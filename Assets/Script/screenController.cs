using UnityEngine;
using System;
using TouchScript.Gestures;

public class screenController : MonoBehaviour {
	
	private Vector2 posTouchI;
	private Vector2 posTouch;
	private string posToMove;

	void Start(){
		posToMove = "";
	}

	private void OnEnable()
	{
		GetComponent<MetaGesture>().StateChanged += metaHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<MetaGesture>().StateChanged -= metaHandler;
	}
	
	private void metaHandler(object sender, EventArgs e)
	{
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Began)) {
			posTouchI = Camera.main.ScreenToWorldPoint(GetComponent<MetaGesture>().ScreenPosition);
		} 
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Changed)) {
			posTouch = Camera.main.ScreenToWorldPoint(GetComponent<MetaGesture>().ScreenPosition);
			if(posTouchI.x < posTouch.x){// direita
				posToMove = "dir";
			} else
			if(posTouchI.x > posTouch.x){// direita
				posToMove = "esq";
			} else
			if(posTouchI.x == posTouch.x){// direita
				posToMove = "none";
			}
		}

		/* if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Ended)) {
			posTouchI = Camera.main.ScreenToWorldPoint(GetComponent<MetaGesture>().ScreenPosition);
			if(Math.Round (posTouchI.x, 1) >= 4f){
				if(posToMove.Equals("esq") && gameC.getCurrentGameState().Equals(GameState.INGAME))
					SoundController.PlaySound(soundsGame.changeSide);
				posToMove = "dir";
			} 
			else if(Math.Round (posTouchI.x, 1) <= -2f){
				if(posToMove.Equals("dir") && gameC.getCurrentGameState().Equals(GameState.INGAME))
					SoundController.PlaySound(soundsGame.changeSide);
				posToMove = "esq";
			}
			else
			{

				posToMove = "dir";
			}
		} */ 
	}
	
	public string posToM(){
		return (posToMove);
	}
}
