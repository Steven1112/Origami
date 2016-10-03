using UnityEngine;
using System.Collections;

public class MidGroundMoving : MonoBehaviour {
	public float movingSpeedPlayer; //Moving speed accroding to player 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x - movingSpeedPlayer;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x + movingSpeedPlayer;
			this.transform.position = position;
		}
	
	}
}
