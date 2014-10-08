using UnityEngine;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class btn_likePage : MonoBehaviour {


	private float time = 10f;
	private float currentTime;
	private bool isOk;
	private ShopContentController shopC;

	void Start () {
		shopC = FindObjectOfType(typeof(ShopContentController)) as ShopContentController;
	}

	void Update(){

	}
	
	private void OnEnable()
	{
		GetComponent<MetaGesture>().StateChanged += metaHandler;
	}
	
	private void OnDisable()
	{
		GetComponent<MetaGesture>().StateChanged -= metaHandler;
	}
	
	void metaHandler (object sender, EventArgs e)
	{
		if (GetComponent<MetaGesture> ().State.Equals (Gesture.GestureState.Began)) {
			Application.OpenURL ("https://www.facebook.com/pickthecoinsGame");
			shopC.btnLikePage();
			}
	}
}
