using UnityEngine;
using System.Collections;
using System;

public class WaterfallController : MonoBehaviour {

	public float speed;
	public GameObject fallTwo;
	private Vector3 startPosition;
	private Vector3 First1startPosition;
	private bool control1;
	private bool control2;
	private bool loopStart;
	private bool waterfallState;

	void Start () {
		First1startPosition = transform.position;
		startPosition = fallTwo.transform.position;
		fallTwo.transform.position = startPosition;
		control1 = true;
		control2 = false;
		loopStart = false;
	}

	void Update () { //x = 2 e y = 11

		if(waterfallState){
		if(control1){
			if(Math.Round(transform.position.x, 1) > 3f && Math.Round(transform.position.y, 1) > 11f){
				transform.position += new Vector3(-speed, -speed, 0);
			} else {
				fallTwo.transform.position = startPosition;
				control1 = false;
				control2 = true;
				if(!loopStart)
					loopStart = true;
			}
		}
		if(control2){
			if(Math.Round(fallTwo.transform.position.x, 1) > 3f && Math.Round(fallTwo.transform.position.y, 1) > 11f){
				fallTwo.transform.position += new Vector3(-speed, -speed, 0);
			} else {
				transform.position = startPosition;
				control1 = true;
				control2 = false;
			}
		}

		if(!control1){
			transform.position += new Vector3(-speed, -speed, 0);
		}
		if(!control2 && loopStart){
			fallTwo.transform.position += new Vector3(-speed, -speed, 0);
		}
		}


	}

	public void startWaterfall(){
		waterfallState = true;
	}

	public void stopWaterfall(){
		transform.position = First1startPosition;
		fallTwo.transform.position = startPosition;
		waterfallState = false;
		control1 = true;
		control2 = false;
		loopStart = false;
	}
}
