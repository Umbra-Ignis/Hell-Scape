﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public int keysRequired;

	private PlayerController playerController;

//	llows doors to be opened only after picking up  key 
	void Start () {

		GameObject playerControllerObject = GameObject.FindWithTag ("Player");

		if (playerControllerObject != null) {

			playerController = playerControllerObject.GetComponent<PlayerController> ();
		}
	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			if (playerController.keysCollected >= keysRequired) {
				gameObject.SetActive (false);
			}
		}
	}
}
