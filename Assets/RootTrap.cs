using UnityEngine;
using System.Collections;

public class RootTrap : MonoBehaviour {
	private GameObject monster;
	private float rootDmg = 999;//root dmg
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag=="Player") {
			coll.gameObject.SendMessage ("TakeDmg", rootDmg);
			Invoke ("DestoryTrap", 3f);
		}
		if (coll.gameObject.tag=="Monster1") {
			coll.gameObject.SendMessage ("TakeDmg", rootDmg);
			Invoke ("DestoryTrap", 3f);
		}
	
	}

	void DestoryTrap(){
		Destroy (gameObject);
	}
}
