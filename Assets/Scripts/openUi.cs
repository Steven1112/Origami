using UnityEngine;
using System.Collections;

public class openUi : MonoBehaviour {

	[HideInInspector]public GameObject inventoryPanel;
	[HideInInspector]public GameObject firewoodButton;
	[HideInInspector]public GameObject firewoodText;
	[HideInInspector]public GameObject axeButton;
	[HideInInspector]public GameObject axeText;
	[HideInInspector]public GameObject flintstonesButton;
	[HideInInspector]public GameObject flintstonesText;
	[HideInInspector]public GameObject emptyText;
	private pickupFirewood item1;
	private pickupAxe item2;
	private pickupFlintstones item3;

	// Use this for initialization
	void Start () {
		
		inventoryPanel = GameObject.Find("InventoryPanel");
		firewoodButton = GameObject.Find("FirewoodButton");
		axeButton = GameObject.Find("AxeButton");
		flintstonesButton = GameObject.Find("FlintstonesButton");
		emptyText = GameObject.Find("EmptyText");
		inventoryPanel.SetActive (false);
		firewoodButton.SetActive (false);
		axeButton.SetActive (false);
		flintstonesButton.SetActive (false);
		emptyText.SetActive (true);

		GameObject firewood = GameObject.Find("Firewood");
		item1 = firewood.GetComponent<pickupFirewood>();
		GameObject axe = GameObject.Find("Axe");
		item2 = axe.GetComponent<pickupAxe>();
		GameObject flintstones = GameObject.Find("Flintstones");
		item3 = flintstones.GetComponent<pickupFlintstones>();
	}
	
	// Update is called once per frame
	void Update () {

		if (item1.getFirewood == true) {
			firewoodButton.SetActive (true);
			emptyText.SetActive (false);
		}

		if (item2.getAxe == true) {
			axeButton.SetActive (true);
			emptyText.SetActive (false);
		}

		if (item3.getFlintstones == true) {
			flintstonesButton.SetActive (true);
			emptyText.SetActive (false);
		}
	
	}

	public void showUI(){
		
		inventoryPanel.SetActive (true);

	}

	public void hideUI(){
		
		inventoryPanel.SetActive (false);

	}

//	public void getAxe(){
//		
//		axeButton.SetActive (true);
//
//	}
//
//	public void getFirewood(){
//
//		firewoodButton.SetActive (true);
//
//	}
//
//	public void getFlintstones(){
//
//		flintstonesButton.SetActive (true);
//
//	}
}
