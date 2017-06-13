using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour {
	
	public Text victoryText;
	public Text restartText;

	public bool victory;
	// Use this for initialization
	void Start () {
		victory = false;
		victoryText.text = "";
		restartText.text = "";
	}
//	this resets the level 
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
		if (victory) {
			victoryText.text = "LEVEL COMPLETE!";
			restartText.text = "Press 'R' to Restart";
		}
	}
// this allows the canvas to trigger the victory screen when player enters trigger
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			victory = true;
			Destroy (other.gameObject);
		}
	}
}