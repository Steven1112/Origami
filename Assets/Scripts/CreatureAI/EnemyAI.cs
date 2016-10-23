using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyAI : MonoBehaviour {

	public float searchingTurnSpeed ;
	public float searchingDuration ;
	public float killDuration;
	public float sightRange ;
	public Transform[] wayPoints;
	public Transform eyes;
	public MeshRenderer meshRendererFlag;
	public float visionSphereR;
	public Image HealthBar;
	public LayerMask notInVisionLayer;
	public float enemyDmg;
	public float attackDist;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public StateMachine currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public KillState killState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Animator anim;
	private float enemyHealth = 100;
	private float enemyCurrentHealth = 100;
	private float originalSpeed;


	void Awake () {
		killState = new KillState (this);
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
	

		navMeshAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponentInChildren<Animator> ();
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
		//dmg> 900 is special damage 999 is root
		if (dmg > 900) {
			if (dmg == 999f) {
				originalSpeed = navMeshAgent.speed;
				navMeshAgent.speed = 0;
				Invoke ("DisableRoot", 3.0f);//root for 3 sec
			}
		} else {
			enemyCurrentHealth -= dmg;
		}
	}
	private void Died(){
		Destroy (gameObject);
	}
	public void DisableRoot(){
		navMeshAgent.speed = originalSpeed;
	}
}
