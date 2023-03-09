using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GoalScript blue, green, red, orange;

	private bool isGameOver = true;
	private float elapsedTime = 0;
	private bool isRunning = true;

	void Update ()
	{
		// Add time to the clock if the game is running
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}
		// If all four goals are solved then the game is over
		isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved;
		if (isGameOver)
			FinishedGame();
	}
	
	//This resets to game back to the way it started
	private void StartGame()
	{
		isGameOver = false;
		isRunning = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Runs when the player gets all goals finished
	public void FinishedGame()
	{
		isGameOver = true;
		isRunning = false;
	}

	void OnGUI()
	{
		if(!isRunning)
		{			
			string message = "Click or Press Enter to Play Again";

			GUI.Box(new Rect(Screen.width / 2 - 65, 155, 130, 40), "Your Time Was");
			GUI.Label(new Rect(Screen.width / 2 - 10, 170, 20, 30), ((int)elapsedTime).ToString());

			//Define a new rectangle for the UI on the screen
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2 + 20, 240, 30);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
				//start the game if the user clicks to play
				StartGame ();
			}
		}
	}
}