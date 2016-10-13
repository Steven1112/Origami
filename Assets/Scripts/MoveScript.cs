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
	private float ratio;
	Animator anim;
	public float animSpeed = 0.1f;

	void Awake(){
		isLeft = false;
		isRight = true;
	}

	void Start(){
		rb = gameObject.GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		//update Health Bar
		ratio = playerCurrentHealth/playerHealth;

		anim.speed = animSpeed;

		if (ratio > 0) {
			HealthBar.rectTransform.localScale = new Vector3 (ratio, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (isRight)
			{
				//turn around
				isLeft = true;
				isRight = false;
				transform.Rotate (Vector3.up*180f);
			}
			Vector3 position = this.transform.position;
			position.x = position.x - movingSpeed;
			this.transform.position = position;
			anim.runtimeAnimatorController = Resources.Load ("Run_0") as RuntimeAnimatorController;
			animSpeed = 0.5f;
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			anim.runtimeAnimatorController = Resources.Load ("Idle_0") as RuntimeAnimatorController;
			animSpeed = 0.1f;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//turn
			if (isLeft) 
			{
				isRight = true;
				isLeft = false;
				transform.Rotate (Vector3.up*-180f);
			}
			Vector3 position = this.transform.position;
			position.x = position.x + movingSpeed;
			this.transform.position = position;
			anim.runtimeAnimatorController = Resources.Load ("Run_0") as RuntimeAnimatorController;
			animSpeed = 0.5f;
		}

		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			anim.runtimeAnimatorController = Resources.Load ("Idle_0") as RuntimeAnimatorController;
			animSpeed = 0.1f;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.z=position.z+movingSpeed;
			this.transform.position = position;
			anim.runtimeAnimatorController = Resources.Load ("Run_0") as RuntimeAnimatorController;
			animSpeed = 0.5f;
		}

		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			anim.runtimeAnimatorController = Resources.Load ("Idle_0") as RuntimeAnimatorController;
			animSpeed = 0.1f;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.z=position.z-movingSpeed;
			this.transform.position = position;
			anim.runtimeAnimatorController = Resources.Load ("Run_0") as RuntimeAnimatorController;
			animSpeed = 0.5f;
		}

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			anim.runtimeAnimatorController = Resources.Load ("Idle_0") as RuntimeAnimatorController;
			animSpeed = 0.1f;
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (isGround) 
			{
				
				rb.AddForce (Vector3.up * JumpForce);
				isGround = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			LaunchAttack (attackHitBox [0]);
			anim.runtimeAnimatorController = Resources.Load ("Attack_0") as RuntimeAnimatorController;
			animSpeed = 2.5f;
		}
		if (Input.GetKeyUp(KeyCode.Z)) {
			anim.runtimeAnimatorController = Resources.Load ("Idle_0") as RuntimeAnimatorController;
			animSpeed = 0.1f;
		}
	}
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ground")
			isGround = true;
	}

	private void LaunchAttack(Collider col){
		Collider[] colls = Physics.OverlapBox (col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask ("Hitbox"));
		foreach (Collider c in colls) {
			c.SendMessageUpwards ("TakeDmg", meeleDmg);
		}

	}

}
