using UnityEngine;
using System.Collections;

public class Tree_Mesh : MonoBehaviour {
	
	public float speed;
	private int currentMeshID;
	private GameController gameC;
	private scenarioController scenarioC;

	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		scenarioC = FindObjectOfType(typeof(scenarioController)) as scenarioController;
	}
	
	void OnEnable(){

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
