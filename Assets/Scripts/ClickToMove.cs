using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	public float ActionDistance;
	public float ActionRate;

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy;
	private Ray VisionRay;
	private RaycastHit VisonHit;
	private bool walking;
	private bool enemyClicked;
	private float nextAction;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButtonDown ("Fire1")) {//mouse click
			if (Physics.Raycast (ray, out hit, 200f)) {//cast ray to mouse click
				//AI Stuff

				if (hit.point.x <= transform.position.x) {//flip around
					
					transform.rotation = Quaternion.AngleAxis(180,Vector3.up);//left
				} else {
					transform.rotation = Quaternion.AngleAxis(0,Vector3.up);
				}
				if (hit.collider.CompareTag ("Monster1")) {//click to monster
					targetedEnemy = hit.transform;
					enemyClicked = true;
//					Debug.Log ("Enemy");
				} else {//click else where
					walking = true;
					enemyClicked = false;
					navMeshAgent.destination = hit.point;
					navMeshAgent.Resume();
//					Debug.Log ("elseWhere");
				}
			}
		}
		if (enemyClicked) { //Click an Enemy
			MoveAndAction();
		}

		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
				walking = false;
		} else {
			walking = true;
		}
		anim.SetBool ("IsRunning", walking);
	}

	private void MoveAndAction()
	{
		if (targetedEnemy == null)
			return;
		navMeshAgent.destination = targetedEnemy.position;
		if (navMeshAgent.remainingDistance >= ActionDistance) {

			navMeshAgent.Resume();
			walking = true;
		}

		if (navMeshAgent.remainingDistance <= ActionDistance) {

			transform.LookAt(targetedEnemy);
			Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;
			if (Time.time > nextAction)
			{
				nextAction = Time.time + ActionRate;
				//shootingScript.Shoot(dirToShoot);
			}
			navMeshAgent.Stop();
			walking = false;
		}
	}


}

