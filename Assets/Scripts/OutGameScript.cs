﻿using UnityEngine;
using System.Collections;

public class OutGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		Destroy (c.gameObject);
		Application.LoadLevel("Lose");
	}
}
