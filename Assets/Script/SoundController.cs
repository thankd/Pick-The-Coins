using UnityEngine;
using System.Collections;

public enum soundsGame{
	backMusic,
	coin,
	loser,
	changeSide,
	btnSound,
	bombDrop,
	birdAttack,
	birdPickedCoin,
	shipExplosion,
	birdExploded,
	nyanPickedCoin,
}

public class SoundController : MonoBehaviour {
	public AudioClip backMusic;
	public AudioClip soundCoin;
	public AudioClip soundLoser;
	public AudioClip soundChangeSide;
	public AudioClip btnSound;
	public AudioClip bombDrop;

	public AudioClip birdAttack;
	public AudioClip birdPickedCoin;
	public AudioClip shipExplosion;
	public AudioClip birdExploded;
	public AudioClip nyanPickedCoin;

	public static SoundController instance;
	
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public static void PlaySound(soundsGame currentSound){
		switch(currentSound){
		case soundsGame.backMusic:{
			instance.audio.PlayOneShot(instance.backMusic);
		}
			break;
		case soundsGame.coin:{
			instance.audio.PlayOneShot(instance.soundCoin);
		}
			break;
		case soundsGame.loser:{
			instance.audio.PlayOneShot(instance.soundLoser);
		}
			break;
		case soundsGame.changeSide:{
			instance.audio.PlayOneShot(instance.soundChangeSide);
		}
			break;
		case soundsGame.btnSound:{
			instance.audio.PlayOneShot(instance.btnSound);
		}
			break;
		case soundsGame.bombDrop:{
			instance.audio.PlayOneShot(instance.bombDrop);
		}
			break;
		case soundsGame.birdAttack:{
			instance.audio.PlayOneShot(instance.birdAttack);
		}
			break;
		case soundsGame.birdPickedCoin:{
			instance.audio.PlayOneShot(instance.birdPickedCoin);
		}
			break;
		case soundsGame.birdExploded:{
			instance.audio.PlayOneShot(instance.birdExploded);
		}
			break;
		case soundsGame.shipExplosion:{
			instance.audio.PlayOneShot(instance.shipExplosion);
		}
			break;
		case soundsGame.nyanPickedCoin:{
			instance.audio.PlayOneShot(instance.nyanPickedCoin);
		}
			break;
		}
	}
}
