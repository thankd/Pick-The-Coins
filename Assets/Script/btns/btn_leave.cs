using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_leave : MonoBehaviour {
	

	
	void Start () {

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
			PlayerPrefs.SetInt("ptc_totalCoins", 0);
			PlayerPrefs.SetInt("ScorePTC", 0);
			PlayerPrefs.SetInt("ptc_gamesPlayed", 0);
			PlayerPrefs.SetString("ptc_achievements", "");
			PlayerPrefs.SetInt("ptc_bombsDrown", 0);
			PlayerPrefs.SetInt("ptc_ship1", 0);
			PlayerPrefs.SetInt("ptc_ship2", 0);
			PlayerPrefs.SetInt("ptc_ship3", 0);
			PlayerPrefs.SetInt("ptc_ship4", 0);
			PlayerPrefs.SetInt("ptc_ship5", 0);
			PlayerPrefs.SetInt("ptc_ship6", 0);
			PlayerPrefs.SetInt("ptc_ship7", 0);
			PlayerPrefs.SetInt("ptc_ship8", 0);
			PlayerPrefs.SetInt("ptc_ship9", 0);
		}
	}
	
	void Update () {
		
	}
}