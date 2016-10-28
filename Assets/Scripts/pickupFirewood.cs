using UnityEngine;
using System.Collections;

public class pickupFirewood : MonoBehaviour {

	private openUi ui;
	[HideInInspector] public bool getFirewood;

	// Use this for initialization
	void Start () {
		getFirewood = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter (Collision other) {

		if (other.gameObject.name == "Player") {
			getFirewood = true;
			Destroy (gameObject);
		}

	}
}
