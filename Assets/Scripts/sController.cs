using UnityEngine;
using System.Collections;

public class sController : MonoBehaviour {

	public AudioClip self;

	void Start(){
		StartCoroutine("playSelf");
	}

	IEnumerator playSelf(){
		yield return new WaitForSeconds(1);
		audio.PlayOneShot(self);
	}

}
