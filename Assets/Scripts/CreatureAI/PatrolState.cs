﻿using UnityEngine;
using System.Collections;

public class PatrolState : StateMachine {

	private readonly EnemyAI enemy;
	private int nextWayPoint;
	public PatrolState (EnemyAI enemyAI)
	{
		enemy = enemyAI;
	}

	public void UpdateState()
	{
		Look ();
		Patrol ();
	}

	public void TriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState()
	{
		
	}

	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}
	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}
	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	void Patrol ()
	{
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		enemy.navMeshAgent.Resume ();

		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
			nextWayPoint =(nextWayPoint + 1) % enemy.wayPoints.Length;

		}


	}
}
