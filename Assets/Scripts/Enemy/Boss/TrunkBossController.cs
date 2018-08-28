using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TrunkBossController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	// Projectile Transforms
	[Header("Projectile Transforms")]
	public GameObject mainHead;	// The GameObject component of the Boss' Main Head, this will come into play during PHASE 2

	public GameObject leftHead;	// The GameObject component of the Boss' Left Head, used during PHASE 1, while the two heads can shoot
	public bool hasLeftHead; // Check to see if the Boss HAS his left head

	public GameObject rightHead; // The GameObject component of the Boss' Right Head, used during PHASE 1, while the two heads can shoot
	public bool hasRightHead; // Check to see if the Boss HAS his right head

	// Health Components
	[Header("Health Components")]
	public EnemyHealthManager enemyHealthManager;

	// Objects for the Boss To Instantiate
	[Header("Objects To Instantiate")]
	public GameObject projectile; // The projectile the heads will be shooting during PHASE 1, make this a List later and randomly choose which gameObject to instantiate
	public GameObject lHead; // Head which instantiate during PHASE 2
	public GameObject rHead; // Head which instantiate during PHASE 2
	public bool headsSpawned = false;
	public GameObject bulletHellProj; // Final Phase Projectile
	public bool shootStraight;
	public bool shootDiag;

	[Header("Movement Variables")]
	[SerializeField] private Transform target; // The Target is the GameObject the Boss will move towards, in this case it is the PLAYEr

	public float speed;
	[SerializeField] private float angryMoveSpeed; // Set these in the inspector and change the value of the public speed variable above to match these values
	[SerializeField] private float lastStandSpeed;


	// Shooting Timers
	[Header("Shooting Timers")]
	private float shootingTimer; // shootingTimer does need to be a public variable
	public float timeBetweenShots;

	#endregion

	#region STATES
	public enum State {idle, angry, rage, lastStand};
	public State bossState;
	public State curState;

	#endregion

	void Awake(){
		// Getting a reference to the head transforms
		mainHead = GameObject.FindGameObjectWithTag ("Head");
		leftHead = GameObject.FindGameObjectWithTag ("LHead");
		rightHead = GameObject.FindGameObjectWithTag ("RHead");

		target = GameObject.FindGameObjectWithTag ("Player").transform;

		curState = bossState;
		Debug.Log (curState);
		//enemyHealthManager = GetComponent<EnemyHealthManager> ();
	}

	void Start(){
		bossState = State.idle;
		Debug.Log (bossState);

		shootStraight = true;
		shootDiag = false;
	}

	void Update ()
	{
		// Do Phase 1 Here
		#region PHASE 1 - THE IDLE STATE
		// If the Boss State is Equal to Idle -> Do the thing
		if (bossState == State.idle){
			Debug.Log("Current State: " + bossState);
			// If the Boss has both of his heads
			if (hasRightHead && hasLeftHead) {
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Instantiate the projectile prefab at 135 on the Z axis
					GameObject projectileOBJR = Instantiate (projectile, rightHead.transform.position, Quaternion.identity);
					Debug.Log ("Shot Right");
					// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
					if (Time.time - shootingTimer > timeBetweenShots) {
						// Instantiate the projectile prefab at 135 on the Z axis
						GameObject projectileOBJL = Instantiate (projectile, leftHead.transform.position, Quaternion.identity);
						Debug.Log("Shot Left");
						// Reset the timer
						shootingTimer = Time.time;
					}
				}
			}
		}
		#endregion

		// Do Phase 2 Here
		#region PHASE 2 - THE ANGRY PHASE
		// If the Boss State is equal to Angry -> Do The Thing
		else if (bossState == State.angry){
			// Set the hasLeftHead & hasRightHead bool to FALSE
			hasLeftHead = false;
			hasRightHead = false;
			Debug.Log("Current State: " + bossState);
			// If the Boss does NOT have the left & right heads -> Do The Thing
			if (!hasRightHead && !hasLeftHead){
				// If the Boss has NOT spawned the heads -> Spawn Heads
				if (!headsSpawned){
					GameObject leftHeadGO = Instantiate (lHead, leftHead.transform.position, Quaternion.identity) as GameObject;
					GameObject rightHeadGO = Instantiate (rHead, rightHead.transform.position, Quaternion.identity) as GameObject;
					// Set the headsSpawned bool equal to TRUE (This means NO MORE HEADS can be spawned)
					headsSpawned = true;
				}
			}

			// Set the Original Heads Active false (This is only temporary as Animations/ Sprites will change later)
			leftHead.SetActive(false);
			rightHead.SetActive(false);

			speed = angryMoveSpeed;

			// If the Player is NOT null -> DO the thing
			if (target != null){
				// Move towards the player at the speed multiplied by Time.deltaTime
				transform.position = Vector2.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			}
			// Add the code for the Boss to shoot projectiles at the player during Phase 2
		}
		#endregion

		#region PHASE 3 - RAGE
		// If tge Boss State is equal to LastStand (PHASE 3)
		if (bossState == State.rage){

			// If the Player is NOT null -> Move towards the player
			if (target != null){
				// Move towards the player at the speed multiplied by Time.deltaTime
				transform.position = Vector2.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			}

			// Shoot towards the player from the Main Head
			if (Time.time - shootingTimer > timeBetweenShots) {
				// Instantiate the projectile prefab at 135 on the Z axis
				GameObject projectileOBJ = Instantiate (projectile, mainHead.transform.position, Quaternion.identity); // The Random Range creates a bullet spread effect
				Debug.Log ("Shot Right");
				shootingTimer = Time.time;
			}

		}
		#endregion

		#region PHASE 4 - LAST STAND
		if (bossState == State.lastStand){
			// Shoot out in all 4 directions?
			#region INSTANTIATE PROJECTILES
			// Instantiate UP
			if (shootStraight){
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Instantiate the projectile prefab at 135 on the Z axis
					GameObject projUP = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f)); // The Random Range creates a bullet spread effect
					GameObject projDOWN = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 180.0f));
					GameObject projLEFT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 90.0f));
					GameObject projRIGHT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 270.0f));
					shootingTimer = Time.time;
					shootDiag = true;
					shootStraight = false;
				}
			}

			if (shootDiag){
				if (Time.time - shootingTimer > timeBetweenShots && shootDiag) {

					// Instantiate the projectile prefab at 135 on the Z axis
					GameObject projUPLEFT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 45.0f)); // The Random Range creates a bullet spread effect
					GameObject projDOWNLEFT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, 135.0f));
					GameObject projUPRIGHT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, -45.0f));
					GameObject projDOWNRIGHT = Instantiate (bulletHellProj, mainHead.transform.position, Quaternion.Euler(0.0f, 0.0f, -135.0f));
					shootingTimer = Time.time;
					shootStraight = true;
					shootDiag = false;
				}
		
			}
			#endregion
		}
		#endregion
	}
}

