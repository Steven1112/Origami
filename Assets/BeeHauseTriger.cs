using UnityEngine;
using System.Collections;

public class BeeHauseTriger : MonoBehaviour {
	private Rigidbody rigid;
	private Collider coll;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDmg() {
		coll.isTrigger = false;
		rigid.useGravity = true;
	}
}
