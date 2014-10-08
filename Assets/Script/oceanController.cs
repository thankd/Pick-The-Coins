using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class oceanController : MonoBehaviour {

	private GameController gameC;
	private playerController playerC;
	private AchievementsAnalysisController achievementsC;
	public List<GameObject> waterDrops;
	private sceneController sceneC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
		achievementsC = FindObjectOfType(typeof(AchievementsAnalysisController)) as AchievementsAnalysisController;
		sceneC = FindObjectOfType(typeof(sceneController)) as sceneController;
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "coin"){
			SoundController.PlaySound(soundsGame.loser);
			playerC.changeAnimationShip(false);
			gameC.setCurrentGameState(GameState.GAMEOVER);
		}
		if(coll.gameObject.tag == "bomb"){
			SoundController.PlaySound(soundsGame.bombDrop);
			int auxB = PlayerPrefs.GetInt("ptc_bombsDrown");
			auxB++;
			PlayerPrefs.SetInt("ptc_bombsDrown", auxB);
			showWaterDrop(new Vector3(coll.transform.position.x, -6.7f, 0f));
			coll.gameObject.SetActive(false);
			sceneC.addSpeedToScene();
		}
	}

	public void showWaterDrop(Vector3 pos){
		GameObject tempDrop = null;

		for(int i=0; i<3; i++){
			if(waterDrops[i].activeSelf == false){
				tempDrop = waterDrops[i];
				break;
			}
		}

		if(tempDrop != null){
			tempDrop.transform.position = pos;
			tempDrop.SetActive(true);
		}
	}
}
