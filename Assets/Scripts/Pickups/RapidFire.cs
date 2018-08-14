using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour {

	PlayerController playerController;
	public float rfTimeBetweenShots;

	void Awake(){
		// Getting a reference to the Player Controller variable
		playerController = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		// If the other game object's tag is "Player"
		if (other.tag == "Player") {
			// Set the player's time between shots equal to the rapid fire time between shots
			playerController.timeBetweenShots = rfTimeBetweenShots;
			// Destroy this game object
			Destroy (gameObject);
		}
	}
}
