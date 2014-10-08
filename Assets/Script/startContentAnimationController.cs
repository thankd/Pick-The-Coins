using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class startContentAnimationController : MonoBehaviour {

	public float speed;
	private bool isAni;

	public float maxHeight;
	public float minHeight;
	
	public float rateSpawn;
	private float currentRateSpawn;
	
	public GameObject coinPrefab;
	
	
	public int maxSpawnCoins;
	
	public List<GameObject> coins;

	void Start () {
		for(int i=0; i<maxSpawnCoins; i++){
			GameObject tempCoin = Instantiate(coinPrefab) as GameObject;
			coins.Add(tempCoin);
			tempCoin.SetActive(false);
		}
		currentRateSpawn = rateSpawn;
	}


	void Update () {
		currentRateSpawn += Time.deltaTime;
		if(currentRateSpawn > rateSpawn){
			currentRateSpawn = 0;
			Spawn();
		}


		if(isAni){
			if(System.Math.Round(transform.position.x, 1) < -0.1f){
				transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}


	void OnDisable(){
		for(int i=0; i<maxSpawnCoins; i++){
			if(coins[i].activeSelf == true){
				coins[i].SetActive(false);
			}
		}
	}


	private void Spawn(){
		float randHeight = Random.Range(minHeight, maxHeight);
		float randY = Random.Range(6, 8);
		GameObject tempCoin = null;
		
		for(int i=0; i<maxSpawnCoins; i++){
			if(coins[i].activeSelf == false){
				tempCoin = coins[i];
				break;
			}
		}
		
		if(tempCoin != null){
			tempCoin.transform.position = new Vector3(randHeight, randY, 5f);
			tempCoin.SetActive(true);
		}
		
	}

	void OnEnable(){
		isAni = true;
		transform.position = new Vector3(-13f, 0f, 0);
	}

}
