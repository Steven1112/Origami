using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerRespawn: MonoBehaviour {


	public GameObject playerPrefab;
	public Transform spawnPoint1;
	private List<Transform> playerSpawn;
	public int lives = 3;
	private MoveScript moveScript;


	// Use this for initialization
	void Start () {
		
		playerSpawn = new List<Transform> ();
		playerSpawn.Add(spawnPoint1);

		GameObject thePlayer = GameObject.Find("Player");
		moveScript = thePlayer.GetComponent<MoveScript>();

	}
	
	// Update is called once per frame
	void Update () {

		if (moveScript.playerCurrentHealth <= 0) {

			//out of the looping if condition
			moveScript.playerCurrentHealth = 100;
			lives--;

			if (lives > 0) {
				StartCoroutine (Dead ());
			} else {
				playerPrefab.GetComponent<Renderer> ().enabled = false;
				//no lives and game over
			}

		}
			
	}

	IEnumerator Dead() {
		Debug.Log ("dead");
		playerPrefab.GetComponent<Renderer> ().enabled = false;
		//hide all hp bars image
		moveScript.HealthBar.GetComponent<CanvasRenderer> ().SetAlpha (0);
		moveScript.HealthBarBack.GetComponent<CanvasRenderer> ().SetAlpha (0);
		yield return new WaitForSeconds(5);
		spawnPlayer();
		Debug.Log ("respawn");
	}

	void spawnPlayer (){

		if (playerPrefab != null) {
			
			print ("Player prefab is not null");
			
		} else {
			
			print("Missing the prefabs");
		}

		//for now is only one respawn point, will increase the range later
		for( int playerCount = 0; playerCount < 1; playerCount++){

			Transform point = playerSpawn[playerCount];

			print("Point:" + point);

			playerPrefab.transform.position = point.position;
			playerPrefab.transform.rotation = point.rotation;
//			playerPrefab.transform.Translate (spawnPoint1.position);
			playerPrefab.GetComponent<Renderer> ().enabled = true;
			//get hp bar images back
			moveScript.HealthBar.GetComponent<CanvasRenderer> ().SetAlpha (1);
			moveScript.HealthBarBack.GetComponent<CanvasRenderer> ().SetAlpha (1);

		}
	}
}