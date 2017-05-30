using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText gameOverText;

	private bool gameOver;

	// Use this for initialization
	void Start () {

		gameOver = false;

		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevelName);
			}

	}
	public void GameOver(){

		gameOverText.text = "GAME OVER";
		gameOver = true;
	}
}
