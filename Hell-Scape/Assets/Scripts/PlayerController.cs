using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	// controller support
	private Rigidbody rigidbody;
	public XboxController controller;

	public Light torch;
	public float jumpHeight = 8f;
	public float gravity = 20f;
	public float runningSpeed = 2f;
	public float maxSpeed = 5f;
	public float movementSpeed = 1f;

	private bool grounded = true;
	[HideInInspector]
	public bool isActive;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody> ();

		isActive = true;
	}
	void FixedUpdate () {
		JumpingMechanic ();

		//MovePlayer ();
	}
	//private void MovePlayer (){
	//	float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
	//	float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
	//
	//	Vector3 movement = new Vector3 (axisX, 0, axisZ);
	//
	//	rigidbody.AddForce (movement * movementSpeed);
	//
	//	if (rigidbody.velocity.magnitude > maxSpeed) {
	//		rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
	//	}
	//}
	//	private void RotatePlayer ()
	//	{
	//
	//		//Allows for 360 Degrees rotation on the Right Stick on X & Y Axis'
	//		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
	//		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);
	//
	//		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);
	//}
	// Update is called once per frame
	void Update (){

//------------------------------------------------------------------------------------
		if (Input.GetKey (KeyCode.W)) {
			//transform.position = transform.position + new Vector3 (0, 0, 0.1f);
			transform.position = transform.position + (transform.forward * 0.1f);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (new Vector3 (0, -2f, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			//transform.position = transform.position + new Vector3 (0, 0, -0.1f);
			transform.position = transform.position + (transform.forward * -0.1f);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (new Vector3 (0, 2f, 0));
		}
		//if (Input.GetKey (KeyCode.Space)) {
		//	gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 20);
		//}
//-----------------------------------------------------------------------------------
		// Toggle torch 
		if (Input.GetKeyDown (KeyCode.E))
		if (isActive == false)
		 {
			torch.enabled = true;
			isActive = true;
		} else if (isActive == true) {
			torch.enabled = false;
			isActive = false;
		}
		//Sprint 
		if (Input.GetKey (KeyCode.LeftShift)) {
			transform.position = transform.position + (transform.forward * 0.05f);
		} 
	}

	private void JumpingMechanic () {

		if (!grounded && (GetComponent<Rigidbody> ().velocity.y == 0)) {
			grounded = true;
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded ==true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}
	}
}
