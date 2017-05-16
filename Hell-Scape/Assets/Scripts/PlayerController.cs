using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 0.1f;
	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.Space;
	public KeyCode torchKey = KeyCode.E;
	//public int upwardThrust;
	public float jumpLimit;
	public float variableForce;
	//public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Moves the Player Forward
		if (Input.GetKey (forwardsKey)) {
			//transform.position = transform.position + new Vector3 (0, 0, 0.1f);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 25);

		}
		//Moves the player Left
		if (Input.GetKey (leftKey)) {
			//transform.position = transform.position + new Vector3 (-0.1f, 0, 0);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.left * 25);

		}
		//Moves the player Backward
		if (Input.GetKey (backwardsKey)) {
			transform.position = transform.position + new Vector3 (0, 0, -0.1f);
		}
		//Moves the Player Right
		if (Input.GetKey (rightKey)) {
			transform.position = transform.position + new Vector3 (0.1f, 0, 0);
		}
		//Causes the player to Jump
		if (Input.GetKeyDown (jumpKey)) {
			//transform.position = transform.position + new Vector3 (0, 1f, 0);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 350);
			//rb.AddForce (Vector3.up * variableForce, ForceMode.Impulse);
		}
	}
}