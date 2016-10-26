using UnityEngine;
using System.Collections;

public class StartAFire : MonoBehaviour {

//	public Transform target;
//	private GameObject go;
//	public Animator anim;
	public GameObject fire;
	public float offsetY;
	// Use this for initialization
	void Start () {
//		anim = GetComponent<Animator>();
//		go = GameObject.Find("Player");
//		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Call it when player attack collider in hitbox layer
	public void TakeDmg(){
		// create a fire trap on top of fire camp
		Instantiate (fire, gameObject.transform.position + Vector3.up * offsetY, Quaternion.identity);
	}

//	public void OnTriggerEnter (Collider other) {
//
//		// what did i hit?
//
//		print(other.gameObject.name);
//
//		//attach sword no hurt, only for the player getting hurt
//		if (other.gameObject.name == "SwordAttack") {
//
//			print("Active the starting fire trigger!!!"); 
//
//			anim.Play ("Starting_Fire");
//
//			print("Firing!!!");
//		}
//
//	}
}
