using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private PlayerController playerController;

	private Vector2 target;
	// The movement speed of the projectile
	public float speed;
	// The damage amount the projectile inflicts
	public int damageAmount;
	// The score amount the player recieves when the projectile collides with an enemy
	public int scoreAmount;

	private Vector3 direction;

	private bool canDestroy;

	[SerializeField] private GameObject targetAlt;

	void Start(){

		// Find reference to the player Controller script on the player
		playerController = FindObjectOfType<PlayerController> ();

		targetAlt = GameObject.FindGameObjectWithTag ("Cursor");

		if (playerController.usingGamepad) {
			// Change the target pos to crosshair
			target = targetAlt.transform.position;
		} else {
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			canDestroy = true;
		}
	}

	public void Fire(Vector3 directionToShoot){
		direction = directionToShoot;
	}

	void Update(){
		// Move the Projectile towards the cursor
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

	}
}
