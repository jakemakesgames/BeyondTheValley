using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	public float speed;
	public int damageAmount;
	public GameObject projectileEffect;	// Particle effect that is Instantiated when the projectile is fired

	[SerializeField] private Transform player;
	[SerializeField] private Vector2 target;

	[SerializeField] Shake shake;

	#endregion

	void Start(){
		
		#region REFERENCING COMPONENTS / SETTING VALUES
		// The player Transform component is equal to the Player GameObject's transform component
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		// The target is now set to the Player's X and Y transform positions
		target = new Vector2 (player.position.x, player.position.y);

		shake = FindObjectOfType<Shake>();

		#endregion
	}

	void Update(){
		
		#region REGULAR MOVEMENT
		// Move the projectile to the player's position (Even if the player is no longer there)
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

		// Check whether or not the projectile has reached it's desired destination
		if (transform.position.x == target.x && transform.position.y == target.y){
			DestroyProjectile();
		}
		#endregion

		#region MISSILE MOVEMENT
		// If we want the projectile to follow the player like a missile, use the line of code below
		//transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		#endregion

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
