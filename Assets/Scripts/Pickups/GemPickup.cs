using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {

	GameManager gm;

	void Start(){
		gm = FindObjectOfType<GameManager> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the object collided has the tag "Player" -> Do the thing
		if (other.tag == "Player") {

			// If the GemCount is greater than or equal to 999
			if (gm.gemCount >= 999) {
				// Cap the player's gem count at 999
				gm.gemCount = 999;
				Debug.Log ("You cannot hold anymore gems!");
			} else {
				// Increase the Gem count by 1
				gm.gemCount++;
				// Update the Gem Text
				gm.UpdateGemText ();

				Debug.Log (gm.gemCount);

				// Destroy this object
				Destroy(gameObject);
			}
		}
	}
}
