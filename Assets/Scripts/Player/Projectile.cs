using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damageAmount;
	public int scoreMultiplier;
	public GameObject particleEffect;

	[SerializeField] private float moveSpeed;
	[SerializeField] GameManager gm;
	[SerializeField] Shake shake;

	void Start(){
		// Find a reference to the GameManager gameObject 
		gm = FindObjectOfType<GameManager> ();
		// Find a reference to the Shake gameObject;
		shake = FindObjectOfType<Shake>();
	}

	void Update(){

		// When the projectile is instantaited, move the object by the moveSpeed variable multiplied by Time.deltaTime
		transform.position += transform.up * moveSpeed * Time.deltaTime;

		// Call the destroy projectile funtion
		DestroyProjectile();
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the projectile collides with another GameObject tagged "Enemy" -> take the damageAmount from the enemies health
		if (other.tag == "Enemy") {
			// Deal damage to the enemy
			other.GetComponent<EnemyHealthManager> ().TakeDamage (damageAmount);
			// Add score
			gm.AddScore(scoreMultiplier);
			// Instantiate particle effect
			GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;

			// Call the CamMiniShake method
			shake.CamMiniShake();

			// Destroy the particle effect after 1 second
			Destroy (particle, 1f);
			// Destroy the gameObject
			Destroy(gameObject);
		}
		// If the projectile collides with another GameObject tagged "Wall" -> Destroy the projectile
		if (other.tag == "Wall") {
			// Instantiate particle effect
			GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;

			// Call the CamMiniShake method
			shake.CamMiniShake();

			// Destroy the particle effect after 1 second
			Destroy (particle, 1f);
			// Destroy the gameObject
			Destroy(gameObject);
		}
	}

	void DestroyProjectile(){
		// Instantiate particle effect
		GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
		// Call the CamMiniShake method
		shake.CamMiniShake();
		// Destroy the particle effect after 1 second
		Destroy (particle, 1f);
		// Destroy the gameObject
		Destroy(gameObject, 1f);
	}
}
