﻿using UnityEngine;
using System.Collections;

public class CutBridge : MonoBehaviour {

//	public Transform target;
//	public Transform monster;
//	private GameObject go;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
//		go = GameObject.Find("Player");
//		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//call it when player attack on collider in hitbox layer
	public void TakeDmg() {

		// what did i hit

		//attach sword no hurt, only for the player getting hurt

			print("Active the trigger!!!"); 

			anim.Play ("BridgeBroken1");

			//print("Bridge Broken!!!");

			//falling down
		//	monster.transform.position = new Vector3 (monster.transform.position.x, monster.transform.position.y - 10, monster.transform.position.z);
			//print("Moster position:" + monster.transform.position);
		}


}
