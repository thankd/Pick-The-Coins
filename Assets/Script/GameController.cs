using UnityEngine;
using System;
using GoogleMobileAds.Api;

public enum GameState{
	START,
	TUTORIAL,
	PREGAME,
	INGAME,
	GAMEOVER,
	SHOP,
	ACHIEVES,
}

public class GameController : MonoBehaviour {
	public float speed;
	public GameObject gameOverContent;
	public GameObject startContent;
	public GameObject score;
	public GameObject Scene;
	public GameObject Player;
	public GameObject preGameLoad;
	public GameObject tutorialContent;
	public GameObject shopContent;
	public GameObject achievementsContent;
	public GameObject bottomContent;
	public GameObject arrows;
	private bool gameOverAgain;
	private float timeToGameOverAgain;
	private float currentGameTimeGameOverAgain;
	private GameState currentGameState = GameState.START;
	private screenController ScreenController;
	private string lastP;
	private GameState lastGameState;
	private AchievementsAnalysisController achievementsC;
	private bool AnalyControll;
	private scenarioController scenarioC;
	private RavenSpawn ravenS;
	private bool isStart;
	private bool CentralAD;
	private bool checkADisLoad;
	private bool adTopisON;


	public string PublisherIntersticialID;
	public string PublisherBannerID;

	private BannerView bannerADTop;
	private AdRequest requestBannerADTop;

	private InterstitialAd interstitialADCentral;
	private AdRequest requestADCentral;

	public float timeToChangeTopAd;
	private float currentTimeToChangeAd;

	private int countGameAD;

	public float timeToShowLogoAnimation;
	private float currentTimeToShowLogoAnimation;

	void Start () {
		countGameAD = 3;
		adTopisON = false;
		checkADisLoad = false;
		CentralAD = false;
		currentTimeToChangeAd = 0f;
		
		bannerADTop = new BannerView(PublisherBannerID, AdSize.Banner, AdPosition.Top);
		requestBannerADTop = new AdRequest.Builder().Build();
		bannerADTop.LoadAd(requestBannerADTop);
		bannerADTop.Hide();

		isStart = true;

		timeToGameOverAgain = 1f;
		ravenS = FindObjectOfType(typeof(RavenSpawn)) as RavenSpawn;
		achievementsC = FindObjectOfType(typeof(AchievementsAnalysisController)) as AchievementsAnalysisController;
		ScreenController = FindObjectOfType(typeof(screenController)) as screenController;
		scenarioC = FindObjectOfType(typeof(scenarioController)) as scenarioController;
	}

	void Update () {

		currentTimeToChangeAd += Time.deltaTime;
		if(currentTimeToChangeAd > timeToChangeTopAd){
			changeTopAD();
			currentTimeToChangeAd = 0f;
		}


		if(CentralAD){
			loadingAD();
			CentralAD = false;
			checkADisLoad = true;
		}
		if(checkADisLoad){
			if (interstitialADCentral.IsLoaded() && currentGameState.Equals(GameState.GAMEOVER)) {
				interstitialADCentral.Show();
				checkADisLoad = false;
			}
		}

		switch(currentGameState){
		case GameState.START:{

			if(isStart){
				scenarioC.randomWorld();
				isStart = false;
			}

			currentTimeToShowLogoAnimation += Time.deltaTime;
			if(currentTimeToShowLogoAnimation > timeToShowLogoAnimation){

			tutorialContent.SetActive(false);
			score.SetActive(false);
			startContent.SetActive(true);
			bottomContent.SetActive(true);

			}
		}
			break;
		case GameState.TUTORIAL:{
			//arrows.SetActive(false);
			startContent.SetActive(false);
			tutorialContent.SetActive(true);
			bottomContent.SetActive(false);
		}
			break;
		case GameState.PREGAME:{
			arrows.SendMessage("setArrow","none",SendMessageOptions.RequireReceiver);
			bannerADTop.Show();
			score.SetActive(true);
			//arrows.SetActive(false);
			preGameLoad.SetActive(true);
			bottomContent.SetActive(false);
			startContent.SetActive(false);
			gameOverContent.SetActive(false);
		}
			break;
		case GameState.INGAME:{
			AnalyControll = true;
			score.SetActive(true);
			//arrows.SetActive(true);
			string posTemp = ScreenController.posToM();


			if(posTemp == "esq"){
				lastP = "esq";
				if(arrows.activeSelf)
				arrows.SendMessage("setArrow","esq",SendMessageOptions.RequireReceiver);
				Scene.transform.position -= new Vector3(speed, 0, 0) *Time.deltaTime;
			} else
			if(posTemp == "dir"){
				lastP = "dir";
				if(arrows.activeSelf)
				arrows.SendMessage("setArrow","dir",SendMessageOptions.RequireReceiver);
				Scene.transform.position += new Vector3(speed, 0, 0) *Time.deltaTime;
			}


		} 
			break;
		case GameState.GAMEOVER:{
			if(AnalyControll){
				addOneGameToCountAD();
				achievementsC.Analysis();
				AnalyControll = false;
				ravenS.isGameOver();
			}
			score.SetActive(false);
			currentGameTimeGameOverAgain += Time.deltaTime;
			if(currentGameTimeGameOverAgain > timeToGameOverAgain){
				currentGameTimeGameOverAgain = 0;
				gameOverAgain = true;
			}
			gameOverContent.SetActive(true);
			bottomContent.SetActive(true);
		}
			break;
		case GameState.SHOP:{
			//arrows.SetActive(false);
			shopContent.SetActive(true);
			gameOverContent.SetActive(false);
			bottomContent.SetActive(false);
			startContent.SetActive(false);
		}
			break;
		case GameState.ACHIEVES:{
			//arrows.SetActive(false);
			achievementsContent.SetActive(true);
			gameOverContent.SetActive(false);
			bottomContent.SetActive(false);
			startContent.SetActive(false);
			Scene.SendMessage("restart", SendMessageOptions.RequireReceiver);
		}
			break;
		}
	}

	public GameState getCurrentGameState(){
		return currentGameState;
	}

	public void setCurrentGameState(GameState a){
		currentGameState = a;
	}
	public void restart(){
		Scene.SendMessage("restart", SendMessageOptions.RequireReceiver);
		Player.SendMessage("restart", SendMessageOptions.RequireReceiver);
	}

	public bool getGameOverAgain(){
		return gameOverAgain;
	}
	public void setGameOverAgain(bool v){
		gameOverAgain = v;
	}

	public void saveLastGameState(){
		lastGameState = currentGameState;
	}

	public GameState getLastGameState(){
		return lastGameState;
	}

	public void restarting(){
		scenarioC.randomWorld();
		currentGameState = GameState.PREGAME;
	}

	public void addSceneSpeed(float sp){
		speed += sp;
	}

	public void createIntersticialBanner(){
		CentralAD = true;
	}

	public void changeTopAD(){
		bannerADTop = new BannerView(PublisherBannerID, AdSize.Banner, AdPosition.Top);
		requestBannerADTop = new AdRequest.Builder().Build();
		bannerADTop.LoadAd(requestBannerADTop);
	}

	public void adTopControll(){
		if(adTopisON){
			bannerADTop.Show();
		} else {
			bannerADTop.Hide();
		}
	}

	private void loadingAD(){
		interstitialADCentral = new InterstitialAd(PublisherIntersticialID);
		requestADCentral = new AdRequest.Builder().Build();
		interstitialADCentral.LoadAd(requestADCentral);
	}

	public void addOneGameToCountAD(){
		countGameAD++;
		if(countGameAD >= 3){
			tryToShowCentralAD();
			countGameAD = 0;
		}
	}

	private void tryToShowCentralAD(){
		System.Random sort = new System.Random();
		int n = sort.Next(1,3);
		if(n.Equals(1)){ // spawn
			createIntersticialBanner();
		}
	}

}
