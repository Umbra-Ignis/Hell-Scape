using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour {

	public GameObject victory;

	// Use this for initialization
	void Start () {
		victory.SetActive (false);
	}
//	this resets the level 
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
// this allows the canvas to trigger the victory screen when player enters trigger
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			victory.SetActive (true);
			Destroy (other.gameObject);
		}
	}
}
