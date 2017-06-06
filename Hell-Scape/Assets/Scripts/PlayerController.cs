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

	public int keysCollected;

	public GUIText keyText;

	private bool grounded = true;
	[HideInInspector]
	public bool isActive;

//	public GUIText gameOverText;
//	public GUIText victoryText;

//	private bool gameOver;
	private bool win;

	private GameObject dead;
//	private GameObject victory;

	// Use this for initialization
	void Start () {

		keyText.text = "Keys: 0";

		win = false;
//		gameOver = false;

//		gameOverText.text = "";
//		victoryText.text = "";

		rigidbody = GetComponent<Rigidbody> ();

		isActive = true;

		dead = GameObject.FindGameObjectWithTag ("Dead");
//		win = GameObject.FindGameObjectWithTag ("Victory");
	}
	void FixedUpdate () {
		JumpingMechanic ();

	}
	// Update is called once per frame
	void Update (){
//------------------------------------Player Movement------------------------------------------------
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
//		if (Input.GetKeyDown (KeyCode.E))
//		if (isActive == false)
//		 {
//			torch.enabled = true;
//			isActive = true;
//		} else if (isActive == true) {
//			torch.enabled = false;
//			isActive = false;
//		}
//		Sprint 
		if (Input.GetKey (KeyCode.LeftShift)) {
			transform.position = transform.position + (transform.forward * 0.05f);
		} 

		keyText.text = "Keys: " + keysCollected;
	}

	private void JumpingMechanic () {
//		Allows the player to jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}
	}
	void OnCollisionEnter (Collision other) {
//			Player Death Mechanic 
		if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			dead.transform.GetChild (0).gameObject.SetActive (true);
		}
		if (other.gameObject.tag == "Floor") {
			grounded = true;
		}
	}
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Key") {

			AddKey ();
			Destroy (other.gameObject);
		}
	}
	public void AddKey (){

		keysCollected++;
	}
}
