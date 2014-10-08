using UnityEngine;
using System;
using System.Collections;

public class ShopContentController : MonoBehaviour {
	public float speed;
	private bool isAni;

	public TextMesh total;
	public TextMesh best;
	public TextMesh total_shadow;
	public TextMesh best_shadow;
	public TextMesh ship_name;
	public TextMesh ship_shadow;
	public GameObject locked;
	public GameObject unlocked;
	private playerController playerC;
	private int actualShip;
	private int isUnlocked;

	public TextMesh msg_score;
	public TextMesh msg_play;
	public TextMesh msg_collect;
	public TextMesh msg_unlockall;
	public TextMesh msg_unlockall2;
	public TextMesh msg_likeFacebook;
	public TextMesh msg_or;
	public TextMesh need_score;
	public TextMesh need_collect;
	public TextMesh need_play;
	public GameObject likeFaceBtn;

	public GameObject left_btn;
	public GameObject right_btn;
	public GameObject select_btn;


	private Vector3 topMsgPosition;
	private Vector3 botMsgPosition;


	private bool likePageOk = false;
	private float currentTime;
	private float time = 5f;

	void Start () {
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
		topMsgPosition = new Vector3(-1.86f, -1.51f, -1.66f);
		botMsgPosition = new Vector3(-3.06f, -3.61f, -1.66f);
	}
	
	void Update () {

		if(likePageOk){
			currentTime += Time.deltaTime;
			if(currentTime>time){
				PlayerPrefs.SetInt("ptc_ship5", 1);
				likePageOk = false;
			}
		}

		if(isAni){
			if(System.Math.Round(transform.position.y, 1) > 0.6f){
				transform.position += new Vector3(0f, -speed, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}

		isLockedOrUnlocked();


		total.text = PlayerPrefs.GetInt("ptc_totalCoins").ToString();
		best.text = PlayerPrefs.GetInt("ScorePTC").ToString();
		total_shadow.text = PlayerPrefs.GetInt("ptc_totalCoins").ToString();
		best_shadow.text = PlayerPrefs.GetInt("ScorePTC").ToString();
	}

	void OnEnable(){
		isAni = true;
		transform.position = new Vector3(0f, 16f, 0f);
		right_btn.SetActive(true);
		left_btn.SetActive(true);
		select_btn.SetActive(true);
		actualShip = PlayerPrefs.GetInt("ptc_UseShip");
		if(actualShip == null)
			actualShip = 1;
		CheckLocked();
		isLockedOrUnlocked();
	}

	void OnDisable(){
		right_btn.SetActive(false);
		left_btn.SetActive(false);
		select_btn.SetActive(false);
	}

	public void changeShip(string dir){
		if(dir.Equals("left")){
			if(actualShip > 0){
				actualShip--;
			} else {
				actualShip = 9;
			}
		} else 
		if(dir.Equals("right")){
			if(actualShip < 9){
				actualShip++;
			} else {
				actualShip = 0;
			}
		}
		isLockedOrUnlocked();
		playerC.ShipsToShopScreen(actualShip);
	}

	private void isLockedOrUnlocked(){

		switch(actualShip){
		case 1:{
			ship_name.text = "     Ship";
			ship_shadow.text = "     Ship";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship1");
			hideTextObjects();
			// pegar 100 moedas
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_collect.transform.position = new Vector3(msg_collect.transform.position.x, topMsgPosition.y ,msg_collect.transform.position.z);
				msg_collect.text = "Collect    Coins";
				need_collect.transform.position = new Vector3(need_collect.transform.position.x, topMsgPosition.y ,need_collect.transform.position.z);
				need_collect.text = "100";
			}


		}break;
		case 2:{
			ship_name.text = "    Caravel";
			ship_shadow.text = "    Caravel";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship2");
			hideTextObjects();
			// score 40 or collect 250
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_score.transform.position = new Vector3(msg_score.transform.position.x, topMsgPosition.y  ,msg_score.transform.position.z);
				msg_score.text = "Score";
				need_score.transform.position = new Vector3(need_score.transform.position.x, topMsgPosition.y ,need_score.transform.position.z);
				need_score.text = "40";
				msg_or.text = "or";
				msg_collect.transform.position = new Vector3(msg_collect.transform.position.x, botMsgPosition.y ,msg_collect.transform.position.z);
				msg_collect.text = "Collect    Coins";
				need_collect.transform.position = new Vector3(need_collect.transform.position.x, botMsgPosition.y ,need_collect.transform.position.z);
				need_collect.text = "250";
			}
		}break;
		case 3:{
			ship_name.text = "    U-Boat";
			ship_shadow.text = "    U-Boat";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship3");
			hideTextObjects();
			// Score 60 or collect 500
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_score.transform.position = new Vector3(msg_score.transform.position.x, topMsgPosition.y ,msg_score.transform.position.z);
				msg_score.text = "Score";
				need_score.transform.position = new Vector3(need_score.transform.position.x, topMsgPosition.y ,need_score.transform.position.z);
				need_score.text = "50";
				msg_or.text = "or";
				msg_collect.transform.position = new Vector3(msg_collect.transform.position.x, botMsgPosition.y ,msg_collect.transform.position.z);
				msg_collect.text = "Collect    Coins";
				need_collect.transform.position = new Vector3(need_collect.transform.position.x, botMsgPosition.y ,need_collect.transform.position.z);
				need_collect.text = "500";
			}
		}break;
		case 4:{
			ship_name.text = "  Motorboat";
			ship_shadow.text = "  Motorboat";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship4");
			hideTextObjects();
			// play 30 games
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_play.transform.position = new Vector3(msg_play.transform.position.x, topMsgPosition.y ,msg_play.transform.position.z);
				msg_play.text = "Play    Games";
				need_play.transform.position = new Vector3(need_play.transform.position.x, topMsgPosition.y ,need_play.transform.position.z);
				need_play.text = "30";
			}
		}break;
		case 5:{
			ship_name.text = "Shark Machine";
			ship_shadow.text = "Shark Machine";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship5");
			hideTextObjects();
			// like facebook
			// play 30 games
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_likeFacebook.text = "Like Facebook Page";
				likeFaceBtn.SetActive(true);
			}
		}break;
		case 6:{
			ship_name.text = "Red Lions King";
			ship_shadow.text = "Red Lions King";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship6");
			hideTextObjects();
			//score 80 or play 80 games
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_score.transform.position = new Vector3(msg_score.transform.position.x, topMsgPosition.y ,msg_score.transform.position.z);
				msg_score.text = "Score";
				need_score.transform.position = new Vector3(need_score.transform.position.x, topMsgPosition.y ,need_score.transform.position.z);
				need_score.text = "60";
				msg_or.text = "or";
				msg_play.transform.position = new Vector3(msg_play.transform.position.x, botMsgPosition.y ,msg_play.transform.position.z);
				msg_play.text = "Play    Games";
				need_play.transform.position = new Vector3(need_play.transform.position.x, botMsgPosition.y ,need_play.transform.position.z);
				need_play.text = "80";
			}
		}break;
		case 7:{
			ship_name.text = "  Black Pearl";
			ship_shadow.text = "  Black Pearl";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship7");
			hideTextObjects();
			// pegar 1000 moedas
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_collect.transform.position = new Vector3(msg_collect.transform.position.x, topMsgPosition.y ,msg_collect.transform.position.z);
				msg_collect.text = "Collect     Coins";
				need_collect.transform.position = new Vector3(need_collect.transform.position.x, topMsgPosition.y ,need_collect.transform.position.z);
				need_collect.text = "1000";
			}
		}break;	    
		case 8:{
			ship_name.text = " Flying Nyan";
			ship_shadow.text = " Flying Nyan";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship8");
			hideTextObjects();
			// score 100
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_score.transform.position = new Vector3(msg_score.transform.position.x, topMsgPosition.y ,msg_score.transform.position.z);
				msg_score.text = "Score";
				need_score.transform.position = new Vector3(need_score.transform.position.x, topMsgPosition.y ,need_score.transform.position.z);
				need_score.text = "80";
			}
		}break;	 
		case 9:{
			ship_name.text = "    Hydra";
			ship_shadow.text = "    Hydra";
			isUnlocked = PlayerPrefs.GetInt("ptc_ship9");
			hideTextObjects();
			// unlock all achievements
			if(isUnlocked.Equals(1)){
				unlocked.SetActive(true);
			} else {
				unlocked.SetActive(false);
				msg_unlockall.text = "Unlock All";
				msg_unlockall2.text = "Achievements";
			}
		}break;	 
		default:
			ship_name.text = "     Boat";
			ship_shadow.text = "     Boat";
			isUnlocked = 1;
			unlocked.SetActive(true);
			hideTextObjects();
			break;
		}


	}

	public void selectShip(){
		if(isUnlocked.Equals(1)){
			playerC.changeShipComplete(actualShip);
			gameObject.SetActive(false);
		}
	}

	private void CheckLocked(){
		// ship
		if(PlayerPrefs.GetInt("ptc_ship1") != 1 && PlayerPrefs.GetInt("ptc_totalCoins") >= 100){
			PlayerPrefs.SetInt("ptc_ship1", 1);
		}
		// ship 2
		if(PlayerPrefs.GetInt("ptc_ship2") != 1 && PlayerPrefs.GetInt("ptc_totalCoins") >= 250 || PlayerPrefs.GetInt("ScorePTC") >= 40){
			PlayerPrefs.SetInt("ptc_ship2", 1);
		}
		// tatical
		if(PlayerPrefs.GetInt("ptc_ship3") != 1 && PlayerPrefs.GetInt("ptc_totalCoins") >= 500 || PlayerPrefs.GetInt("ScorePTC") >= 50){
			PlayerPrefs.SetInt("ptc_ship3", 1);
		}
		// delux
		if(PlayerPrefs.GetInt("ptc_ship4") != 1 && PlayerPrefs.GetInt("ptc_gamesPlayed") >= 30){
			PlayerPrefs.SetInt("ptc_ship4", 1);
		}
		// lions
		if(PlayerPrefs.GetInt("ptc_ship6") != 1 && PlayerPrefs.GetInt("ptc_gamesPlayed") >= 80 || PlayerPrefs.GetInt("ScorePTC") >= 60){
			PlayerPrefs.SetInt("ptc_ship6", 1);
		}
		// black pearl
		if(PlayerPrefs.GetInt("ptc_ship7") != 1 && PlayerPrefs.GetInt("ptc_totalCoins") >= 1000){
			PlayerPrefs.SetInt("ptc_ship7", 1);
		}
		if(PlayerPrefs.GetInt("ptc_ship8") != 1 && PlayerPrefs.GetInt("ScorePTC") >= 80){
			PlayerPrefs.SetInt("ptc_ship8", 1);
		}
		if(PlayerPrefs.GetInt("ptc_ship9") != 1 && UnlockedAllAchievements()){
			PlayerPrefs.SetInt("ptc_ship9", 1);
		}
		if(PlayerPrefs.GetInt("ptc_ship5") != 1 && PlayerPrefs.GetInt("ptc_totalCoins") >= 1000){
			// codigo do facebook
			PlayerPrefs.SetInt("ptc_ship5", 1);
		}

	}

	private void hideTextObjects(){
		msg_score.text = "";
		msg_play.text = "";
		msg_collect.text = "";;
		msg_unlockall.text = "";;
		msg_or.text = "";;
		need_score.text = "";;
		need_collect.text = "";;
		need_play.text = "";;
		msg_unlockall2.text = "";
		msg_likeFacebook.text = "";
		likeFaceBtn.SetActive(false);
	}

	private bool UnlockedAllAchievements(){
		bool r = false;
		string achievements_string = PlayerPrefs.GetString("ptc_achievements");
		string[] achievements = achievements_string.Split(new Char []{'|'});
		for(int i = 0; i < achievements.Length; i++){
			if(achievements[i].Equals("25")){
				r = true;
				break;
			}
		}
		return r;
	}

	public void btnLikePage(){
		likePageOk = true;
	}
}
