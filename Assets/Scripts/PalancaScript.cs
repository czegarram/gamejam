using UnityEngine;
using System.Collections;

public class PalancaScript : MonoBehaviour {
	public GameObject bloqueo;
	private Vector2 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		bloqueo.rigidbody2D.velocity = new Vector2 (-2f, bloqueo.rigidbody2D.velocity.y);
		transform.Translate (new Vector3 (-.035f, 0, 0));
	}

	void OnTriggerEnter2D(Collider2D c){
		if (Input.GetAxis("Jump") < 0)
				bloqueo.rigidbody2D.velocity = new Vector2 ( bloqueo.rigidbody2D.velocity.x, 1f);
	}

	void OnTriggerExit2D(Collider2D c){
		bloqueo.rigidbody2D.velocity = new Vector2 ( bloqueo.rigidbody2D.velocity.x, -1f);
	}
}
