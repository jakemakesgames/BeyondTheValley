using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damageAmount;

	[SerializeField] private float moveSpeed;

	void Update(){

		// When the projectile is instantaited, move the object by the moveSpeed variable multiplied by Time.deltaTime
		transform.position += transform.up * moveSpeed * Time.deltaTime;

		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the projectile collides with another GameObject tagged "Enemy" -> take the damageAmount from the enemies health
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().TakeDamage (damageAmount);
			// Instantiate particle effect
			// Destroy the gameObject
			Destroy(gameObject);
		}
		// If the projectile collides with another GameObject tagged "Wall" -> Destroy the projectile
		if (other.tag == "Wall") {
			// Instantiate particle effect
			// Destroy the gameObject
			Destroy(gameObject);
		}
	}
}
