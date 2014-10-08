using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tree_Spawn : MonoBehaviour {
	
	public GameObject tPrefab;
	
	public float timeToTryToSpawn;
	private float currentTimeSpawn;
	private bool SpawnNow;
	
	
	public int countTrees;
	
	public List<GameObject> trees;
	
	private GameController gameC;
	
	
	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		for(int i=0; i<countTrees; i++){
			GameObject tempM = Instantiate(tPrefab) as GameObject;
			trees.Add(tempM);
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
		float randYScale = Random.Range(-5.4f, -5.6f);
		 

		for(int i=0; i<countTrees; i++){
			if(trees[i].activeSelf == false){
				tempM = trees[i];
				break;
			}
		}
		
		if(tempM != null){
			tempM.transform.position = new Vector3(8f, randYScale, tempM.transform.position.z);
			tempM.SetActive(true);
		}
		
	}
	
}
