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
	public Transform mainHead;
	public Transform leftHead;
	public bool hasLeftHead;
	public Transform rightHead;
	public bool hasRightHead;

	// Health Components
	[Header("Health Components")]
	public EnemyHealthManager enemyHealthManager;

	// Objects for the Boss To Instantiate
	[Header("Objects To Instantiate")]
	public GameObject projectile;
	public GameObject lHead;
	public GameObject rHead;

	// Shooting Timers
	[Header("Shooting Timers")]
	private float shootingTimer; // shootingTimer does need to be a public variable
	public float timeBetweenShots;

	#endregion

	void Awake(){
		// Getting a reference to the head transforms
		mainHead = GameObject.FindGameObjectWithTag ("Head").transform;
		leftHead = GameObject.FindGameObjectWithTag ("LHead").transform;
		rightHead = GameObject.FindGameObjectWithTag ("RHead").transform;



		//enemyHealthManager = GetComponent<EnemyHealthManager> ();
	}

	void Update ()
	{
		
		if (hasRightHead && hasLeftHead) {

			// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
			if (Time.time - shootingTimer > timeBetweenShots) {
				// Instantiate the projectile prefab at 135 on the Z axis
				GameObject projectileOBJR = Instantiate (projectile, rightHead.transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (-130.0f, -140.0f))); // The Random Range creates a bullet spread effect
				Debug.Log ("Shot Right");

				if (Time.time - shootingTimer > timeBetweenShots) {
					GameObject projectileOBJL = Instantiate (projectile, leftHead.transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (130.0f, 140.0f))); // The Random Range creates a bullet spread effect
					Debug.Log ("Shot Left");
					// Reset the timer
					shootingTimer = Time.time;
				}
			}
		}
	}
}

