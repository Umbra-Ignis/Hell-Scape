using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// controller support
	private Rigidbody rigidbody;

	public Light torch;
	public float jumpHeight;
	public float gravity = 20f;
	public float runningSpeed;
	public float maxSpeed;
	public float movementSpeed;

	private bool grounded = true;
	[HideInInspector]
	public bool isActive;

	public GUIText gameOverText;

	private bool gameOver;

	private GameObject dead;
	private GameObject victory;

	// Use this for initialization
	void Start () {

		gameOver = false;

		gameOverText.text = "";

		rigidbody = GetComponent<Rigidbody> ();

		isActive = true;

		dead = GameObject.FindGameObjectWithTag ("Dead");
	}
	void FixedUpdate () {
		JumpingMechanic ();

	}
	// Update is called once per frame
	void Update (){



//------------------------------------Player Controlls------------------------------------------------
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
// 	Toggle torch 
		if (Input.GetKeyDown (KeyCode.E))
		if (isActive == false)
		 {
			torch.enabled = true;
			isActive = true;
		} else if (isActive == true) {
			torch.enabled = false;
			isActive = false;
		}
//		Sprint 
		if (Input.GetKey (KeyCode.LeftShift)) {
			transform.position = transform.position + (transform.forward * 0.05f);
		} 
	}

	private void JumpingMechanic () {
//		Allows the player to jump
		if (!grounded && (GetComponent<Rigidbody> ().velocity.y <= 1)) {
			grounded = true;
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded ==true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}
	}
	void OnCollisionEnter (Collision other) {
//		Player Death Mechanic 
		if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			dead.transform.GetChild (0).gameObject.SetActive (true);
		}
		if (other.gameObject.tag == "Victory") {
			victory.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
