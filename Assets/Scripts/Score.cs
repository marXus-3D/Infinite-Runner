using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	private float score = 0f;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 10;
	private bool isOof = false;

	public Text scoreText;
	public DeathMenu deathMenu;
	
	// Update is called once per frame
	void Update () {

		if (isOof)
			return;

		if (score >= scoreToNextLevel)
			LevelUp();

		score += Time.deltaTime * difficultyLevel;
		scoreText.text = ((int)score).ToString ();
	}

	void LevelUp()
	{
		if(difficultyLevel == maxDifficultyLevel)
			return;

		scoreToNextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
		Debug.Log(difficultyLevel);
	}

	public void OnDeath()
	{
		isOof = true;
		deathMenu.ToggleEndMenu(score);
	}
}
