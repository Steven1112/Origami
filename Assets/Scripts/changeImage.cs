using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {

	public string changeToImage; // The one that is default when game starts

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void MyButtonClickFunction(Image myImageToUpdate)
	{

//		myImageToUpdate.overrideSprite = Resources.Load(changeToImage) as Sprite;
		myImageToUpdate.GetComponent<CanvasRenderer> ().SetAlpha (0);
	}
}
