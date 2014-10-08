using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AchievementsController : MonoBehaviour {


	public Sprite[] a;
	public List<GameObject> achievements_icon;
	private string[] achievements; 
	private string achievements_string;
	private GameController gameC;
	public float speed;
	private bool isAni;


	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		updateAchievements();
	}

	void Update () {
		if(isAni){
			if(System.Math.Round(transform.position.x, 1) > 0){
				transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}

	public void close(){
		gameObject.SetActive(false);
		gameC.setCurrentGameState(GameState.START);
	}

	void OnEnable(){
		isAni = true;
		transform.position = new Vector3(12, 0.5f, -7f);
		updateAchievements();
	}

	private void updateAchievements(){
		achievements_string = PlayerPrefs.GetString("ptc_achievements");
		achievements = achievements_string.Split(new Char []{'|'});
		for(int i = 0; i < achievements.Length; i++){
			switch(achievements[i]){
			case "1":{
				achievements_icon[0].GetComponent<SpriteRenderer>().sprite = a[0];
			}break;
			case "2":{
				achievements_icon[1].GetComponent<SpriteRenderer>().sprite = a[1];
			}break;
			case "3":{
				achievements_icon[2].GetComponent<SpriteRenderer>().sprite = a[2];
			}break;
			case "4":{
				achievements_icon[3].GetComponent<SpriteRenderer>().sprite = a[3];
			}break;
			case "5":{
				achievements_icon[4].GetComponent<SpriteRenderer>().sprite = a[4];
			}break;
			case "6":{
				achievements_icon[5].GetComponent<SpriteRenderer>().sprite = a[5];
			}break;
			case "7":{
				achievements_icon[6].GetComponent<SpriteRenderer>().sprite = a[6];
			}break;
			case "8":{
				achievements_icon[7].GetComponent<SpriteRenderer>().sprite = a[7];
			}break;
			case "9":{
				achievements_icon[8].GetComponent<SpriteRenderer>().sprite = a[8];
			}break;
			case "10":{
				achievements_icon[9].GetComponent<SpriteRenderer>().sprite = a[9];
			}break;
			case "11":{
				achievements_icon[10].GetComponent<SpriteRenderer>().sprite = a[10];
			}break;
			case "12":{
				achievements_icon[11].GetComponent<SpriteRenderer>().sprite = a[11];
			}break;
			case "13":{
				achievements_icon[12].GetComponent<SpriteRenderer>().sprite = a[12];
			}break;
			case "14":{
				achievements_icon[13].GetComponent<SpriteRenderer>().sprite = a[13];
			}break;
			case "15":{
				achievements_icon[14].GetComponent<SpriteRenderer>().sprite = a[14];
			}break;
			case "16":{
				achievements_icon[15].GetComponent<SpriteRenderer>().sprite = a[15];
			}break;
			case "17":{
				achievements_icon[16].GetComponent<SpriteRenderer>().sprite = a[16];
			}break;
			case "18":{
				achievements_icon[17].GetComponent<SpriteRenderer>().sprite = a[17];
			}break;
			case "19":{
				achievements_icon[18].GetComponent<SpriteRenderer>().sprite = a[18];
			}break;
			case "20":{
				achievements_icon[19].GetComponent<SpriteRenderer>().sprite = a[19];
			}break;
			case "21":{
				achievements_icon[20].GetComponent<SpriteRenderer>().sprite = a[20];
			}break;
			case "22":{
				achievements_icon[21].GetComponent<SpriteRenderer>().sprite = a[21];
			}break;
			case "23":{
				achievements_icon[22].GetComponent<SpriteRenderer>().sprite = a[22];
			}break;
			case "24":{
				achievements_icon[23].GetComponent<SpriteRenderer>().sprite = a[23];
			}break;
			case "25":{
				achievements_icon[24].GetComponent<SpriteRenderer>().sprite = a[24];
			}break;
				
			}
		}
	}

	
}
