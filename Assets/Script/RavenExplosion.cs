using UnityEngine;
using System.Collections;

public class RavenExplosion : MonoBehaviour {

	private bool OnExplosion = false;
	public float timeOfAnimation;
	private float currentTime;
	private Animator animatorExpo; 


	void OnEnable(){
		animatorExpo = GetComponent<Animator>();
		OnExplosion = true;
		currentTime = 0f;
		animatorExpo.SetBool("RavenExplosion", true);
	}

	void Start () {
	
	}
	
	void Update () {
		if(OnExplosion){
			currentTime += Time.deltaTime;
			if(currentTime > timeOfAnimation){
				OnExplosion = false;
				animatorExpo.SetBool("RavenExplosion", false);
				gameObject.SetActive(false);
			}
		}
	}
}
