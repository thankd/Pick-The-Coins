using UnityEngine;
using System.Collections;

public class ColliderOnPlayerController : MonoBehaviour {

	// Use this for initialization
	private playerController playerC;
	private GameController gameC;
	private bool isAni;

	void Start () {
		playerC = FindObjectOfType(typeof(playerController)) as playerController;
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			isAni = false;
		else 
			isAni = true;
		
		//gameObject.GetComponent<Animator>().SetBool("playerAnimation", isAni);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "coin"){
			playerC.ColliderOn("coin");
			coll.gameObject.SetActive(false);
			coll.gameObject.transform.position = new Vector3(0, 11, 0);
		}
		
		if(coll.gameObject.tag == "bomb"){
			playerC.ColliderOn("bomb");
			coll.gameObject.SetActive(false);
			coll.gameObject.transform.position = new Vector3(0, 11, 0);
		}
	}
}
