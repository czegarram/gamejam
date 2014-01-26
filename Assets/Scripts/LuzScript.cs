using UnityEngine;
using System.Collections;

public class LuzScript : MonoBehaviour {

	public float intervalo;
	private Color col;
	private bool fade;
	SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		fade = true;
		spr = GetComponent("SpriteRenderer") as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		cambiarOpacidad();

	}

	void cambiarOpacidad(){

		col = spr.color;
		if(fade == true){
			col.a -= 0.036f;
			if(col.a <= 0){
				fade = false;
			}
		}
		else{
			col.a += 0.036f;
			if(col.a >= 1){
				fade = true;
			}
		}
		Debug.Log(col.a);
		spr.color = col;
	}
}
