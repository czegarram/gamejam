using UnityEngine;
using System.Collections;

public class PalancaScript : MonoBehaviour {
	public GameObject bloqueo;
	private Vector2 initialPosition;
	private bool colision=false;
	// Use this for initialization
	void Start () {
		initialPosition = this.transform.position;
		bloqueo.rigidbody2D.velocity = new Vector2 (-1f, bloqueo.rigidbody2D.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
		//bloqueo.rigidbody2D.velocity = new Vector2 (-1f, bloqueo.rigidbody2D.velocity.y);
		transform.Translate (new Vector3 (-.017f, 0, 0));
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.name.StartsWith ("Tim") && !colision) {
			if(Input.GetButtonDown ("Jump"))
				if (Input.GetAxis ("Jump") < 0){
					bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 1f);
					colision=true;
				}
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if (c.name.StartsWith ("Tim") && colision) {
			bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, -1f);
			colision=false;
		}
	}
}
