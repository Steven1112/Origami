using UnityEngine;
using System.Collections;

public class KillState : StateMachine {


	private readonly EnemyAI enemy;
	private float killTimer;

	public KillState (EnemyAI enemyAI)
	{
		enemy = enemyAI;
		killTimer = 0;
	}

	public void UpdateState()
	{
		Look ();
	}

	public void TriggerEnter(Collider coll)
	{

	}

	public void ToPatrolState()
	{

	}

	public void ToAlertState()
	{
		
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}

	public void ToKillState()
	{
	}

	private void Look()
	{
			enemy.meshRendererFlag.material.color = Color.red;

			float dist = Vector3.Distance (enemy.chaseTarget.position, enemy.eyes.transform.position);
			if (dist < enemy.attackDist) {
				killTimer += Time.deltaTime;
				if (killTimer >= enemy.killDuration) {
					enemy.chaseTarget.SendMessage ("TakeDmg", enemy.enemyDmg);
					enemy.anim.Play ("Attack");
					killTimer = 0;
				}
			} else {
				//Debug.Log ("BackTOAlert");
				ToChaseState ();
			}


	}


}
