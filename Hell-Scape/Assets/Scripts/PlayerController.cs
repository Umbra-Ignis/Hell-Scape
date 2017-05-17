using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	bool grounded;
	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.Space;
	public KeyCode torchKey = KeyCode.E;
	//public int upwardThrust;
	public float jumpLimit = 3;
	public float maxSpeed = 25;
	public float speed = 25;
	//public Rigidbody rb;

	// Use this for initialization
	void Start () {
		grounded == true;
	}
	
	// Update is called once per frame
	void Update () {

		//Moves the Player Forward
		if (Input.GetKey (forwardsKey)) {
			//transform.position = transform.position + new Vector3 (0, 0, 0.1f);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 30);
			speed = speed + maxSpeed;
		}
		//Moves the player Left
		if (Input.GetKey (leftKey)) {
			//transform.position = transform.position + new Vector3 (-0.1f, 0, 0);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.left * 30);
			speed = speed + maxSpeed;
		}
		//Moves the player Backward
		if (Input.GetKey (backwardsKey)) {
			//transform.position = transform.position + new Vector3 (0, 0, -0.1f);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.back * 30);
			speed = speed + maxSpeed;
		}
		//Moves the Player Right
		if (Input.GetKey (rightKey)) {
			//transform.position = transform.position + new Vector3 (0.1f, 0, 0);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * 30);
			speed = speed + maxSpeed;
		}
		//Causes the player to Jump
		if (Input.GetKey (jumpKey)) {
			//transform.position = transform.position + new Vector3 (0, 1f, 0);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 35);
			speed = speed + maxSpeed;
			if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			}
//--------------------------------------------------------------------------------------------
			// Causes player force to be negated on key up 		
			//
			//if (Input.GetKeyUp (jumpKey)) {    
			//	gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 300);
			//}
			//if (Input.GetKeyUp (forwardsKey)) {
			//	gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 10);
			//}
			//if (Input.GetKeyUp (leftKey)) {
			//	gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.left * 10);
			//}
			//if (Input.GetKeyUp (backwardsKey)) {
			//	gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.back * 10);
			//}
			//if (Input.GetKeyUp (rightKey)) {
			//	gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * 10);
			//}
//---------------------------------------------------------------------------------------------
			if (speed > maxSpeed) {
				speed = maxSpeed;
			}
		}
	}
}