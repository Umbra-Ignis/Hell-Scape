using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	public bool gameOver;
	public bool restart;

	public GUIText gameOverText;
		
	
	// Use this for initialization
	void Start () {
		
		gameOver = false;

		gameOverText.text = "";

	}

	// Update is called once per frame
	void Update () {

		if (restart) {
			
			if (Input.GetKeyDown (KeyCode.R)) {
				
				Application.LoadLevel (Application.loadedLevelName);
			}
		}
	}
	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Enemy") {

			Destroy (gameObject);
			GameOver ();
		}

	}

	public void GameOver(){

		restart = true;
		gameOver = true;
		gameOverText.text = "GAME OVER";
	}
}
