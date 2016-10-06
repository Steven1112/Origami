using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

	private float enemyHealth = 100;
	private float enemyCurrentHealth = 100;

	public Image HealthBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//update Health Bar
		float ratio = enemyCurrentHealth/enemyHealth;
		HealthBar.rectTransform.localScale =  new Vector3 (ratio, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
		if (enemyCurrentHealth <= 0) {
			Died ();
		}

	}

	public void TakeDmg(float dmg){
		enemyCurrentHealth -= dmg;
	}
	private void Died(){
		Destroy (gameObject);
	}
}
