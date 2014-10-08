using UnityEngine;
using System.Collections;
using System;

public class starsController : MonoBehaviour {
	
	public float speed;
	public GameObject starsTwo;
	private Vector3 startPosition;
	private Vector3 First1startPosition;
	private bool control1;
	private bool control2;
	private bool loopStart;
	private bool starsStates;
	
	void Start () {
		First1startPosition = transform.position;
		startPosition = starsTwo.transform.position;
		starsTwo.transform.position = startPosition;
		control1 = true;
		control2 = false;
		loopStart = false;
	}
	
	void Update () { //x = 2 e y = 11
		
		if(starsStates){
			if(control1){
				if(Math.Round(transform.position.x, 1) > -4f){
					transform.position += new Vector3(-speed, 0, 0);
				} else {
					starsTwo.transform.position = startPosition;
					control1 = false;
					control2 = true;
					if(!loopStart)
						loopStart = true;
				}
			}
			if(control2){
				if(Math.Round(starsTwo.transform.position.x, 1) > -4f){
					starsTwo.transform.position += new Vector3(-speed, 0, 0);
				} else {
					transform.position = startPosition;
					control1 = true;
					control2 = false;
				}
			}
			
			if(!control1){
				transform.position += new Vector3(-speed, 0, 0);
			}
			if(!control2 && loopStart){
				starsTwo.transform.position += new Vector3(-speed, 0, 0);
			}
		}
		
		
	}
	
	public void startStars(){
		starsStates = true;
	}

	public void stopStars(){
		transform.position = First1startPosition;
		starsTwo.transform.position = startPosition;
		starsStates = false;
		control1 = true;
		control2 = false;
		loopStart = false;
	}
}
