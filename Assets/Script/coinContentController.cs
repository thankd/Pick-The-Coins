using UnityEngine;
using System.Collections;

public class coinContentController : MonoBehaviour {

	public float speed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.activeSelf == true){
			transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
		}

		if(transform.position.y < -6)
			gameObject.SetActive(false);
	}
}
