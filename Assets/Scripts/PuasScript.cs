using UnityEngine;
using System.Collections;

public class PuasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (-1.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c != null)
			if (c.name.StartsWith ("Tim"))
				Destroy (c.gameObject);
	}

}
