using UnityEngine;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_achievements_leave : MonoBehaviour {

	private AchievementsController achievementsC;
	
	void Start () {
		achievementsC = FindObjectOfType(typeof(AchievementsController)) as AchievementsController;
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
			achievementsC.close();
		}
	}
	
	void Update () {
		
	}
}
