using UnityEngine;
using System.Collections;

public class ArrowsController : MonoBehaviour {

	public Sprite[] hover_arrows; 
	public Sprite[] arrows;
	public GameObject left;
	public GameObject right;
	private string arrow;

	void Start () {
		arrow = "";
	}
		
	void Update () {
		if(arrow.Equals("esq")){
			left.GetComponent<SpriteRenderer>().sprite = hover_arrows[0];
			right.GetComponent<SpriteRenderer>().sprite = arrows[1];
		} else 
		if(arrow.Equals("dir")){
			left.GetComponent<SpriteRenderer>().sprite = arrows[0];
			right.GetComponent<SpriteRenderer>().sprite = hover_arrows[1];
		} else {
			left.GetComponent<SpriteRenderer>().sprite = arrows[0];
			right.GetComponent<SpriteRenderer>().sprite = arrows[1];
		}
	}

	public void setArrow(string arg){
		arrow = arg;
	}
}
