using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	public EnemyScriptable eS;

	public enum type{ ranged, aggressive };
	public type enemyType;

	//public bool canDropItem;

	public float speed;
	public float moveRange;

	void Start(){
		// Get reference to the Player GameObject
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();;

		// Call the EnemyTypeCheck function
		EnemyTypeCheck ();
		speed = eS.enemyMovementSpeed;
		moveRange = eS.enemyMoveRange;
		//canDropItem = eS.enemyCanDropItem;
	}

	// This Function serves the purpose of checking which type this enemy is - this will set the variable values and type specific parameters
	void EnemyTypeCheck(){
		
		if (enemyType == type.ranged) {
			// Check if the type of this enemy is Ranged
			Debug.Log ("I am Ranged");

			// Do the Ranged Enemy Stuff here
			// SHOOT AT PLAYER, FLEE WHEN PLAYER GETS CLOSE

		} else if (enemyType == type.aggressive) {
			// Check if the type of this enemy is Aggressive
			Debug.Log ("I am Aggressive");
		}
	}

	void Update(){
		
		if (enemyType == type.ranged) {
			
			// SHOOT AT PLAYER, FLEE WHEN PLAYER GETS CLOSE

		} else if (enemyType == type.aggressive) {
			
			// Call the AggressiveBehaviour function. This function contains all of the code needed to move the
			// Aggressive AI as intended.
			AggressiveBehaviour ();
		} 
	}

	void AggressiveBehaviour(){
		// Move the Enemy towards the player
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

}
