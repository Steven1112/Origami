using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public float movingSpeed;
	private bool isLeft;
	private bool isRight;
	private bool isGround;
	private  Rigidbody rb;
	public float JumpForce;
	void Awake(){
		isLeft = false;
		isRight = true;
	}
	void Start(){
		rb = gameObject.GetComponent<Rigidbody>();
	}
	void Update ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (isRight)
			{
				//turan around
				isLeft = true;
				isRight = false;
				transform.Rotate (Vector3.up*180f);
			}
			Vector3 position = this.transform.position;
			position.x = position.x - movingSpeed;
			this.transform.position = position;
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
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.z=position.z+movingSpeed;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.z=position.z-movingSpeed;
			this.transform.position = position;
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (isGround) 
			{
				Debug.Log (isGround);
				rb.AddForce (Vector3.up * JumpForce);
				isGround = false;
			}
		}
	}
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ground")
			isGround = true;
	}
}
