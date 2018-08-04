using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	PlayerHealthController playerHealthController;
	public int healthGained;

	void Awake(){
		// Getting a reference to the Player Health Controller variable
		playerHealthController = FindObjectOfType<PlayerHealthController> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the object collided has a tag "Play" -> Do the thing
		if (other.tag == "Player") {
			// Check if the player's health is less that the number of hearts, if true
			if (playerHealthController.health < playerHealthController.numberOfHearts) {
				// Add the healthGained int to the player's health
				playerHealthController.GainHealth (healthGained);
				// Destroy this game object
				Destroy (gameObject);
			}
		}
	}
}
