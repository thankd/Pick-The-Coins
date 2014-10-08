using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AchievementsAnalysisController : MonoBehaviour {

	private string[] achievements; 
	private string achievements_string;
	private int[] flowToShow;
	public float speed;
	public GameObject contentAchievement;
	public Sprite[] achieve;
	private playerController playerC;

	void Start () {
		//flowToShow[0] = 0;
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
	}

	void Update () {


	}

	public void Analysis(){
		int scorePTC = playerC.getScore();
		achievements_string = PlayerPrefs.GetString("ptc_achievements");
		achievements = achievements_string.Split(new Char []{'|'});

		if(!exists("1")){
			if(scorePTC >= 10){
				contentAchievement.SendMessage("addOnFlow", 1, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "1|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("2")){
			if(scorePTC >= 20){
				contentAchievement.SendMessage("addOnFlow", 2, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "2|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("3")){
			if(scorePTC >= 30){
				contentAchievement.SendMessage("addOnFlow", 3, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "3|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("4")){
			if(scorePTC >= 40){
				contentAchievement.SendMessage("addOnFlow", 4, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "4|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("5")){
			if(scorePTC >= 50){
				contentAchievement.SendMessage("addOnFlow", 5, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "5|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("6")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 50){
				contentAchievement.SendMessage("addOnFlow", 6, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "6|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("7")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 200){
				contentAchievement.SendMessage("addOnFlow", 7, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "7|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("8")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 350){
				contentAchievement.SendMessage("addOnFlow", 8, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "8|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("9")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 500){
				contentAchievement.SendMessage("addOnFlow", 9, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "9|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("10")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 700){
				contentAchievement.SendMessage("addOnFlow", 10, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "10|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("11")){
			if(PlayerPrefs.GetInt("ptc_totalCoins") >= 1000){
				contentAchievement.SendMessage("addOnFlow", 11, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "11|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("12")){
			if(qtd_ships() >= 2){
				contentAchievement.SendMessage("addOnFlow", 12, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "12|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("13")){
			if(qtd_ships() >= 4){
				contentAchievement.SendMessage("addOnFlow", 13, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "13|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("14")){
			if(qtd_ships() >= 8){
				contentAchievement.SendMessage("addOnFlow", 14, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "14|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("15")){
			if(PlayerPrefs.GetInt("ptc_bombsDrown") >= 10){
				contentAchievement.SendMessage("addOnFlow", 15, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "15|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("16")){
			if(PlayerPrefs.GetInt("ptc_bombsDrown") >= 30){
				contentAchievement.SendMessage("addOnFlow", 16, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "16|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("17")){
			if(PlayerPrefs.GetInt("ptc_bombsDrown") >= 70){
				contentAchievement.SendMessage("addOnFlow", 17, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "17|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("18")){
			if(PlayerPrefs.GetInt("ptc_bombsDrown") >= 120){
				contentAchievement.SendMessage("addOnFlow", 18, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "18|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("19")){
			if(PlayerPrefs.GetInt("ptc_bombsDrown") >= 200){
				contentAchievement.SendMessage("addOnFlow", 19, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "19|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("20")){
			if(PlayerPrefs.GetInt("ptc_gamesPlayed") >= 5){
				contentAchievement.SendMessage("addOnFlow", 20, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "20|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("21")){
			if(PlayerPrefs.GetInt("ptc_gamesPlayed") >= 15){
				contentAchievement.SendMessage("addOnFlow", 21, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "21|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("22")){
			if(PlayerPrefs.GetInt("ptc_gamesPlayed") >= 40){
				contentAchievement.SendMessage("addOnFlow", 22, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "22|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("23")){
			if(PlayerPrefs.GetInt("ptc_gamesPlayed") >= 70){
				contentAchievement.SendMessage("addOnFlow", 23, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "23|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("24")){
			if(PlayerPrefs.GetInt("ptc_gamesPlayed") >= 120){
				contentAchievement.SendMessage("addOnFlow", 24, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "24|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}
		if(!exists("25")){
			if(qtd_Achievements() >= 24){
				contentAchievement.SendMessage("addOnFlow", 25, SendMessageOptions.RequireReceiver);
				string aux = PlayerPrefs.GetString("ptc_achievements");
				aux += "25|";
				PlayerPrefs.SetString("ptc_achievements", aux);
			}
		}




	}

	public bool exists(string id){
		bool r = false;
		for(int i = 0; i < achievements.Length; i++){
			if(achievements[i].Equals(id)){
				r = true;
				break;
			}
		}
		return r;
	}

	private int qtd_ships(){
		int r = 1;
		if(PlayerPrefs.GetInt("ptc_ship1").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship2").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship3").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship4").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship5").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship6").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship7").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship8").Equals(1))
			r++;
		if(PlayerPrefs.GetInt("ptc_ship9").Equals(1))
			r++;
		return r;
	}

	private int qtd_Achievements(){
		int r;
		string aux_string = PlayerPrefs.GetString("ptc_achievements");
		string[] aux_v = aux_string.Split(new Char []{'|'});
		r = aux_v.Length+1;
		return r;
	}

}
