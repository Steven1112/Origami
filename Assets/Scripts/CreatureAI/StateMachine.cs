using UnityEngine;
using System.Collections;

public interface StateMachine {

	void UpdateState ();

	void TriggerEnter(Collider coll);

	void ToPatrolState ();

	void ToAlertState ();

	void ToChaseState ();

	void ToKillState ();
}
