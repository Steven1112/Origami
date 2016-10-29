using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TakeDmg(float dmg){
		Invoke ("AppleGone",2f);

	}
	void AppleGone(){
		Destroy (gameObject);
	}
}
