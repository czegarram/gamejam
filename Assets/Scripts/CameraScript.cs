using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float pixelsPerUnit;
	
	public int zoom = 1;	
	
	void Start () { 		
		Camera.main.orthographicSize = Screen.height / 2f / pixelsPerUnit / zoom;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
