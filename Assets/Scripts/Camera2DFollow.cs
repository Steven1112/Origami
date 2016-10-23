using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 0;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float cameraY;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	//private bool changeAngles;
	// Use this for initialization
	void Start () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
//		changeAngles = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
//		if(changeAngles){
//		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
//		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
//			newPos = new Vector3 (newPos.x, 45.0f, newPos.z);
//			//newPos = newPos + Vector3.up * 5;
//			transform.position = newPos;
//			//lastTargetPosition = target.position+ Vector3.up * 5;	
//			transform.localRotation=Quaternion.AngleAxis(45,Vector3.right);
//		}else{
			Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
		 // make it have certain Height
			newPos = new Vector3 (newPos.x, cameraY, newPos.z);
			transform.position = newPos;
			//transform.localRotation = Quaternion.identity;
//		}
		lastTargetPosition = target.position;		
	}

//	public void ChangeView(){
//		changeAngles = true;
//	}
//	public void ResetView(){
//		changeAngles = false;
//	}
}
