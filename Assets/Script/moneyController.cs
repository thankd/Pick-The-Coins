using UnityEngine;
using System.Collections;

public class moneyController : MonoBehaviour {

	public float speed;

	void Start () {
	
	}
	
	void Update () {
		if(transform.position.y > -6){
			gameObject.SetActive(false);
		} else {
			transform.position += new Vector3(0, speed, 0) *Time.deltaTime;
		}
	}
}
