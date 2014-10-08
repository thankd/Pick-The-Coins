using UnityEngine;
using System.Collections;

public class nv_Controller : MonoBehaviour {

	public float speed;
	private int currentMeshID;
	public Sprite[] nv_sprites;
	private GameController gameC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
	}

	void OnEnable(){
		System.Random n = new System.Random();
		currentMeshID = n.Next(0,5);
		GetComponent<SpriteRenderer>().sprite = nv_sprites[currentMeshID];
	}

	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			return;

		if(transform.position.x < -9){
			gameObject.SetActive(false);
		} else {
			transform.position -= new Vector3(speed, 0, 0) *Time.deltaTime;
		}

	}
}
