﻿using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_start : MonoBehaviour {

	private GameController gameC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
	}

	private void OnEnable()
	{
		GetComponent<MetaGesture>().StateChanged += metaHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<MetaGesture>().StateChanged -= metaHandler;
	}
	
	void metaHandler (object sender, EventArgs e)
	{
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Ended)) {
			SoundController.PlaySound(soundsGame.btnSound);
			int auxP = PlayerPrefs.GetInt("ptc_gamesPlayed");
			auxP++;
			PlayerPrefs.SetInt("ptc_gamesPlayed", auxP);
			gameC.setCurrentGameState(GameState.PREGAME);
		}
	}

	void Update () {
	
	}
}
