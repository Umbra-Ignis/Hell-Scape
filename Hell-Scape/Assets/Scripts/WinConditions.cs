using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour {

	public GameObject victory;

	// Use this for initialization
	void Start () {
		victory.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			victory.SetActive (true);
			Destroy (other.gameObject);
		}
	}
}
