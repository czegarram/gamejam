using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public GameObject playerPrefab;
	
	// Use this for initialization
	void Start () {
		if (Network.isServer) {
			Network.Instantiate (playerPrefab, spawnPoint1.position, Quaternion.identity, 0);
		} 
		else {
			Network.Instantiate (playerPrefab, spawnPoint2.position, Quaternion.identity, 0);
		}
	}
}
