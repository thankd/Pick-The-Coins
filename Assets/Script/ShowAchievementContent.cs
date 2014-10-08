using UnityEngine;
using System;
using System.Collections;

public class ShowAchievementContent : MonoBehaviour {

	public float speed;
	public Sprite[] achievements_s;
	public float timeToStay;
	private Vector3 startP;
	private AchievementsAnalysisController AC;
	private bool isOn;
	private bool back;
	private float currentTimeToStay;
	private bool currentStates;
	private int[] flow = new int[25];
	private int controlflow;

	void Start () {
		controlflow = 0;
		isOn = false;
		currentStates = false;
		flow[0] = 0;
		startP = new Vector3(0f, 13f, 2.5f);
		AC = FindObjectOfType(typeof(AchievementsAnalysisController)) as AchievementsAnalysisController;
	}


	void Update () {

		if(!currentStates && flow[0]!=0){
			start(flow[0]);
			
				
			for(int i = 0; i < flow.Length; i++){
				if(i+1 < flow.Length){
					flow[i] = flow[i+1];
				} else {
					flow[i] = 0;
					controlflow--;
				}
			}
		}

		if(isOn){
		if(Math.Round(transform.position.y,1) > 6.5 && !back){
			transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
		} else {
				if(!back)
				currentTimeToStay += Time.deltaTime;
				if(currentTimeToStay > timeToStay){
					currentTimeToStay = 0;
					back = true;
				}
		}
			if(Math.Round(transform.position.y,1) < 13 && back){
				transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
			}
			if(Math.Round(transform.position.y,1) >= 12.9 && back){
				currentStates = false;

			}
		}
	}

	public void start(int id){
		GetComponent<SpriteRenderer>().sprite = achievements_s[id-1];
		isOn = true;
		back = false;
		currentStates = true;
	}

	public bool getCurrentStates(){
		return currentStates;
	}

	public void addOnFlow(int arg){
		flow[controlflow] = arg;
		controlflow++;
	}
}
