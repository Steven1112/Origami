using UnityEngine;
using System.Collections;

public class pickupAxe : MonoBehaviour {

	private openUi ui;
	[HideInInspector] public bool getAxe;

	// Use this for initialization
	void Start () {
		getAxe = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter (Collision other) {

		if (other.gameObject.name == "Player") {
			getAxe = true;
			Destroy (gameObject);
		}

	}
}
