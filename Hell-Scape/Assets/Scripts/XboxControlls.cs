using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class XboxControlls : MonoBehaviour {

	public Rigidbody rigidBody;
	public XboxController controller;
	public float movementSpeed = 60;
	public float maxSpeed = 5;
	public Vector3 previousRotationDirection = Vector3.forward; 

	// Use this for initialization
	void Start () {
	rigidBody.GetComponent<Rigidbody> ();
	}
	void Update () {
		RotatePlayer ();
	}
	void FixedUpdate () {
		MovePlayer ();
	}
	private void MovePlayer() {
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		if (movement.magnitude > 1) {
			movement = movement.normalized;
	}
		transform.GetComponent<Rigidbody>().AddForce (movement * movementSpeed);

		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
		}
	}
	private void RotatePlayer ()
	{
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);

		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);

		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirection;
		}
		directionVector = directionVector.normalized;
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);
	}
}