using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	[Header("Base Variables")]
	[SerializeField]private Transform target;
	public EnemyScriptable eS;

	public enum type{ ranged, aggressive };
	public type enemyType;

	public float speed;

	[Header ("Ranged AI Variables")]
	public float stoppingDistance;
	public float retreatDistance;

	private float timeBetweenShots;
	public float startTimeBetweenShots;
	public GameObject projectile;
	bool canShoot = true;

	#endregion

	void Start(){

		#region REFERENCING COMPONENTS/ SETTING VALUES
		// Get reference to the Player GameObject
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();;

		// Call the EnemyTypeCheck function
		EnemyTypeCheck ();
		speed = eS.enemyMovementSpeed;

		// Set the timeBetweenShots value equal to the startTimeBetweenShots value
		timeBetweenShots = startTimeBetweenShots;
		#endregion
	}

	// This Function serves the purpose of checking which type this enemy is - this will set the variable values and type specific parameters
	void EnemyTypeCheck(){

		#region DEBUGGING CHECKS -> DELETE LATER

		if (enemyType == type.ranged) {
			// Check if the type of this enemy is Ranged
			Debug.Log ("I am Ranged");

			// Do the Ranged Enemy Stuff here
			// SHOOT AT PLAYER, FLEE WHEN PLAYER GETS CLOSE

		} else if (enemyType == type.aggressive) {
			// Check if the type of this enemy is Aggressive
			Debug.Log ("I am Aggressive");
		}

		#endregion
	}

	void Update(){

		#region ENEMY TYPE CHECK
		if (enemyType == type.ranged) {
			
			// Call the RangedBehaviour function. This function contains all of the code needed to move the Ranged AI as intended (ie Moving/ Retreating and Shooting)
			RangedBehaviour();

		} else if (enemyType == type.aggressive) {
			
			// Call the AggressiveBehaviour function. This function contains all of the code needed to move the Aggressive AI as intended.
			AggressiveBehaviour ();
		}
		#endregion

		// If the target does not exist
		if (target == null) {
			// Destroy the Object
			HardDestroy();
		}
	}

	void AggressiveBehaviour(){
		// Move the Enemy towards the player
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

	void RangedBehaviour(){
		
		#region MOVEMENT BEHAVIOURS
		// If the distance between the enemy's position and the player's position is GREATER THAN the stopping distance -> Do the thing
		if (Vector2.Distance (transform.position, target.position) > stoppingDistance) {
			// Move the enemy from their current position to the player's position at the speed pace multiplied by Time.deltaTime
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			// Else if the distance between the enemy's position and the player's position is LESS THAN the stopping distance and they aren't too close to the player -> Do the thing 
		} else if (Vector2.Distance (transform.position, target.position) < stoppingDistance && Vector2.Distance (transform.position, target.position) > retreatDistance) {
			// Make the enemy STOP moving
			transform.position = this.transform.position;
		// Else if the distance betwen the enemy's position and the player's position is less than the retreat distance -> Do the thing
		} else if (Vector2.Distance (transform.position, target.position) < retreatDistance) {
			// Move the enemy away from the player at the speed pace multiplied by Time.deltaTime
			transform.position = Vector2.MoveTowards (transform.position, target.position, -speed * Time.deltaTime);
		}
		#endregion

		#region SHOOTING BEHAVIOURS

		if (canShoot){
			// If the timeBetweenShots value is LESS THAN or equal to 0 -> Do the thing
			if (timeBetweenShots <= 0) {
				// Instantiate a projectile at 0, 0, 0
				Instantiate(projectile, transform.position, Quaternion.identity);
				//Reset the shooting timer
				timeBetweenShots = startTimeBetweenShots;
				// Else subtract Time.deltaTime from the timeBetweenShots value
			} else {
				timeBetweenShots -= Time.deltaTime;
			}
		}
		#endregion
	}

	void HardDestroy(){
		Destroy (gameObject);
	}

}
