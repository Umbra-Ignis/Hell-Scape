using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceController: MonoBehaviour {

	public float jumpHeight = 8f;
	public float gravity = 20f;
	public float runningSpeed = 2f;
	public float slideTimer = 1f;

	public GameObject mainCamera;

	private float timer;
	private bool grounded = true;
	private bool sliding = false;
	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {
		
	}

	void Update () {

		if (sliding == true) {
			timer += Time.deltaTime;
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		MovePlayer ();
		MoveCamera ();
	}

	private void PlayerSlide () {
		
	}
		
	private void MovePlayer () {
		transform.position += Vector3.right * runningSpeed * Time.deltaTime;

		if (!grounded && (GetComponent<Rigidbody> ().velocity.y == 0)) {
			grounded = true;
		}
					
		if (Input.GetButtonDown ("Jump") && grounded == true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (runningSpeed, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}




		if (Input.GetKeyDown (KeyCode.C) && grounded == true) {
			GetComponent<Rigidbody> ().transform.rotation = Quaternion.AngleAxis (90f, Vector3.forward);
			sliding = true;
			grounded = false;
		} 

		if (timer > slideTimer) {
			sliding = false;
			grounded = true;
			timer = 0;
		}

		if (sliding == false) {
			GetComponent<Rigidbody> ().transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
		}
			



		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -gravity * GetComponent<Rigidbody> ().mass, 0));
	}

	private void MoveCamera () {
		float cameraXpos = this.transform.position.x;
		float cameraYpos = this.transform.position.y + 2;
		float cameraZpos = this.transform.position.z - 10;
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

	}
}