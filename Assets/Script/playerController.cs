using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

	public float sceneSpeedToAdd;
	private int score;
	private GameController gameC;
	public TextMesh scoreMesh;
	public TextMesh scoreMeshShadow;
	public GameObject expo;
	private bool isAni;
	private sceneController sceneC;

	public float maxXmoney;
	public float minXmoney;
	public GameObject moneyPrefab;
	public int maxQtdMoney;

	public List<GameObject> ships;

	public List<GameObject> moneys;

	public GameObject nyanCoin;
	public GameObject birdCoin;

	private int UseShip;

	void Start () {
		isAni = true;
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		sceneC = FindObjectOfType(typeof(sceneController)) as sceneController;

		for(int i=0; i<maxQtdMoney; i++){
			GameObject tempM = Instantiate(moneyPrefab) as GameObject;
			moneys.Add(tempM);
			tempM.SetActive(false);
		}

		UseShip = PlayerPrefs.GetInt("ptc_UseShip");
		clearShipAndUse();
	}

	void Update () {
		scoreMesh.text = score.ToString();
		scoreMeshShadow.text = score.ToString();
	}

	public void ColliderOn(string type){
		if(type == "coin"){
			SpawnOneMoney();
			SoundController.PlaySound(soundsGame.coin);
			addScore();
			sceneC.addSpeedToScene();
		}
		
		if(type == "bomb"){
			changeAnimationShip(false);
			SoundController.PlaySound(soundsGame.shipExplosion);
			gameC.setCurrentGameState(GameState.GAMEOVER);
			expo.SetActive(true);
		}
	}

	private void SpawnOneMoney(){
		float randX = Random.Range(minXmoney, maxXmoney);
		
		GameObject tempMoney = null;
		
		for(int i=0; i<maxQtdMoney; i++){
			if(moneys[i].activeSelf == false){
				tempMoney = moneys[i];
				break;
			}
		}
		
		if(tempMoney != null){
			tempMoney.transform.position = new Vector3(randX, transform.position.y, transform.position.z);
			tempMoney.SetActive(true);
		}
	}

	private void addScore(){
		score++;
		int aux_total =	PlayerPrefs.GetInt("ptc_totalCoins");
		aux_total++;
		PlayerPrefs.SetInt("ptc_totalCoins",aux_total);
	}
	
	public int getScore(){
		return score;
	}

	public void restart(){
		score = 0;
		changeAnimationShip(true);
		expo.SetActive(false);
	}

	private void clearShipAndUse(){
		for(int i = 0; i < ships.Count; i++){
			ships[i].SetActive(false);
		}
		if(UseShip.Equals(1)){
			ships[1].SetActive(true);
		} else
		if(UseShip.Equals(2)){
			ships[2].SetActive(true);
		} else
		if(UseShip.Equals(3)){
			ships[3].SetActive(true);
		} else
		if(UseShip.Equals(4)){
			ships[4].SetActive(true);
		} else
		if(UseShip.Equals(5)){
			ships[5].SetActive(true);
		} else
		if(UseShip.Equals(6)){
			ships[6].SetActive(true);
		} else
		if(UseShip.Equals(7)){
			ships[7].SetActive(true);
		} else
		if(UseShip.Equals(8)){
			ships[8].SetActive(true);
		}else
		if(UseShip.Equals(9)){
			ships[9].SetActive(true);
		} else {
			ships[0].SetActive(true);
		}
	}

	public void changeShipComplete(int shipID){
		PlayerPrefs.SetInt("ptc_UseShip", shipID);
		UseShip = shipID;
		clearShipAndUse();
		gameC.setCurrentGameState(GameState.START);
	}

	public void ShipsToShopScreen(int shipNow){
		UseShip = shipNow;
		clearShipAndUse();
	}

	public int getUseShip(){
		return UseShip;
	}

	public void changeAnimationShip(bool arg){
		Animator animatorShip = ships[UseShip].GetComponentInChildren<Animator>();
		animatorShip.SetBool("ship_Ani", arg);
	}

	public void NyanPickedCoin(){
		nyanCoin.SetActive(true);
		score += 2;
		int aux_total =	PlayerPrefs.GetInt("ptc_totalCoins");
		aux_total+=2;
		PlayerPrefs.SetInt("ptc_totalCoins",aux_total);
	}

	public void BirdPickedCoin(){
		if(score > 0){
		birdCoin.SetActive(true);
		score -= 1;
		int aux_total =	PlayerPrefs.GetInt("ptc_totalCoins");
		aux_total-=1;
		PlayerPrefs.SetInt("ptc_totalCoins",aux_total);
		}
	}
}
