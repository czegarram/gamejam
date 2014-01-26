using UnityEngine;
using System.Collections;

public class sLoseBG : MonoBehaviour {

	Vector3 pos = new Vector3(0,7,-1);

	// Use this for initialization
	void Start () {
		transform.position = pos;
		iTween.MoveTo(gameObject, iTween.Hash("y", 0, "speed",20, "easeType", "easeInOutExpo"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
