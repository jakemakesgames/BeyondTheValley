using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour {

	PlayerController playerController;

	void Start(){
		playerController = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			playerController.bombCount++;
			Debug.Log ("Bomb Up + 1");
			Destroy (gameObject);
		}
	}
}
