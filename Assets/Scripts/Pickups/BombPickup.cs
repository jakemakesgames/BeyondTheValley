using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour {

	PlayerController playerController;

	void Start(){
		playerController = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		// If the other object to collide with this is tagged player
		if (other.tag == "Player") {
			// If the player's bomb count is greater than or equal to 100
			if (playerController.bombCount >= 100) {
				// Cap the player's bomb count to 100
				playerController.bombCount = 100;
				Debug.Log ("You cannot hold anymore bombs!");
			} else {
				// Increase the bomb count by 1
				playerController.bombCount++;
				Debug.Log ("Bomb Up + 1");
				playerController.UpdateBombUI ();
				// Destroy this pickup object (to prevent it being picked up again) 
				Destroy (gameObject);
			}
		}
	}
}

