using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	[SerializeField] private Transform player;

	public float moveSpeed;
	public int damageAmount;
	public GameObject projectileEffect;	// Particle effect that is Instantiated when the projectile is fired

	[SerializeField] Shake shake;

	#endregion

	// Use this for initialization
	void Start () {
		// Get reference to the Shake Component
		shake = FindObjectOfType<Shake>();
		player = FindObjectOfType<PlayerController> ().transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Move the projectile straight up
		transform.position += transform.up * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the projectile collides with an object tagged as "Player" -> Do the thing
		if (other.tag == "Player"){
			// Get a reference to the player's health controller and do some damage
			player.GetComponent<PlayerHealthController>().HurtPlayer(damageAmount);
			// Call the CamShake function
			shake.CamShake ();
			// Call the DestroyProjectile function
			DestroyProjectile ();
		}
		// If the projectile collides with an object tagged as "Wall" -> Do the thing
		if (other.tag == "Wall") {
			// Call the DestroyProjectile function
			DestroyProjectile ();
		}
	}

	void DestroyProjectile(){
		// Instantiate a particle effect
		GameObject effect = Instantiate(projectileEffect, transform.position, Quaternion.identity) as GameObject;

		// Call the CamShake function
		shake.CamShake ();

		// Destroy the Particle Effect after 1 second.
		Destroy(effect, 1f);
		// Destroy this gameObject
		Destroy(gameObject);
	}
}
