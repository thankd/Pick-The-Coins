using UnityEngine;
using System.Collections;

public class gameOverController : MonoBehaviour {

	public TextMesh a_score;
	public TextMesh best;
	public TextMesh a_score_shadow;
	public TextMesh best_shadow;
	public GameObject coinsP;
	private playerController playerC;
	private AchievementsAnalysisController achievementsC;
	public Sprite[] coin_points;
	public float speed;
	public GameObject pirate_msg1;
	public GameObject pirate_msg2;
	private bool isAni;
	
	void Start () {
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
		achievementsC = FindObjectOfType(typeof(AchievementsAnalysisController)) as AchievementsAnalysisController;
	}

	void OnEnable(){
		isAni = true;
		transform.position = new Vector3(-13, -0.4f, -6.4f);
	}

	void Update () {

		if(isAni){
			if(System.Math.Round(transform.position.x, 1) < 0){
				transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}

		if(playerC.getScore() > PlayerPrefs.GetInt("ScorePTC")){
			PlayerPrefs.SetInt("ScorePTC",playerC.getScore());
		}

		int points = PlayerPrefs.GetInt("ScorePTC");
		if(points > 0)
			coinsP.GetComponent<SpriteRenderer>().sprite = coin_points[0];
		if(points >= 10 && points < 25)
			coinsP.GetComponent<SpriteRenderer>().sprite = coin_points[1];
		if(points >= 25 && points < 40)
			coinsP.GetComponent<SpriteRenderer>().sprite = coin_points[2];
		if(points >= 40 && points < 60)
			coinsP.GetComponent<SpriteRenderer>().sprite = coin_points[3];
		if(points >= 60)
			coinsP.GetComponent<SpriteRenderer>().sprite = coin_points[4];

		a_score.text = playerC.getScore().ToString();
		best.text = PlayerPrefs.GetInt("ScorePTC").ToString();
		a_score_shadow.text = playerC.getScore().ToString();
		best_shadow.text = PlayerPrefs.GetInt("ScorePTC").ToString();
	
		if(playerC.getScore() >= PlayerPrefs.GetInt("ScorePTC") && playerC.getScore() >= 10){
			pirate_msg1.SetActive(true);
			pirate_msg2.SetActive(false);
		} else {
			pirate_msg1.SetActive(false);
			pirate_msg2.SetActive(true);
		}
	}
}
