using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RavenSpawn : MonoBehaviour {

	public GameObject birdPrefab;
	public GameObject nyanPrefab;

	public int maxSpawnBirds;
	public int maxSpawnNyans;
	
	public List<GameObject> birds;
	public List<GameObject> nyans;

	public float timeToTryToSpawn;
	private float currentTime;
	private bool isOnAttack = false;
	private float timeToTryToSpawnArm;

	public float timeInAttack;
	public float durationOfAttack;
	private float currentDurationOfAttack = 0f;
	private int nRaven;

	private sceneController sceneC;
	private GameController gameC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		sceneC = FindObjectOfType(typeof(sceneController)) as sceneController;
		timeToTryToSpawnArm = timeToTryToSpawn;
		nRaven = 0;
		currentTime = 0;

		for(int i=0; i<maxSpawnBirds; i++){
			GameObject tempB = Instantiate(birdPrefab) as GameObject;
			birds.Add(tempB);
			tempB.SetActive(false);
		}
		for(int i=0; i<maxSpawnNyans; i++){
			GameObject tempN = Instantiate(nyanPrefab) as GameObject;
			nyans.Add(tempN);
			tempN.SetActive(false);
		}
	}
	
	void Update () {
		currentTime += Time.deltaTime;
		if(currentTime > timeToTryToSpawn){
			System.Random n = new System.Random();
			int rand = n.Next(0,10);
			if(rand <= 3 && !gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			SpawnRaven();

			currentTime = 0f;
		}

		if(isOnAttack){
			currentDurationOfAttack += Time.deltaTime;
			if(currentDurationOfAttack > durationOfAttack){
				timeToTryToSpawn = timeToTryToSpawnArm;
				isOnAttack = false;
				currentDurationOfAttack = 0f;
				sceneC.resetBar();
				// final do atack
			}
		}
	}

	private void SpawnRaven(){

		GameObject tempBird = null;

		float NyanSpawn = Random.Range(1,5);

		if(NyanSpawn <= 2f && !isOnAttack){ // 2/5 chances de vim um nyan
		for(int i=0; i<maxSpawnNyans; i++){
			if(nyans[i].activeSelf == false){
				tempBird = nyans[i];
				break;
			}
		}
		} else {
			for(int i=0; i<maxSpawnBirds; i++){
				if(birds[i].activeSelf == false){
					tempBird = birds[i];
					break;
				}
			}
		}

		
		if(tempBird != null){
			// definir para que lado o passaro ira
			float randbird = Random.Range(0,5);
			int nBird = 0;

			if(randbird >= 0f && randbird <= 1f){ // esquerda caindo
				nBird = 1;
			}
			if(randbird > 1f && randbird <= 2f){ // esqueda subindo
				nBird = 2;
			}
			if(randbird > 2f && randbird <= 3f){ // direita caindo
				nBird = 3;
			}
			if(randbird > 3f && randbird <= 4f){ // direita subindo
				nBird = 4;
			}

			tempBird.SetActive(true);
			tempBird.SendMessage("changeDirection", nBird, SendMessageOptions.RequireReceiver);
		}
	}

	public void setIsOnAttack(){
		timeToTryToSpawn = timeInAttack;
		isOnAttack = true;
	}

	public void setIsOffAttack(){
		currentDurationOfAttack = 0f;
		timeToTryToSpawn = timeToTryToSpawnArm;
		isOnAttack = false;
	}

	public bool getIsOnAttack(){
		return isOnAttack;
	}


	public void isGameOver(){
		for(int i=0; i<maxSpawnNyans; i++){
			if(nyans[i].activeSelf == true){
				nyans[i].SetActive(false);
			}
		}
		for(int i=0; i<maxSpawnBirds; i++){
			if(birds[i].activeSelf == true){
				birds[i].SetActive(false);
			}
		}
	}
	
}
