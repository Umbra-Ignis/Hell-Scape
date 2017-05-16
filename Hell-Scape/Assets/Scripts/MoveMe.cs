using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour {

	public float upwardsThrust = 40;
	public float rotationalThrust = 5f;


	// Use this for initialization
	void Start () {
		transform.position = transform.position + new Vector3 (0, 0, 0.1f);	
	}
	
	// Update is called once per frame
	void Update () {
//------------------------------WASD Movement-----------------------------------
		//if (Input.GetKey (KeyCode.W)) {
		//	transform.position = transform.position + new Vector3 (0, 0, 0.1f);
		//}
		//if (Input.GetKey (KeyCode.A)) {
		//	transform.position = transform.position + new Vector3 (-0.1f, 0, 0);	
		//}
		//if (Input.GetKey (KeyCode.S)) {
		//	transform.position = transform.position + new Vector3 (0, 0, -0.1f);	
		//}
		//if (Input.GetKey (KeyCode.D)) {
		//	transform.position = transform.position + new Vector3 (0.1f, 0, 0);	
		//}
		//if (Input.GetKey (KeyCode.LeftControl)) {
		//	transform.position = transform.position + new Vector3 (0.1f, 0, 0);	
		//}
		//if (Input.GetKey (KeyCode.LeftArrow)) {
		//	transform.Rotate (new Vector3 (0, 1, 0));	
		//}
//--------------------------Thrusting controller------------------------------
		if (Input.GetKey (KeyCode.Space)) {
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 20);
		}
		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * 15);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0, 1, 0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0, -1, 0));
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (new Vector3 (1, 0, 0));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (new Vector3 (-1, 0, 0));
		}
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0, 0, 1));
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0, 0, -1));
		}
	}
}