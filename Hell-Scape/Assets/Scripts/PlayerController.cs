using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Light torch;
	public float jumpHeight = 8f;
	public float gravity = 20f;
	public float runningSpeed = 2f;
	public float maxSpeed = 

	private bool grounded = true;
	private bool isActive;

	// Use this for initialization
	void Start () {

		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			transform.position = transform.position + new Vector3 (0, 0, 0.1f);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position = transform.position + new Vector3 (-0.1f, 0, 0);	
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position = transform.position + new Vector3 (0, 0, -0.1f);	
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position = transform.position + new Vector3 (0.1f, 0, 0);	
		}
		if (Input.GetKey (KeyCode.Space)) {
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 20);
		}
	// Toggle torch 
		if (Input.GetKeyDown (KeyCode.E))
		    if (isActive == false) {
			    torch.enabled = true;
			    isActive = true;
		} else if (isActive == true) {
			torch.enabled = false;
			isActive = false;
		}
		//Sprint 

	}

		private void JumpingMechanic () {

		if (!grounded && (GetComponent<Rigidbody> ().velocity.y == 0)) {
			grounded = true;
			}
			if (Input.GetKeyDown (KeyCode.Space) && grounded ==true) {
				GetComponent<Rigidbody> ().velocity = new Vector3 (runningSpeed, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			    grounded = false;
		}
	}
}
