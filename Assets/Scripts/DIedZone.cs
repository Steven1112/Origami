using UnityEngine;
using System.Collections;

public class DIedZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Monster1") {
			Destroy (collision.gameObject);
		}
	}
}
