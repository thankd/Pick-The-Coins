using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WorldsState{
	DAY,
	FALL,
	WATERFALL,
	SUMMER,
	NIGHT,
}

public class scenarioController : MonoBehaviour {

	public WorldsState currentWorld;
	public GameObject mountains;
	public GameObject clouds;
	public GameObject background;
	public GameObject sun;
	public GameObject moon;
	public GameObject fall_floor;
	public GameObject summer_floor;
	public GameObject waterfall1;
	public GameObject waterfall2;
	public GameObject stars;
	public GameObject stars2;
	public Sprite[] backgrounds;

	// trees control
	public GameObject tPrefab;
	public float timeToTryToSpawn;
	public int countTrees;
	public List<GameObject> trees;
	public Sprite[] trees_fall;
	public Sprite[] trees_summer;
	private float currentTimeSpawn;
	private bool SpawnNow;
	private GameController gameC;

	private bool spawnTrees;

	void Start () {
		// trees
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		spawnTrees = false;
		for(int i=0; i<countTrees; i++){
			GameObject tempM = Instantiate(tPrefab) as GameObject;
			trees.Add(tempM);
			tempM.SetActive(false);
		}
		//

		currentWorld = WorldsState.DAY;
	}
	
	void Update () {
		// trees

		if(spawnTrees){
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
		// -----
	}

	private void tryToSpawn(){
		if(SpawnNow){
			SpawnNow = false;
			Spawn();
		}
	}
	
	private void Spawn(){
		GameObject tempM = null;
		float randYScale = Random.Range(-5.5f, -5.7f);
		for(int i=0; i<countTrees; i++){
			if(trees[i].activeSelf == false){
				tempM = trees[i];
				break;
			}
		}
		if(tempM != null){
			if(currentWorld.Equals(WorldsState.SUMMER)){
				System.Random n = new System.Random();
				int idToChange = n.Next(0,6);
				tempM.GetComponent<SpriteRenderer>().sprite = trees_summer[idToChange];
			} else 
			if(currentWorld.Equals(WorldsState.FALL)){
				System.Random n = new System.Random();
				int idToChange = n.Next(0,6);
				tempM.GetComponent<SpriteRenderer>().sprite = trees_fall[idToChange];
			}
			tempM.transform.position = new Vector3(8f, randYScale, tempM.transform.position.z);
			tempM.SetActive(true);
		}
	}

	private void ChangeTreesAreUp(){
		if(currentWorld.Equals(WorldsState.SUMMER)){
			for(int i=0; i<countTrees; i++){
				if(trees[i].activeSelf == true){
					System.Random n = new System.Random();
					int idToChange = n.Next(0,6);
					trees[i].GetComponent<SpriteRenderer>().sprite = trees_summer[idToChange];
				}
			}
		} else
		if(currentWorld.Equals(WorldsState.FALL)){
			for(int i=0; i<countTrees; i++){
				if(trees[i].activeSelf == true){
					System.Random n = new System.Random();
					int idToChange = n.Next(0,5);
					trees[i].GetComponent<SpriteRenderer>().sprite = trees_fall[idToChange];
				}
			}
		}
	}

	private void changeFloor(string arg){
		fall_floor.SetActive(false);
		summer_floor.SetActive(false);
		if(arg=="fall"){
			fall_floor.SetActive(true);
		} else
		if(arg=="summer"){
			summer_floor.SetActive(true);
		}
	}

	private void SpawnTrees(){
		spawnTrees = true;
	}

	private void DontSpawnTrees(){
		spawnTrees = false;
	}

	private void clearTrees(){
		for(int i=0; i<countTrees; i++){
			if(trees[i].activeSelf == true){
				trees[i].SetActive(false);
			}
		}
	}

	private void changeBackground(int id){
		background.SetActive(true);
		background.GetComponent<SpriteRenderer>().sprite = backgrounds[id];
	}

	private void changeWorld(){
		switch(currentWorld){
		case WorldsState.DAY:{
			changeBackground(0);
			mountains.SetActive(true);
			clouds.SetActive(true);
			sun.SetActive(true);
			changeFloor("none");
			DontSpawnTrees();
			clearTrees();
			moon.SetActive(false);
			stopStars();
			stopWaterfall();

		}break;
		case WorldsState.FALL:{
			changeBackground(1);
			mountains.SetActive(true);
			clouds.SetActive(true);
			sun.SetActive(true);
			SpawnTrees();
			ChangeTreesAreUp();
			changeFloor("fall");
			moon.SetActive(false);
			stopStars();
			stopWaterfall();
		}break;
		case WorldsState.WATERFALL:{
			sun.SetActive(false);
			clouds.SetActive(false);
			changeBackground(2);
			mountains.SetActive(true);
			DontSpawnTrees();
			clearTrees();
			changeFloor("none");
			startWaterfall();
			moon.SetActive(false);
			stopStars();
		}break;
		case WorldsState.SUMMER:{
			sun.SetActive(true);
			changeBackground(3);
			mountains.SetActive(true);
			clouds.SetActive(true);
			SpawnTrees();
			ChangeTreesAreUp();
			changeFloor("summer");
			moon.SetActive(false);
			stopStars();
			stopWaterfall();
		}break;
		case WorldsState.NIGHT:{
			sun.SetActive(false);
			mountains.SetActive(true);
			clouds.SetActive(false);
			DontSpawnTrees();
			clearTrees();
			changeFloor("none");
			changeBackground(4);
			moon.SetActive(true);
			startStars();
			stopWaterfall();
		}break;
		}
	}

	public WorldsState getCurrentWorld(){
		return currentWorld;
	}

	public void setCurrentWorld(WorldsState w){
		currentWorld = w;
	}

	private void startWaterfall(){
		waterfall2.SetActive(true);
		waterfall1.SetActive(true);
		waterfall1.SendMessage("startWaterfall", SendMessageOptions.RequireReceiver);
	}

	private void stopWaterfall(){
		if(waterfall1.activeSelf){
			waterfall1.SendMessage("stopWaterfall", SendMessageOptions.RequireReceiver);
			waterfall1.SetActive(false);
			waterfall2.SetActive(false);
		}
	}

	private void startStars(){
		stars2.SetActive(true);
		stars.SetActive(true);
		stars.SendMessage("startStars", SendMessageOptions.RequireReceiver);
	}

	private void stopStars(){
		if(stars.activeSelf){
			stars.SendMessage("stopStars", SendMessageOptions.RequireReceiver);
			stars.SetActive(false);
			stars2.SetActive(false);
		}
	}

	public void randomWorld(){
		System.Random n = new System.Random();
		int idWorld = n.Next(0,5);
		WorldsState worldS;
		switch(idWorld){
		case 0:{
			setCurrentWorld(WorldsState.DAY);
		}break;
		case 1:{
			setCurrentWorld(WorldsState.FALL);
		}break;
		case 2:{
			setCurrentWorld(WorldsState.WATERFALL);
		}break;
		case 3:{
			setCurrentWorld(WorldsState.SUMMER);
		}break;
		case 4:{
			setCurrentWorld(WorldsState.NIGHT);
		}break;
		}
		changeWorld();
	}



	
}
