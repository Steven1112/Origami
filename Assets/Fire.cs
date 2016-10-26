using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public float fireDmgPlayer;
	public float fireDmgMonster;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){
		//Debug.Log (coll.gameObject.name);
		if (coll.gameObject.tag=="Player") {
			coll.gameObject.SendMessage ("TakeDmg", fireDmgPlayer);
			//Destroy (gameObject);
		}
		if (coll.gameObject.tag=="Monster1") {
			//monster step on trap will destory it 
			coll.gameObject.SendMessage ("TakeDmg", fireDmgMonster);
			Destroy (gameObject);
		}
	}
}
