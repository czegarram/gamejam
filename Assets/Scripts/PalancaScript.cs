using UnityEngine;
using System.Collections;

public class PalancaScript : MonoBehaviour {
	public GameObject bloqueo;
	public bool arriba;
	private Vector2 initialPosition;
	private bool colision=false;
	private int i = 1;
	private string input;
	public GameObject bloque;
	// Use this for initialization
	void Start () {
		if (!arriba) {
			i = -1;
			input="2";

		}
		initialPosition = this.transform.position;
		bloqueo.rigidbody2D.velocity = new Vector2 (-1.5f, bloqueo.rigidbody2D.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
		//bloqueo.rigidbody2D.velocity = new Vector2 (-1f, bloqueo.rigidbody2D.velocity.y);
		Debug.Log (bloqueo.transform.position);

		if (arriba) {
			if (bloqueo.transform.position.y > 5) {
					bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, -1f);
			}
			if (bloqueo.transform.position.y < 2.1) {
					bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 0f);
					bloqueo.transform.position = new Vector2 (bloqueo.transform.position.x, 2.2f);
			}

			if (bloqueo.transform.position.y > 2.2f && bloqueo.transform.position.y < 5f && Input.GetAxis ("Fire") >= 0){
				this.GetComponent<Animator>().SetTrigger("Land");
				bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, -1f*i);
			}
		
		} else {
			if (bloqueo.transform.position.y < -5) {
				bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 1f);
			}
			if (bloqueo.transform.position.y > -1.6) {
				bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 0f);
				bloqueo.transform.position = new Vector2 (bloqueo.transform.position.x, -1.7f);
			}
			
			if (bloqueo.transform.position.y > -5 && bloqueo.transform.position.y < -1.8 && Input.GetAxis ("Fire"+input) >= 0){
				this.GetComponent<Animator>().SetTrigger("Land");
				bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 1f);
			}
		}
		if (bloque != null)
			transform.position =  new Vector2(bloque.transform.position.x,this.transform.position.y);
		else
			transform.Translate (new Vector3 (-.0287f, 0, 0));
	}

	void OnTriggerStay2D (Collider2D c){
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.name.StartsWith ("Tim")) {
			Debug.Log("enter");

			if (Input.GetAxis ("Fire"+input) < 0){
				bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, 1f*i);
				this.GetComponent<Animator>().SetTrigger("Jump");
				Debug.Log ("velocity");
			}else{
		
			}
			colision=true;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if (c.name.StartsWith ("Tim") ) {
			Debug.Log("exit");
			bloqueo.rigidbody2D.velocity = new Vector2 (bloqueo.rigidbody2D.velocity.x, -1f*i);
			colision=false;
		}
	}
}
