﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	void OnCollisionEnter (Collision other) {

		if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
		}
	}
}
