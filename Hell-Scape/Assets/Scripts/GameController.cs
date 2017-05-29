using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private bool gameOver;
	private bool restart;

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
	public void GameOver(){
		gameOver = true;
		gameOverText.text = "GAME OVER";
	}
}
