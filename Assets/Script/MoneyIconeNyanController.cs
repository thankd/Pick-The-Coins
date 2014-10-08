using UnityEngine;
using System.Collections;

public class MoneyIconeNyanController : MonoBehaviour {

	public float time;
	private float currentTime;

	void OnEnable(){
		currentTime = 0f;
	}

	void Start () {
	
	}

	void Update () {
		currentTime += Time.deltaTime;
		if(currentTime > time){
			currentTime = 0f;
			gameObject.SetActive(false);
		}
	}
}
