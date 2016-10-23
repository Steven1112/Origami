using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MoveScript : MonoBehaviour {
	public float movingSpeed;
	private bool isLeft;
	private bool isRight;
	private bool isGround;
	private  Rigidbody rb;
	public float JumpForce;
	public  Collider[] attackHitBox;
	private float playerHealth = 100;
	public float playerCurrentHealth = 100;
	public float meeleDmg = 10;
	public Image HealthBar;
	public Image HealthBarBack;
	public GameObject mainCam;
	private float ratio;
	Animator anim;
	public float animSpeed = 0.1f;
	private bool root;
	[HideInInspector] public bool enableInput;


	void Awake(){
		isLeft = false;
		isRight = true;
		enableInput = true;
	}

	void Start(){
		rb = gameObject.GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		root = false;
	}

	void Update ()
	{
		//update Health Bar
		ratio = playerCurrentHealth/playerHealth;

		anim.speed = animSpeed;

		if (ratio > 0) {
			HealthBar.rectTransform.localScale = new Vector3 (ratio, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
		}
			
		if (enableInput) {
			
			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (isRight) {
					//turn around
					isLeft = true;
					isRight = false;
					transform.Rotate (Vector3.up * 180f);
				}
				if (!root) {
					Vector3 position = this.transform.position;
					position.x = position.x - movingSpeed;
					this.transform.position = position;
				}
				anim.Play ("Run");
				animSpeed = 0.5f;
			}

			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				anim.Play ("Idle");
				animSpeed = 0.1f;
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				//turn
				if (isLeft) {
					isRight = true;
					isLeft = false;
					transform.Rotate (Vector3.up * -180f);
				}
				if (!root) {
					Vector3 position = this.transform.position;
					position.x = position.x + movingSpeed;
					this.transform.position = position;
				}
				anim.Play ("Run");
				animSpeed = 0.5f;
			}

			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				anim.Play ("Idle");
				animSpeed = 0.1f;
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				if (!root) {
					Vector3 position = this.transform.position;
					position.z = position.z + movingSpeed;
					this.transform.position = position;
				}
				anim.Play ("Run");
				animSpeed = 0.5f;
			}

			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				anim.Play ("Idle");
				animSpeed = 0.1f;
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				if (!root) {
					Vector3 position = this.transform.position;
					position.z = position.z - movingSpeed;
					this.transform.position = position;
				}
				anim.Play ("Run");
				animSpeed = 0.5f;
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				anim.Play ("Idle");
				animSpeed = 0.1f;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				if (isGround) {
					if (!root) {
						rb.AddForce (Vector3.up * JumpForce);
						isGround = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Z)) {
				LaunchAttack (attackHitBox [0]);
				anim.Play("Attack");
				animSpeed = 1.5f;

			}
			if (Input.GetKeyUp (KeyCode.Z)) {
				anim.Play ("Idle");
				animSpeed = 0.1f;
			}
		}
	}

	public void TakeDmg(float dmg){
		//dmg> 900 is special damage 999 is root
		if (dmg > 900) {
			if (dmg == 999f) {
				root = true;
				anim.Play ("Idle");
				animSpeed = 0.1f;
				Invoke ("DisableRoot", 3.0f);//root for 3 sec
			}
		} else {
			playerCurrentHealth -= dmg;
		}
	}
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ground")
			isGround = true;
	}


	private void LaunchAttack(Collider col){
		Collider[] colls = Physics.OverlapBox (col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask ("Hitbox"));
		foreach (Collider c in colls) {
			//Call TakeDmg to everything in the hitbox layer can be used as method in all triger
			c.SendMessageUpwards ("TakeDmg", meeleDmg);
		}

	}

	void DisableRoot(){
		root = false;
	}



}
