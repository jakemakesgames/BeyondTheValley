using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	public EnemyScriptable eS;

	public enum type{ neutral, ranged, aggressive, splitter };
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
		if (enemyType == type.neutral) {
			// Check if the type of this enemy is Neutral
			Debug.Log ("I am Neutral");

		} else if (enemyType == type.ranged) {
			// Check if the type of this enemy is Ranged
			Debug.Log ("I am Ranged");

			// Do the Ranged Enemy Stuff here
			// SHOOT AT PLAYER, FLEE WHEN PLAYER GETS CLOSE

		} else if (enemyType == type.aggressive) {
			// Check if the type of this enemy is Aggressive
			Debug.Log ("I am Aggressive");
		} else if (enemyType == type.splitter) {
			// Check if the type of this enemy is Splitter
			Debug.Log("I am a Splitter");
		}
	}

	void Update(){
		if (enemyType == type.neutral) {
			
			// Call the NuetralBehaviour function. This function contains all of the code needed to move the
			// Nuetral AI as intended.
			NeutralBehaviour ();

		} else if (enemyType == type.ranged) {
			
			// SHOOT AT PLAYER, FLEE WHEN PLAYER GETS CLOSE

		} else if (enemyType == type.aggressive) {
			
			// Call the AggressiveBehaviour function. This function contains all of the code needed to move the
			// Aggressive AI as intended.
			AggressiveBehaviour ();
		} else if (enemyType == type.splitter) {
			AggressiveBehaviour ();
		}
	}

	void NeutralBehaviour(){
		// If the distance between the enemy and player is greater than the move range float, move towards the player.
		if (Vector2.Distance (transform.position, target.position) > moveRange) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}

	void AggressiveBehaviour(){
		// Move the Enemy towards the player
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

}
