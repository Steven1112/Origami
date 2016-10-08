using UnityEngine;
using System.Collections;

public class FireEffectScript : MonoBehaviour {

	public int fireDamage;
	public Transform target;
	private float health;
	private MoveScript moveScript;
	private GameObject go;

	// Use this for initialization
	void Start () {

		go = GameObject.Find("Player");
		target = go.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void OnCollisionEnter (Collision other) {
		
		// what did i hit?

		print(other.gameObject.tag);

		//attach sword no hurt, only for the player getting hurt
		if (other.gameObject.name == "Player") {
			
			print("Torghing the fire!!!"); 

			
			health = other.gameObject.GetComponent<MoveScript>().playerCurrentHealth;
			
			print ("Fire Damage: " + fireDamage);

		    health -= fireDamage;
			
			print("health" + health);
			other.gameObject.GetComponent<MoveScript>().playerCurrentHealth = health;

			float playPositionX = target.position.x;
			float playPositionZ = target.position.z;

			// if no directly die
			if (target != null){

				playPositionX -= 2;
				playPositionZ -= 2;
				target.position = new Vector3 (playPositionX, target.position.y, playPositionZ);
			
			}


			print("finish minus HP by torching the fire");
			
		}
		
	}

}
