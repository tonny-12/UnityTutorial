using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text gameOverText;
	public Text restartText;

	private bool gameOver;
	private bool restart;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
		if (gameOver) {
			restartText.text = "Press Space for Restart";
			restart = true;
		}
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
