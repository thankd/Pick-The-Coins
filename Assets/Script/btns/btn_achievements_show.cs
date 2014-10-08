using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_achievements_show : MonoBehaviour {

	public string id;
	private GameController gameC;
	private AchievementsTopList topC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		topC = FindObjectOfType(typeof(AchievementsTopList)) as AchievementsTopList;
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
			SoundController.PlaySound(soundsGame.btnSound);
				topC.setId_Show(id);
		}
	}

}