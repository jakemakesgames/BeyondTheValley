using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class StraightProjectile : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	[SerializeField] private GameObject player;

	public float moveSpeed;
	public int damageAmount;
	public GameObject projectileEffect;	// Particle effect that is Instantiated when the projectile is fired

	[ToggleGroup("isSlimeBall", order:2, groupTitle: "Slime Ball")]
	[SerializeField] private bool isSlimeBall;
	[ToggleGroup("isSlimeBall")]public GameObject slimeEnemy;

	[SerializeField] Shake shake;

	#endregion

	void Awake(){

		// Find refernce to the player
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Use this for initialization
	void Start () {
		// Get reference to the Shake Component
		shake = FindObjectOfType<Shake>();

	}
	
	// Update is called once per frame
	void Update () {

		// If the player IS alive, do the thing
		if (player != null) {
			// Move the projectile straight up
			transform.position += transform.up * moveSpeed * Time.deltaTime;
		}
		if (player == null) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D other){
		// If the player IS alive
		if (player != null){
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
	}

	void DestroyProjectile(){
		// Instantiate a particle effect
		GameObject effect = Instantiate(projectileEffect, transform.position, Quaternion.identity) as GameObject;

		// Call the CamShake function
		shake.CamShake ();

		// If this projectile IS a slimeBall object, give it a random chance to instantiate a slime enemy when it is destroyed
		if (isSlimeBall) {
			int randomNum;
			GameObject slime;

			// Set the random number equal to a random number between 1 and 6
			randomNum = Random.Range (1, 7);

			// CLEAN THIS UP LATER

			#region RANDOM NUMBER IF STATEMENTS

			if (randomNum == 1) {
				Debug.Log ("No slime enemy dropped...");
			}

			if (randomNum == 2) {
				slime = Instantiate (slimeEnemy, transform.position, Quaternion.identity) as GameObject;
			}

			if (randomNum == 3) {
				Debug.Log ("No slime enemy dropped");
			}

			if (randomNum == 4) {
				Debug.Log ("No slime enemy dropped");
			}

			if (randomNum == 5) {
				Debug.Log ("No slime enemy dropped");
			}

			if (randomNum == 6) {
				Debug.Log ("No slime enemy dropped");
			}

			if (randomNum == 7) {
				Debug.Log ("No slime enemy dropped");
			}

			#endregion
				
		}

		// Destroy the Particle Effect after 1 second.
		Destroy(effect, 1f);
		// Destroy this gameObject
		Destroy(gameObject);
	}
}
