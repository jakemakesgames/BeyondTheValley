using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damageAmount;
	public int scoreMultiplier;

	[SerializeField] private float moveSpeed;
	[SerializeField] GameManager gm;

	void Start(){
		// Find a reference to the GameManager gameObject 
		gm = FindObjectOfType<GameManager> ();
	}

	void Update(){

		// When the projectile is instantaited, move the object by the moveSpeed variable multiplied by Time.deltaTime
		transform.position += transform.up * moveSpeed * Time.deltaTime;

		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the projectile collides with another GameObject tagged "Enemy" -> take the damageAmount from the enemies health
		if (other.tag == "Enemy") {
			// Deal damage to the enemy
			other.GetComponent<EnemyHealthManager> ().TakeDamage (damageAmount);
			// Add score
			gm.AddScore(scoreMultiplier);
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
