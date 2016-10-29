using UnityEngine;
using System.Collections;

public class TurnOnGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Monster1") {
			Rigidbody rigid =other.gameObject.GetComponent<Rigidbody> ();
			rigid.useGravity = true;
		}
	}
}
