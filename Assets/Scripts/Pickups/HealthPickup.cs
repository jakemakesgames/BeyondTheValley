using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS HEALTH PICK UP IS ESSENTIALLY A HP (+1) PICKUP, IT WILL GIVE THE PLAYER +1 HEART TO FILL WHAT THEY HAVE MISSING -> IF THEY HAVE FULL HEARTS THEY CANNOT PICK
// THE HEART UP

public class HealthPickup : MonoBehaviour {

	PlayerHealthController playerHealthController;
	public int healthGained;

	int randNum;

	void Awake(){
		// Getting a reference to the Player Health Controller variable
		playerHealthController = FindObjectOfType<PlayerHealthController> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the object collided has a tag "Player" -> Do the thing
		if (other.tag == "Player") {

			if (healthGained == 10) {
				playerHealthController.health = 10;
				playerHealthController.numberOfHearts = 10;
				playerHealthController.GainHealth (healthGained);
				// Destroy this game object
				Destroy (gameObject);
			}


			// Check if the player's health is less that the number of hearts, if true
			if (playerHealthController.health < playerHealthController.numberOfHearts) {
				playerHealthController.GainHealth (healthGained);
				// Destroy this game object
				Destroy (gameObject);
			}
		}
	}

	public void HealthGainedValue(){

		randNum = Random.Range (1, 3);

		// If the random number variable is equal to 1
		if (randNum == 1) {
			// Add the healthGained int to the player's health
			healthGained = 1;
			Debug.Log("HP UP (+" + healthGained + ")");
		}
		// If the random number variable is equal to 1
		if (randNum == 2){
			healthGained = 3;
			Debug.Log("HP UP (+" + healthGained + ")");
		}
		// If the random number variable is equal to 3 ----> SACRED HEART! <----
		if (randNum == 3) {
			// SACRED HEART
		}
	}
}
