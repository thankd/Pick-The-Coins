using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sceneController : MonoBehaviour {

	private int nivelBar;

	public float objectSpeed;
	private float arm_objectSpeed;
	public float addSpeedVariant;

	public int maxSpawnCoins;
	public int maxSpawnBombs;

	public float maxHeight;
	public float minHeight;
	public float rateSpawn;
	private float rateSpawnArm;

	private float currentRateSpawn;

	public List<GameObject> coins;
	public List<GameObject> bombs;

	private float requiredXPos;

	private GameController gameC;
	private RavenSpawn RavenSpawnC;

	private int actualLevel;
	public Sprite[] barForces;
	public Sprite[] barForcesBlink;
	public GameObject bar_force;
	public GameObject bar_force_blink;
	private Vector3 startPositionBar;
	private Vector3 startPositionBarBlink;
	private Vector3 startScale;

	public float timeBlink;
	private float currentTimeBlink;
	private bool blinkNow = false;

	public GameObject BirdAttackInfo;

	private bool showLevelInfo;
	public float timeToShowLevel;
	private float currentTimeToShowLevel;
	public TextMesh levelMesh;
	public TextMesh levelMeshShadow;

	void Start () {
		showLevelInfo = false;
		actualLevel = 0;
		currentRateSpawn = rateSpawn;
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		RavenSpawnC = FindObjectOfType(typeof(RavenSpawn)) as RavenSpawn;
		nivelBar = 0;
		startPositionBar = bar_force.transform.position;
		startPositionBarBlink = bar_force_blink.transform.position;
		startScale = bar_force.transform.localScale;
		arm_objectSpeed = objectSpeed;
		rateSpawnArm = rateSpawn;
	}
	

	void Update () {

		if(showLevelInfo){
			levelMesh.text = "Level " + getLevel().ToString();
			levelMeshShadow.text = "Level " + getLevel().ToString();
			currentTimeToShowLevel += Time.deltaTime;
			if(currentTimeToShowLevel > timeToShowLevel){
				levelMesh.text = "";
				levelMeshShadow.text = "";
				showLevelInfo = false;
				currentTimeToShowLevel = 0f;
			}
		}

		if(blinkNow){
			currentTimeBlink += Time.deltaTime;
			if(currentTimeBlink > timeBlink){
				blinkNow = false;
				currentTimeBlink = 0f;
				bar_force_blink.SetActive(false);
			}
		}

		if(gameC.getCurrentGameState().Equals(GameState.START)
		|| gameC.getCurrentGameState().Equals(GameState.TUTORIAL)
		|| gameC.getCurrentGameState().Equals(GameState.PREGAME)
		|| gameC.getCurrentGameState().Equals(GameState.GAMEOVER)
		|| gameC.getCurrentGameState().Equals(GameState.SHOP)
		|| gameC.getCurrentGameState().Equals(GameState.ACHIEVES))
			return;

		currentRateSpawn += Time.deltaTime;
		if(currentRateSpawn > rateSpawn){
			currentRateSpawn = 0;
			Spawn();
		}

	}

	private void Spawn(){
		float randHeightX = Random.Range(minHeight, maxHeight);
		float randHeightY = Random.Range(7, 8);
		System.Random s = new System.Random();
		int bombSpawn = s.Next(1,5);
		bool isBomb = false;

		if(bombSpawn == 1){
			isBomb = true;
		}

		GameObject tempCoin = null;

		if(isBomb){
			for(int i=0; i<maxSpawnBombs; i++){
				if(bombs[i].activeSelf == false){
					tempCoin = bombs[i];
					break;
				}
			}

		} else {
		for(int i=0; i<maxSpawnCoins; i++){
			if(coins[i].activeSelf == false){
				tempCoin = coins[i];
				break;
				}
			}
		}
		
		if(tempCoin != null){
			tempCoin.transform.position = new Vector3(randHeightX, randHeightY, transform.position.z);
			tempCoin.SetActive(true);
		}
		
	}
	
	public void restart(){
		for(int i=0; i<maxSpawnCoins; i++){
			if(coins[i].activeSelf == true){
				coins[i].SetActive(false);
				coins[i].transform.position = new Vector3(0f, 11f, 0f);
			}
		}
		for(int i=0; i<maxSpawnBombs; i++){
			if(bombs[i].activeSelf == true){
				bombs[i].SetActive(false);
				bombs[i].transform.position = new Vector3(0f, 11f, 0f);
			}
		}
		RavenSpawnC.setIsOffAttack();
		actualLevel = 0;
		rateSpawn = rateSpawnArm;
		objectSpeed = arm_objectSpeed;
		bar_force.transform.position = startPositionBar;
		bar_force.transform.localScale = startScale;
		bar_force_blink.transform.position = startPositionBarBlink;
		bar_force_blink.transform.localScale = startScale;
	}

	public float getObejctSpeed(){
		return objectSpeed;
	}

	public void addSpeedToScene(){
	

		bar_force.GetComponent<SpriteRenderer>().sprite = barForces[actualLevel];
		bar_force_blink.GetComponent<SpriteRenderer>().sprite = barForcesBlink[actualLevel];

		if(RavenSpawnC.getIsOnAttack()){ // apenas blink se tiver em atack
			bar_force_blink.SetActive(true);
			blinkNow = true;
		} else {

		if(bar_force.transform.localScale.x < 10f){
			nivelBar++;
			addForceInBar();
		} else { 

			RavenSpawnC.setIsOnAttack();
			BirdAttackInfo.SetActive(true);

			}
		
		}
		if(objectSpeed < 20f)
		objectSpeed += addSpeedVariant;
	}

	public void resetBar(){
		showLevelInfo = true; // mostra o level atual

		if(rateSpawn > 0.4f){
			rateSpawn -= 0.1f;
		}

		if(actualLevel < 4)
			actualLevel += 1;
		bar_force.transform.position = startPositionBar;
		bar_force.transform.localScale = startScale;
		bar_force_blink.transform.position = startPositionBarBlink;
		bar_force_blink.transform.localScale = startScale;
	}

	private void addForceInBar(){
		bar_force_blink.SetActive(true);
		blinkNow = true;

		bar_force.transform.localScale += new Vector3(0.01f, 0f, 0f) * 100;
		bar_force.transform.position += new Vector3(0.005f, 0f, 0f) * 100;
		bar_force_blink.transform.localScale += new Vector3(0.01f, 0f, 0f) * 100;
		bar_force_blink.transform.position += new Vector3(0.005f, 0f, 0f) * 100;
	}

	private int getLevel(){
		return actualLevel + 1;
	}

	public void setLevel(){
		actualLevel = 0;
	}


}
