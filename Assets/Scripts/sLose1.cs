﻿using UnityEngine;
using System.Collections;

public class sLose1 : MonoBehaviour {

	public GameObject losePrefab;
	// Use this for initialization
	void Start () {
		Instantiate(losePrefab, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
