using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	/*
	#region OLD CODE
	[SerializeField] private PlayerController playerController;

	private Vector2 target;
	// The movement speed of the projectile
	public float speed;
	// The damage amount the projectile inflicts
	public int damageAmount;
	// The score amount the player recieves when the projectile collides with an enemy
	public int scoreAmount;

	private bool canDestroy;

	[SerializeField] private GameObject targetAlt;

	void Start(){

		// Find reference to the player Controller script on the player
		playerController = FindObjectOfType<PlayerController> ();

		targetAlt = GameObject.FindGameObjectWithTag ("Cursor");

		if (playerController.usingGamepad) {
			// Change the target pos to crosshair
			target = targetAlt.transform.position;
			canDestroy = true;
		} else {
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			canDestroy = true;
		}
	}


	void Update(){
		// Move the Projectile towards the cursor
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if (transform.position.x == target.x && transform.position.y == target.y) {
			if (canDestroy) {
				DestroyProjectile ();
			}
		}
	}

	void DestroyProjectile(){
		canDestroy = false;
		Destroy (gameObject, 0.1f);
	}
	#endregion
	*/

	public int damageAmount;

	private float lockPos = 0;

	[SerializeField] private float moveSpeed;

	void Update(){

		transform.Rotate (lockPos, lockPos, lockPos);

		// When the projectile is instantaited, move the object by the moveSpeed variable multiplied by Time.deltaTime
		transform.position += transform.forward * moveSpeed * Time.deltaTime;

		Destroy (gameObject, 5f);
	}
		
	void DestroyProjectile(){
		Destroy (gameObject, 0.1f);
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the projectile collides with another GameObject tagged "Enemy" -> Destroy both objects
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().TakeDamage (damageAmount);
			//Destroy (other.gameObject);
			DestroyProjectile ();
		}
	}
}
