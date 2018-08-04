using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	public int healthGained;

	public void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthController> ().GainHealth (healthGained);
			Destroy (this.gameObject);
		}
	}
}
