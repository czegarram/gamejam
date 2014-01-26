using UnityEngine;
using System.Collections;

public class sLose : MonoBehaviour {

	Vector3 pos = new Vector3(-10,0,-1);

	// Use this for initialization
	void Start () {
		transform.position = pos;
		iTween.MoveTo(gameObject, iTween.Hash("x", 0, "speed",15, "easeType", "easeInOutExpo", "delay", .05));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
