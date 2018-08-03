using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private Vector2 target;
	// The movement speed of the projectile
	public float speed;
	// The damage amount the projectile inflicts
	public int damageAmount;
	// The score amount the player recieves when the projectile collides with an enemy
	public int scoreAmount;

	private bool canDestroy;

	void Start(){
		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		canDestroy = true;
	}

	void Update(){
		// Move the Projectile towards the cursor
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

	}


}
