using UnityEngine;
using System.Collections;

public class StartAFire : MonoBehaviour {

	public Transform target;
	private GameObject go;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		go = GameObject.Find("Player");
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider other) {

		// what did i hit?

		print(other.gameObject.name);

		//attach sword no hurt, only for the player getting hurt
		if (other.gameObject.name == "SwordAttack") {

			print("Active the starting fire trigger!!!"); 

			anim.Play ("Starting_Fire");

			print("Firing!!!");
		}

	}
}
