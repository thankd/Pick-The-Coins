using UnityEngine;
using System.Collections;

public class logoFirstScreenController : MonoBehaviour {

	public float fadeSpeed = 2f;     
	
	
	private bool startFade = false;      
	private string fadeS = "none";
	private scenarioController scenarioC;
	private GameController gameC;

	public GameObject blackHover;
	public float LogoTime;
	private float currentLogoTime;

	public float lifeTime;
	private float currentlifeTime;

	void Start(){
		startFade = true;
		fadeS = "Start";
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

		currentlifeTime += Time.deltaTime;
		if(currentlifeTime > lifeTime){
			SoundController.PlaySound(soundsGame.backMusic);
			gameObject.SetActive(false);
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
		guiTexture.color = Color.Lerp(guiTexture.color, Color.white, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		
		// Fade the texture to clear.
		FadeToBlack();
		
		// If the texture is almost clear...
		if(guiTexture.color.a >= 0.75f)
		{
			fadeS = "End";
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		
		guiTexture.enabled = true;
		
		// Start fading towards black.
		currentLogoTime += Time.deltaTime;
		if(currentLogoTime >= LogoTime){
		FadeToClear();
		}
		
		// If the screen is almost black...
		if(guiTexture.color.a <= 0f){
			guiTexture.color = Color.clear;
			fadeS = "none";
			startFade = false;
		}
		
	}
}
