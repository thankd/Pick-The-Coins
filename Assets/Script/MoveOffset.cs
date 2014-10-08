using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speed;
	private float offset;
	private GameController gameC;
	
	
	void Start () {
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		currentMaterial = renderer.material;
		
	}

	void Update () {
		if(gameC.getCurrentGameState().Equals(GameState.GAMEOVER))
			return;


		offset += 0.001f;
		
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*speed, 0));
		
	}
}
