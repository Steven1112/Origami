using UnityEngine;
using System.Collections;

public class ChaseState : StateMachine 

{

	private readonly EnemyAI enemy;
	private float killTimer;

	public ChaseState (EnemyAI enemyAI)
	{
		enemy = enemyAI;
		killTimer = 0;
	}

	public void UpdateState()
	{
		Look ();
		Chase ();
	}

	public void TriggerEnter(Collider coll)
	{

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

	}

	public void ToKillState()
	{
		enemy.currentState = enemy.killState;
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position) - enemy.eyes.transform.position;
		if (Physics.SphereCast (enemy.eyes.transform.position,enemy.visionSphereR, enemyToTarget, out hit, enemy.sightRange,enemy.notInVisionLayer.value) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
		}
		else
		{
			float dist = Vector3.Distance (enemy.chaseTarget.position, enemy.eyes.transform.position);
			if (dist < enemy.attackDist) {
				ToKillState ();
			//	Debug.Log ("Kill");
			} else {
				//Debug.Log ("Alert");
				ToAlertState ();
			}
		}

	}

	private void Chase()
	{
		enemy.anim.Play ("Run");
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.Resume ();

	}



}