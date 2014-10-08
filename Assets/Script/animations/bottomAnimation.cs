using UnityEngine;
using System.Collections;
using System;
public class bottomAnimation : MonoBehaviour {

	public float speed;
	private bool isAni;

	void Update () {
		if(isAni){
			if(Math.Round(transform.position.y, 1) < 0f){
				transform.position += new Vector3(0f, speed, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}

	void OnEnable(){
		//transform.position = startPosition;
		isAni = true;
		transform.position = new Vector3(0f, -5f, -16.8f);
	}
}
