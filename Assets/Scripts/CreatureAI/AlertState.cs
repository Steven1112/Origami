using UnityEngine;
using System.Collections;

public class AlertState : StateMachine 

{
	private readonly EnemyAI enemy;
	private float searchTimer;

	public AlertState (EnemyAI enemyAI)
	{
		enemy = enemyAI;
	}

	public void UpdateState()
	{
		Look ();
		Search ();
	}

	public void TriggerEnter(Collider coll)
	{

	}

	public void ToPatrolState()
	{
		enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
	}

	public void ToAlertState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}
	public void ToKillState()
	{
		
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.SphereCast (enemy.eyes.transform.position,enemy.visionSphereR, enemy.eyes.transform.forward, out hit, enemy.sightRange,enemy.notInVisionLayer.value) && hit.collider.CompareTag ("Player")) {
			//Debug.Log (hit.collider.name);
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	private void Search()
	{
		enemy.anim.Play ("Ideal");
		enemy.meshRendererFlag.material.color = Color.yellow;
		enemy.navMeshAgent.Stop ();
		enemy.eyes.transform.Rotate (0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
		searchTimer += Time.deltaTime;

		if (searchTimer >= enemy.searchingDuration)
			ToPatrolState ();
	}




}