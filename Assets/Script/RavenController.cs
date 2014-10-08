using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RavenController : MonoBehaviour {

	public float speed;
	public Sprite Normal;
	public Sprite WithCoin;
	public Sprite none; // none Sprite renderer
	public bool isRight;
	public bool isDown;
	private Vector3 startP;
	private bool RavenUp = false;
	private float randY;
	public GameObject Explosion;
	private bool isExploded = false;
	private playerController playerC;

	void Start () {
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
		startP = transform.position;
	}

	void OnEnable(){
		RavenUp = true;
		isExploded = false;
		float randY = Random.Range(-1, 5);
		transform.position = new Vector3(transform.position.x, randY, transform.position.z);
	}

	void Update () {
		if(RavenUp){

			if(isRight && isDown){ // começa pela direita caindo
			if(System.Math.Round(transform.position.x, 1) >= -12){
			transform.position += new Vector3(speed * -1f, speed * -0.1f, 0f) * Time.deltaTime;
			} else {
				transform.position = startP;
				gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
					RavenUp = false;
					gameObject.SetActive(false);
			}
			}

			if(!isRight && isDown){ // começa pela esquerda caindo
				if(System.Math.Round(transform.position.x, 1) <= 12){
					transform.position += new Vector3(speed * 1f, speed *-0.1f, 0f) * Time.deltaTime;
				} else {
					transform.position = startP;
					gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
					RavenUp = false;
					gameObject.SetActive(false);
				}
			}

			if(isRight && !isDown){ // começa pela direita subindo
				if(System.Math.Round(transform.position.x, 1) >= -12){
					transform.position += new Vector3(speed * -1f, speed * 0.1f, 0f) * Time.deltaTime;
				} else {
					transform.position = startP;
					gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
					RavenUp = false;
					gameObject.SetActive(false);
				}
			}
			
			if(!isRight && !isDown){ // começa pela esquerda subindo
				if(System.Math.Round(transform.position.x, 1) <= 12){
					transform.position += new Vector3(speed * 1f, speed * 0.1f, 0f) * Time.deltaTime;
				} else {
					transform.position = startP;
					gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
					RavenUp = false;
					gameObject.SetActive(false);
				}
			}

		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "coin"){
			if(!isExploded){
			playerC.BirdPickedCoin();
			SoundController.PlaySound(soundsGame.birdPickedCoin);
			coll.gameObject.SetActive(false);
			gameObject.GetComponent<SpriteRenderer>().sprite = WithCoin;
			}
		}

		if(coll.gameObject.tag == "bomb"){
			isExploded = true;
			SoundController.PlaySound(soundsGame.birdExploded);
			coll.gameObject.SetActive(false);
			gameObject.GetComponent<SpriteRenderer>().sprite = none;
			Explosion.SetActive(true);
		}
	}

	public void changeDirection(int n){
		if(n == 1){ // caindo esquerda
			transform.position = new Vector3(-12f, transform.position.y, 8f);
			transform.eulerAngles = new Vector3(0f,0f, 350f);
			isDown = true;
			isRight = false;
		} else 
		if(n == 2){ // subindo esquerda
			transform.position = new Vector3(-12f, transform.position.y, 8f);
			transform.eulerAngles = new Vector3(0f,0f, 10f);
			isDown = false;
			isRight = false;
		} else
		if(n == 3){ // caindo direita
			transform.position = new Vector3(12f, transform.position.y, 8f);
			transform.eulerAngles = new Vector3(0f,180f, -12f);
			isDown = true;
			isRight = true;
		} else
		if(n == 4){ // subindo direita
			transform.position = new Vector3(12f, transform.position.y, 8f);
			transform.eulerAngles = new Vector3(0f,180f, 10f);
			isDown = false;
			isRight = true;
		}
	}


}
