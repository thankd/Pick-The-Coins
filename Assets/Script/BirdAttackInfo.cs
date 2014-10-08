using UnityEngine;
using System.Collections;

public class BirdAttackInfo : MonoBehaviour {

	public float timeToShow;
	private float currentTime;
	private bool isOn = false;
	private GameController gameC;

	void OnEnable(){
		SoundController.PlaySound(soundsGame.birdAttack);
		isOn = true;
		currentTime = 0f;
	}

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
	}

	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER)){
			isOn = false;
			gameObject.SetActive(false);
		}

		if(isOn){
			currentTime += Time.deltaTime;
			if(currentTime > timeToShow){
				isOn = false;
				gameObject.SetActive(false);
			}
		}
	}
}
