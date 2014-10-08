using UnityEngine;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_shop_right : MonoBehaviour {


	private ShopContentController shopC;
	public float speed;
	private bool isAni;

	void Start () {
		shopC = FindObjectOfType(typeof(ShopContentController)) as ShopContentController;
	}
	
	private void OnEnable()
	{
		isAni = true;
		transform.position = new Vector3(9f, -5.5f, -1.5f);
		GetComponent<MetaGesture>().StateChanged += metaHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<MetaGesture>().StateChanged -= metaHandler;
	}
	
	void metaHandler (object sender, EventArgs e)
	{
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Began)) {
			SoundController.PlaySound(soundsGame.btnSound);
			shopC.changeShip("right");
		}
	}
	
	void Update () {
		if(isAni){
			if(System.Math.Round(transform.position.x, 1) > 3.4f){
				transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}
}