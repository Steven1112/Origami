using UnityEngine;
using System.Collections;

public class BeeHouseAttack : MonoBehaviour {
	public float beesDmgPlayerPerSecond;
	public float beesDmgMonsterPerSecond;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		InvokeRepeating ("OnCollisionEnter", 3f, 1f);

	}

	public void OnCollisionEnter(Collision coll){

		print (coll);
		if (coll.gameObject.tag=="Player") {
			coll.gameObject.SendMessage ("TakeDmg", beesDmgPlayerPerSecond);
			//Destroy (gameObject);
		}
		if (coll.gameObject.tag=="Monster1") {
			//monster step on trap will destory it 
			coll.gameObject.SendMessage ("TakeDmg", beesDmgMonsterPerSecond);
			Destroy (gameObject);
		}
	}
}
