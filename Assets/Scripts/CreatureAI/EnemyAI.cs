using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyAI : MonoBehaviour {

	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public MeshRenderer meshRendererFlag;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public StateMachine currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	private float enemyHealth = 100;
	private float enemyCurrentHealth = 100;

	public Image HealthBar;

	void Awake () {
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{
		currentState = patrolState;
	}
	// Update is called once per frame
	void Update () {
		currentState.UpdateState ();
		//update Health Bar
		float ratio = enemyCurrentHealth/enemyHealth;
		HealthBar.rectTransform.localScale =  new Vector3 (ratio, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
		if (enemyCurrentHealth <= 0) {
			Died ();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.TriggerEnter(other);
	}
	public void TakeDmg(float dmg){
		enemyCurrentHealth -= dmg;
	}
	private void Died(){
		Destroy (gameObject);
	}
}
