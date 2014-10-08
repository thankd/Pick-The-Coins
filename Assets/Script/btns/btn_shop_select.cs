using UnityEngine;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_shop_select : MonoBehaviour {
	
	private ShopContentController shopC;
	public float speed;
	private bool isAni;

	void Start () {
		shopC = FindObjectOfType(typeof(ShopContentController)) as ShopContentController;
	}
	
	private void OnEnable()
	{
		isAni = true;
		transform.position = new Vector3(0.2f, -12f, -1.5f);
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
			shopC.selectShip();
		}
	}
	
	void Update () {
		if(isAni){
			if(System.Math.Round(transform.position.y, 1) < -8f){
				transform.position += new Vector3(0f, speed, 0f) * Time.deltaTime;
			} else {
				isAni = false;
			}
		}
	}
}