using UnityEngine;
using System.Collections;

public class LevelInfoController : MonoBehaviour {

	public float time;
	private float currentTime;
	private string levelString;
	private sceneController sceneC;
	public TextMesh level;
	public TextMesh levelShadow;
	private bool isOn;
	private int levelInt;

	void OnEnable(){
		isOn = true;
		levelString = "Level " + levelInt.ToString();
		level.text = levelString;
		levelShadow.text = levelString;
	}

	void Start () {
		levelInt = 0;
		sceneC = FindObjectOfType(typeof(sceneController)) as sceneController;
		isOn = false;
	}

	void Update (){
		if(isOn){
			currentTime += Time.deltaTime;
			if(currentTime > time){
				isOn = false;
				gameObject.SetActive(false);
			}
		}
	}

	public void setLevel(int arg){
		levelInt = arg;
	}

}
