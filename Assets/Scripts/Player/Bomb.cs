using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	[Header("General Stats")]
	public float delay; // This is the time delay between being instantiated and exploding (0 by default).
	public Vector2 targetScale; // This is how large the bomb will scale overtime
	public float scaleSpeed; // This is how fast the bomb will scale;

	private SpriteRenderer rend;

	[SerializeField] private float countdown;
	[SerializeField] private bool hasExploded;	// A bool to check whether or not the bomb has exploded or not.

	public float radius; // This is the radius of the explosion.
	public int damageAmount; // How much damage will this bomb inflict within the explosion radius.

	public GameObject explosionEffect;	// This is the particle that will play when the bomb explodes

	[SerializeField] Shake shake;

	void Start(){
		// Countdown's value is equal to the delay's value
		countdown = delay;
		// Find Reference to the Shake GameObject
		shake = FindObjectOfType<Shake>();

		rend = GetComponent<SpriteRenderer> ();
	}

	// Potentially have the colour of the bomb slowly change to *red* for the duration of the countdown (?)
	void Update(){
		// Time.deltaTime is subtracted from the countdown variable every frame
		countdown -= Time.deltaTime;
		transform.localScale = Vector2.Lerp (transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

		// This lerps the colour of the bomb between grey and red, with a Ping Pong effect
		rend.material.color =  Color.Lerp (Color.white, Color.red, (Mathf.PingPong (Time.time, 0.5f)));

		// If the countdown's value is less than or equal to 0, do the thing
		if (countdown <= 0 && !hasExploded){
			// Call the Explode function
			Explode ();
			// hasExploded becomes TRUE, which means this grenade CANNOT explode again.
			hasExploded = true;
		}
	}

	void Explode(){
		Debug.Log ("BOOM BOI!");
		// Instantiate the Explosion particle effect

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

		foreach (Collider2D nearbyObject in colliders) {

			// If the nearby object's tag is "Enemy"
			if (nearbyObject.tag == "Enemy") {
				// Get the EnemyHealthManager component on that object and call the TakeDamage function -> deal the damageAmount to their health
				nearbyObject.GetComponent<EnemyHealthManager>().TakeDamage (damageAmount);
			}

			// If the nearby object's tag is "Player"
			if (nearbyObject.tag == "Player") {
				// Get the HealthManager component on that object and call the TakeDamage function -> deal the damageAmount to their health
				nearbyObject.GetComponent<PlayerHealthController>().HurtPlayer (damageAmount);
			}	
		}
		GameObject explode = Instantiate (explosionEffect, transform.position, Quaternion.identity) as GameObject;

		// Call the CamShake function
		shake.CamShake ();

		Destroy (gameObject);
		Destroy (explode, 1f);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
