using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	[Header("General Stats")]
	public float delay; // This is the time delay between being instantiated and exploding (0 by default).
	[SerializeField] private float countdown;
	[SerializeField] private bool hasExploded;	// A bool to check whether or not the bomb has exploded or not.
	public float radius; // This is the radius of the explosion.
	public int damageAmount; // How much damage will this bomb inflict within the explosion radius.

	void Start(){
		// Countdown's value is equal to the delay's value
		countdown = delay;
	}

	// Potentially have the colour of the bomb slowly change to *red* for the duration of the countdown (?)
	void Update(){
		// Time.deltaTime is subtracted from the countdown variable every frame
		countdown -= Time.deltaTime;

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

			// If the nearby objects tag is "Enemy"
			if (nearbyObject.tag == "Enemy") {
				// Get the EnemyHealthManager component on that object and call the TakeDamage function -> deal the damageAmount to their health
				nearbyObject.GetComponent<EnemyHealthManager>().TakeDamage (damageAmount);
			}

			if (nearbyObject.tag == "Player") {
				// Get the HealthManager component on that object and call the TakeDamage function -> deal the damageAmount to their health
				nearbyObject.GetComponent<PlayerHealthController>().HurtPlayer (damageAmount);
			}	
		}

		Destroy (gameObject);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
