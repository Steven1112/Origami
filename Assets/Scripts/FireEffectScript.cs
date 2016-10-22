using UnityEngine;
using System.Collections;

public class FireEffectScript : MonoBehaviour {

	public int fireDamage;
	public int fireMonsterDamage;
	public Transform target;
	public Transform targetMonster;
	private float health;
	private float monsterHealth;
	private MoveScript moveScript;
	private Enemy EnemyScript;
	private GameObject go;
	private GameObject monster;

	// Use this for initialization
	void Start () {

		go = GameObject.Find("Player");
		monster = GameObject.Find("Enemy");
		target = go.transform;
		targetMonster = monster.transform;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void OnCollisionEnter (Collision other) {
		
		// what did i hit?

		//attach sword no hurt, only for the player getting hurt
		if (other.gameObject.name == "Player") {
			
			print("Torching the fire!!!"); 

			print(other.gameObject.name);

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
			

		if (other.gameObject.name == "Creature") {

			print("Monster torching the fire!!!"); 

			print("Monster" +other.gameObject.name);

			monsterHealth = other.gameObject.GetComponent<Enemy>().enemyCurrentHealth;

			print ("Fire Monster Damage: " + fireMonsterDamage);

			monsterHealth -= fireMonsterDamage;

			print("MonsterHealth" + monsterHealth);
			other.gameObject.GetComponent<Enemy>().enemyCurrentHealth = monsterHealth;

			float playPositionX = targetMonster.position.x;
			float playPositionZ = targetMonster.position.z;

			// if no directly die
			if (target != null){

				playPositionX -= 2;
				playPositionZ -= 2;
				target.position = new Vector3 (playPositionX, targetMonster.position.y, playPositionZ);

			}


			print("finish minus monster HP by torching the fire");

		}
		
	}

}