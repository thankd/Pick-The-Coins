using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_restart : MonoBehaviour {
	
	private GameController gameC;
	private SceneFadeInOut fade;
	
	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		fade = FindObjectOfType(typeof(SceneFadeInOut)) as SceneFadeInOut;
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
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Began)) {
			if(gameC.getCurrentGameState() == GameState.GAMEOVER && gameC.getGameOverAgain()){
				SoundController.PlaySound(soundsGame.btnSound);
				gameC.setGameOverAgain(false);
				int auxP = PlayerPrefs.GetInt("ptc_gamesPlayed");
				auxP++;
				PlayerPrefs.SetInt("ptc_gamesPlayed", auxP);
				fade.StartFade();
			}
		}
	}
	
	void Update () {
		
	}
}