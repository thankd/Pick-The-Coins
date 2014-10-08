using UnityEngine;
using System.Collections;
using System;

public class bombDrop : MonoBehaviour {

	public float speed;
	private bool ani = false;
	private bool dec = false;

	void Start () {


	}

	void OnEnable(){
		ani = true;
		dec = false;
	}

	void Update () {
		if(ani){
			if(!dec){
			if(Math.Round(transform.localScale.y, 1) < 15f){
			transform.localScale += new Vector3(0, speed, 0) * Time.deltaTime;
			} else {
				dec = true;
			}
			} else
			if(dec){
				if(Math.Round(transform.localScale.y, 1) > 0f){
					transform.localScale += new Vector3(0, -speed, 0) * Time.deltaTime;
				} else {
					ani = false;
					gameObject.SetActive(false);
				}
			}
		}
	}
}
