using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mountainSpawn : MonoBehaviour {
	
	public GameObject mPrefab;
	
	public float timeToTryToSpawn;
	private float currentTimeSpawn;
	private bool SpawnNow;


	public int countMountains;
	
	public List<GameObject> mountains;
	
	private GameController gameC;


	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		for(int i=0; i<countMountains; i++){
			GameObject tempM = Instantiate(mPrefab) as GameObject;
			mountains.Add(tempM);
			tempM.SetActive(false);
		}
	}
	
	void Update () {

		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			return;

		currentTimeSpawn += Time.deltaTime;
		if(currentTimeSpawn>timeToTryToSpawn){
			currentTimeSpawn = 0;
			System.Random sort = new System.Random();
			int n = sort.Next(1,3);
			if(n.Equals(1)){ // spawn
				SpawnNow = true;
			}
		}

		tryToSpawn();


	}

	private void tryToSpawn(){
		if(SpawnNow){
			SpawnNow = false;
			Spawn();
		}
	}

	private void Spawn(){

		GameObject tempM = null;
		
		for(int i=0; i<countMountains; i++){
			if(mountains[i].activeSelf == false){
				tempM = mountains[i];
				break;
			}
		}
		
		if(tempM != null){
			tempM.transform.position = new Vector3(12f, -7.2f, tempM.transform.position.z);
			tempM.SetActive(true);
		}

	}
	
}
