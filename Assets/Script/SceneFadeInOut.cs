using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
		
	
	private bool startFade = false;      // Whether or not the scene is still fading in.
	private string fadeS = "none";
	private scenarioController scenarioC;
	private GameController gameC;
	public GameObject gameController;


	void Start(){
		gameC = FindObjectOfType(typeof(GameController)) as GameController;
		guiTexture.color = Color.clear;
	}

	
	
	void Update ()
	{
		// If the scene is starting...
		if(startFade){
			if(fadeS.Equals("Start")){
				StartScene();
			} else 
			if(fadeS.Equals("End")){
				EndScene();
			}
		}
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, 2*fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{

		// Fade the texture to clear.
		FadeToBlack();
		
		// If the texture is almost clear...
		if(guiTexture.color.a >= 0.75f)
		{
			gameC.restart();
			gameController.SendMessage("restarting", SendMessageOptions.RequireReceiver);
			fadeS = "End";
		}
	}
	

	public void EndScene ()
	{
		// Make sure the texture is enabled.

		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToClear();

		// If the screen is almost black...
		if(guiTexture.color.a < 0f){
			guiTexture.color = Color.clear;
			fadeS = "none";
			startFade = false;
		}

	}

	public void StartFade(){
		startFade = true;
		fadeS = "Start";
	}
}