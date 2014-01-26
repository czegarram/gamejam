using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {
	public Transform topScreen;
	public Transform bottomScreen;
	public int scale;
	public float speed = .6f ;
	public float pixelsToUnit;
	private float nextpositionBG;
	private float maxLimitLeftBG;

	private GameObject newTopScreen,newBottomScreen;

	void clonarBGTop ()
	{
		newTopScreen = (GameObject)Instantiate (topScreen.gameObject, new Vector3 (topScreen.position.x + nextpositionBG, topScreen.position.y), new Quaternion ());
	}

	void clonarBGBottom ()
	{
		newBottomScreen = (GameObject)Instantiate (bottomScreen.gameObject, new Vector3 (bottomScreen.position.x + nextpositionBG, bottomScreen.position.y), new Quaternion ());
	}

	void ClonarBackgrounds ()
	{
		clonarBGTop ();
		clonarBGBottom ();
	}

	// Use this for initialization
	void Start () {
		speed = speed * 0.015f;
		nextpositionBG = (topScreen.gameObject.GetComponent<SpriteRenderer> ().sprite.texture.width / pixelsToUnit) * (scale) ;
		maxLimitLeftBG = topScreen.transform.position.x - nextpositionBG;
		ClonarBackgrounds ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.deltaTime);
		if (topScreen.transform.position.x < maxLimitLeftBG) {
			topScreen.transform.position = new Vector3(newTopScreen.transform.position.x+nextpositionBG,topScreen.transform.position.y);
			GameObject tmp = newTopScreen;
			newTopScreen = topScreen.gameObject;
			topScreen = tmp.transform;
		} else {
			//topScreen.Translate (Vector3.left * speed);
			topScreen.rigidbody2D.velocity=new Vector2(-2,0);
		}

		if (bottomScreen.transform.position.x < maxLimitLeftBG) {
			bottomScreen.transform.position = new Vector3(newBottomScreen.transform.position.x+nextpositionBG,bottomScreen.transform.position.y);
			GameObject tmp = newBottomScreen;
			newBottomScreen = bottomScreen.gameObject;
			bottomScreen = tmp.transform;
		} else {
			//bottomScreen.Translate (Vector3.left * speed); 
			bottomScreen.rigidbody2D.velocity=new Vector2(-2,0);

		}
		newTopScreen.rigidbody2D.velocity=new Vector2(-2,0);
		newBottomScreen.rigidbody2D.velocity=new Vector2(-2,0);
		//newTopScreen.transform.Translate (Vector3.left * speed); 
		//newBottomScreen.transform.Translate (Vector3.left * speed);
	}
}
