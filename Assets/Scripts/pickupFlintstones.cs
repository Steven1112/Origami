using UnityEngine;
using System.Collections;

public class pickupFlintstones : MonoBehaviour {

	private openUi ui;
	[HideInInspector] public bool getFlintstones;

	// Use this for initialization
	void Start () {
		getFlintstones = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter (Collision other) {

		if (other.gameObject.name == "Player") {
			getFlintstones = true;
			Destroy (gameObject);
		}

	}
}
