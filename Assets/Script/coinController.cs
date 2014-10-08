using UnityEngine;
using System.Collections;

public class coinController : MonoBehaviour {
	
	private float speed;
	private Vector3 startPos;
	private GameController gameC;
	private float XAbs;
	private float YtoActive;
	private sceneController sceneC;
	public bool isBomb;
	private screenController ScreenController;

	void Start () {
		startPos = transform.position;
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		sceneC = FindObjectOfType(typeof(sceneController)) as sceneController;
		ScreenController = FindObjectOfType(typeof(screenController)) as screenController;
	}

	void Update () {

		if(gameC.getCurrentGameState() != GameState.GAMEOVER){
			if(gameC.getCurrentGameState() == GameState.INGAME){
			normalSp();
		} else 
			if(gameC.getCurrentGameState() == GameState.INGAME){
			ultraSp();
		}

			if(isBomb){
				string posTemp = ScreenController.posToM();
				if(posTemp == "esq"){
					transform.eulerAngles = new Vector3(0f, 0f, -18f);
				} else
				if(posTemp == "dir"){
					transform.eulerAngles = new Vector3(0f, 0f, 18f);
				} else {
					transform.eulerAngles = new Vector3(0f, 0f, 0f);
				}
			}

		if(transform.position.x > 5.2){
			transform.position = new Vector2(5.2f, transform.position.y);
		}
		if(transform.position.x < -5.2){
			transform.position = new Vector2(-5.2f, transform.position.y);
		}
		if(transform.position.y > YtoActive){
			gameObject.SetActive(true);
		}
		if(transform.position.y < -9){
			gameObject.SetActive(false);
			transform.position = startPos;
		} else {
			//transform.position = new Vector3(XAbs, transform.position.y);
			transform.position -= new Vector3(0f, speed, 0f) * Time.deltaTime;
		}
		}
	}

	private void ultraSp(){
		speed = sceneC.getObejctSpeed();
	}

	private void normalSp(){
		speed = sceneC.getObejctSpeed();
	}

	private void yToStart(float y){
		gameObject.SetActive(false);
		YtoActive = y;
	}

}
