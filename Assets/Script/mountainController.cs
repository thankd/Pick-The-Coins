using UnityEngine;
using System.Collections;

public class mountainController : MonoBehaviour {

	public float speed;
	public float maxXScale;
	public float minXScale;
	public float maxYScale;
	public float minYScale;
	private GameController gameC;


	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
	}
	
	void OnEnable(){
		setScale();
	}

	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			return;

		if(transform.position.x < -12){
			gameObject.SetActive(false);
		} else {
			transform.position -= new Vector3(speed, 0, 0) *Time.deltaTime;
		}
	}

	private void setScale(){
		float randXScale = Random.Range(minXScale, maxXScale);
		float randYScale = Random.Range(minYScale, maxYScale);
		transform.localScale = new Vector3(randXScale, randYScale, transform.localScale.y);
	}
}
