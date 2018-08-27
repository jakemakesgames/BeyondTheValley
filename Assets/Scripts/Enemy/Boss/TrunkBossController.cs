using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EnemyHealthManager))]
public class TrunkBossController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	// Projectile Transforms
	[Header("Projectile Transforms")]
	public GameObject mainHead;

	public GameObject leftHead;
	public bool hasLeftHead;

	public GameObject rightHead;
	public bool hasRightHead;

	// Health Components
	[Header("Health Components")]
	public EnemyHealthManager enemyHealthManager;

	// Objects for the Boss To Instantiate
	[Header("Objects To Instantiate")]
	public GameObject projectile;
	public GameObject lHead;
	public GameObject rHead;
	public bool headsSpawned = false;

	public Transform target;

	public float speed;
	[SerializeField] private float angryMoveSpeed; // Set these in the inspector and change the value of the public speed variable above to match these values
	[SerializeField] private float lastStandSpeed;

	// Shooting Timers
	[Header("Shooting Timers")]
	private float shootingTimer; // shootingTimer does need to be a public variable
	public float timeBetweenShots;

	#endregion

	#region STATES
	public enum State {idle, angry, lastStand};
	public State bossState;

	#endregion

	void Awake(){
		// Getting a reference to the head transforms
		mainHead = GameObject.FindGameObjectWithTag ("Head");
		leftHead = GameObject.FindGameObjectWithTag ("LHead");
		rightHead = GameObject.FindGameObjectWithTag ("RHead");

		target = GameObject.FindGameObjectWithTag ("Player").transform;


		//enemyHealthManager = GetComponent<EnemyHealthManager> ();
	}

	void Start(){
		bossState = State.idle;
		Debug.Log (bossState);
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
					GameObject projectileOBJR = Instantiate (projectile, rightHead.transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (-130.0f, -140.0f))); // The Random Range creates a bullet spread effect
					Debug.Log ("Shot Right");
					// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
					if (Time.time - shootingTimer > timeBetweenShots) {
						// Instantiate the projectile prefab at 135 on the Z axis
						GameObject projectileOBJL = Instantiate (projectile, leftHead.transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (130.0f, 140.0f))); // The Random Range creates a bullet spread effect
						Debug.Log ("Shot Left");
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
		if (bossState == State.angry){
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

			if (target != null){
				transform.position = Vector2.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			}


		}
		#endregion

	}
}

