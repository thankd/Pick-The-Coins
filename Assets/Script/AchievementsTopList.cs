using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AchievementsTopList : MonoBehaviour {

	public Sprite[] achieve;
	public Sprite[] achieve_complete;
	public float speed;
	private AchievementsAnalysisController achievementsC;
	private GameController gameC;
	private string id;
	private bool isAni;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
		isAni = false;
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		achievementsC = FindObjectOfType(typeof(AchievementsAnalysisController)) as AchievementsAnalysisController;
	}
	
	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.START) && GetComponent<SpriteRenderer>().sprite != null){
			GetComponent<SpriteRenderer>().sprite = null;
		}
		Anime();
	}

	public void setContent(){
		switch(id){
		case "1":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[0];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[0];
		}break;
		case "2":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[1];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[1];
		}break;
		case "3":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[2];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[2];
		}break;
		case "4":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[3];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[3];
		}break;
		case "5":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[4];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[4];
		}break;
		case "6":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[5];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[5];
		}break;
		case "7":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[6];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[6];
		}break;
		case "8":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[7];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[7];
		}break;
		case "9":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[8];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[8];
		}break;
		case "10":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[9];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[9];
		}break;
		case "11":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[10];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[10];
		}break;
		case "12":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[11];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[11];
		}break;
		case "13":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[12];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[12];
		}break;
		case "14":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[13];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[13];
		}break;
		case "15":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[14];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[14];
		}break;
		case "16":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[15];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[15];
		}break;
		case "17":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[16];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[16];
		}break;
		case "18":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[17];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[17];
		}break;
		case "19":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[18];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[18];
		}break;
		case "20":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[19];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[19];
		}break;
		case "21":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[20];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[20];
		}break;
		case "22":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[21];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[21];
		}break;
		case "23":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[22];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[22];
		}break;
		case "24":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[23];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[23];
		}break;
		case "25":{
			if(!exists(id))
				GetComponent<SpriteRenderer>().sprite = achieve[24];
			else
				GetComponent<SpriteRenderer>().sprite = achieve_complete[24];
		}break;
			
		}
	}

	private void Anime(){
		if(isAni){
			if(Math.Round(transform.position.x, 1) < 0){
				transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}

	public void setId_Show(string arg){
		id = arg;
		setContent();
		transform.position = startPosition;
		isAni = true;
	}

	public bool exists(string id){
		bool r = false;
		string achievements_string = PlayerPrefs.GetString("ptc_achievements");
		string[] achievements = achievements_string.Split(new Char []{'|'});
		for(int i = 0; i < achievements.Length; i++){
			if(achievements[i].Equals(id)){
				r = true;
				break;
			}
		}
		return r;
	}
}
