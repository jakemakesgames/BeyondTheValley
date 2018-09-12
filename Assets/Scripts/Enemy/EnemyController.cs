using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;

public class EnemyController : MonoBehaviour {
	
	#region COMPONENTS AND VARIABLE
	[Header("Base Variables")]

	private Room room;

	[SerializeField]private Transform target;
	public EnemyScriptable eS;

	public enum type{ ranged, aggressive, slime};
	public type enemyType;

	public float speed;

	[FoldoutGroup("Ranged AI")]
	[Header ("Variables")]
	[FoldoutGroup("Ranged AI")] public float stoppingDistance;
	[FoldoutGroup("Ranged AI")] public float retreatDistance;
	[FoldoutGroup("Ranged AI")] private float timeBetweenShots;
	[FoldoutGroup("Ranged AI")] public float startTimeBetweenShots;
	[FoldoutGroup("Ranged AI")] public GameObject projectile;
	[FoldoutGroup("Ranged AI")] bool canShoot = true;

	[FoldoutGroup("Slime AI")]
	[Header("Variables")]
	[FoldoutGroup("Slime AI")] public bool isSlime;
	[FoldoutGroup("Slime AI")] public GameObject smallSlime;

	//[Header("Boss Entity Variables")]
	[ToggleGroup("isBossEntity", order:2, groupTitle: "Boss Entity")]
	//public bool BossToggle;
	public bool isBossEntity;
	[ToggleGroup("isBossEntity")] public List<GameObject> moveSpot;
	[ToggleGroup("isBossEntity")] public int randSpot;
	[ToggleGroup("isBossEntity")] private float waitTime;
	[ToggleGroup("isBossEntity")] public float startWaitTime;

	#endregion

	void Awake(){
		room = FindObjectOfType<Room> ();

		room.enemiesInRoom.Add (gameObject);
	}

	void Start(){

		#region REFERENCING COMPONENTS/ SETTING VALUES
		// Get reference to the Player GameObject
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();;

		// Call the EnemyTypeCheck function
		//EnemyTypeCheck ();
		if(!isBossEntity){
			speed = eS.enemyMovementSpeed;
		}
		// Set the timeBetweenShots value equal to the startTimeBetweenShots value
		timeBetweenShots = startTimeBetweenShots;
		#endregion

		#region SETTING BOSS ENTITY VALUES
		// If this enemy IS a boss entity
		if (isBossEntity){
			// Set the wait time's value equal to the startWaitTime's value
			waitTime = startWaitTime;

			// For each GameObject with the Tag "MoveSpot" in the scene -> add it to the moveSpot list
			foreach (GameObject spot in GameObject.FindGameObjectsWithTag("MoveSpot")) {
				moveSpot.Add(spot);
			}


			// Set the random spot equal to a random posiion between zero and the max count of the move spots list
			randSpot = Random.Range(0, moveSpot.Count);
		}

		#endregion
	}

	// This Function serves the purpose of checking which type this enemy is - this will set the variable values and type specific parameters
	/*
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
		} else if (enemyType == type.slime){
			// Check if the type of this enemy is a Slime
			Debug.Log("I am Slime");
		}

		#endregion
	}
	*/

	void Update(){

		if (!isBossEntity) {
			// If the target does not exist
			if (target == null) {
				// Destroy the Object
				HardDestroy();
			}

			#region ENEMY TYPE CHECK
			if (enemyType == type.ranged) {

				// Call the RangedBehaviour function. This function contains all of the code needed to move the Ranged AI as intended (ie Moving/ Retreating and Shooting)
				RangedBehaviour();

			} else if (enemyType == type.aggressive) {

				// Call the AggressiveBehaviour function. This function contains all of the code needed to move the Aggressive AI as intended.
				AggressiveBehaviour ();
			}
			#endregion

		}

		#region IF THIS ENEMY IS A BOSS ENTITY
		// Add this into an enemy type later on, call type checks etc.
		if (isBossEntity) {
			// If the player is still alive
			if (target != null) {
				transform.position = Vector2.MoveTowards (transform.position, moveSpot[randSpot].transform.position, speed * Time.deltaTime);

				// If the enemy HAS reached the random position, move to another
				if (Vector2.Distance(transform.position, moveSpot[randSpot].transform.position) < 0.2f){
					// If the wait time is less than OR equal to zero
					if (waitTime <= 0) {
						// Set the random spot equal to a random posiion between zero and the max count of the move spots list
						randSpot = Random.Range(0, moveSpot.Count);
						waitTime = startWaitTime;
					} else {
						// Slowly decrease Time.delatTime from the waitTime value
						waitTime -= Time.deltaTime;
					}
				}

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
		}
		#endregion
	}

	void AggressiveBehaviour(){
		// Move the Enemy towards the player
		if (target != null){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}


	void RangedBehaviour(){
		
		#region MOVEMENT BEHAVIOURS
		// If the player is still alive
		if (target != null){
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
		}

		#endregion

		#region SHOOTING BEHAVIOURS
		if (target != null){
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
		}

		#endregion
	}

	public void SlimeSplit(){
		GameObject smallSlimeOBJ = Instantiate (smallSlime, transform.position, Quaternion.identity) as GameObject;
		GameObject smallSlimeOBJ2 = Instantiate (smallSlime, transform.position, Quaternion.identity) as GameObject;
	}

	void HardDestroy(){
		Destroy (gameObject);
	}

}
