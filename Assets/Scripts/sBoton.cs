using UnityEngine;
using System.Collections;

public class sBoton : MonoBehaviour {

	public string target;
	public Sprite alt;
	private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		spr = GetComponent("SpriteRenderer") as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		spr.sprite = alt;
	}

	void OnMouseUp(){
		if(gameObject.name == "salir"){
			Application.Quit();
		}
		Application.LoadLevel(target);
	}
}
