using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;	
using UnityEngine.SceneManagement;

public class UI_Countdown : MonoBehaviour
{

	private Text TextCountdown;
	private float CountdownTimerDuration;
	private float CountdownTimerStartTime;

	public static float TimerBonus = 0;

	public static bool IsGameFinished;
	
	// Use this for initialization
	void Start ()
	{
		IsGameFinished = false;
		TextCountdown = GetComponent<Text>();
		SetupCountdownTimer(30);
	}
	
	// Update is called once per frame
	void Update ()
	{
		string TimeMessage = "End Game";

		if (TimerBonus > 0 && !IsGameFinished)
		{
			CountdownTimerStartTime += TimerBonus;
			TimerBonus = 0;
		}

		int TimeLeft = (int) CountdownTimeRemaining();

		if (TimeLeft > 0)
		{
			TimeMessage = "Time: " + LeadingZero(TimeLeft);
		}
		else
		{
			if (!IsGameFinished)
			{
				IsGameFinished = true;
				Time.timeScale = 0;
				//Invoke("RestartLevel", 2);
				RestartLevel();
			}
			
		}

		TextCountdown.text = TimeMessage;
	}

	private void SetupCountdownTimer(float DelaySeconds)
	{
		CountdownTimerDuration = DelaySeconds;
		CountdownTimerStartTime = Time.time;
	}

	private String LeadingZero(int n)
	{
		return n.ToString().PadLeft(3, '0');
	}

	private float CountdownTimeRemaining()
	{
		float elapsedSeconds = Time.time - CountdownTimerStartTime;
		float TimeLeft = CountdownTimerDuration - elapsedSeconds;
		return TimeLeft;
	}

	private void RestartLevel()
	{
		Time.timeScale = 1;
		IsGameFinished = false;
		int SceneId = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(SceneId, LoadSceneMode.Single);
		
	}
}
