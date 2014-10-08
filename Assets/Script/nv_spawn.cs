using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nv_spawn : MonoBehaviour {

	public float maxY;
	public float minY;
	public float maxX;
	public float minX;
	
	public GameObject nvPrefab;

	public float rateSpawn;
	private float currentRateSpawn;

	public int maxSpawnNv;
	
	public List<GameObject> nvs;

	private GameController gameC;

	private Animator animatorSun;
	public Transform meshSun;
	private bool sunAni;

	void Start () {
		sunAni = true;
		animatorSun = meshSun.GetComponent<Animator>();
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		for(int i=0; i<maxSpawnNv; i++){
			GameObject tempNv = Instantiate(nvPrefab) as GameObject;
			nvs.Add(tempNv);
			tempNv.SetActive(false);
		}
		currentRateSpawn = rateSpawn;
	}
	

	void Update () {

		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			sunAni = false;
		else 
			sunAni = true;

		animatorSun.SetBool("sunAnimation", sunAni);

		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			return;

		currentRateSpawn += Time.deltaTime;
		if(currentRateSpawn > rateSpawn){
			currentRateSpawn = 0;
			Spawn();
		}
	}


	private void Spawn(){
		float randX = Random.Range(minX, maxX);
		float randY = Random.Range(minY, maxY);

		GameObject tempNV = null;
		
		for(int i=0; i<maxSpawnNv; i++){
			if(nvs[i].activeSelf == false){
				tempNV = nvs[i];
				break;
			}
		}
		
		if(tempNV != null){
			tempNV.transform.position = new Vector3(randX, randY, transform.position.z);
			tempNV.SetActive(true);
		}
		
	}

	void OnDisable(){
		for(int i=0; i<maxSpawnNv; i++){
			if(nvs[i].activeSelf){
				nvs[i].SetActive(false);
			}
		}
	}



}
