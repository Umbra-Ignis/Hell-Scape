using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {

	public ObstructionDetection obstructionDetec;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			Debug.Log ("Enter");
			obstructionDetec.StartRayCast ();
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("Exit");
			obstructionDetec.StopRayCast ();
		}
	}
}