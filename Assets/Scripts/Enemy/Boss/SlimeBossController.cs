using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlimeBossController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	[Header("Encounter Countdown Timer")]
	public float countdown;

	[Header("Movement Variables")]
	public float speed;
	public GameObject player;

	[Header("Projectiles")]
	public GameObject slimeEnemy;
	public GameObject slimeBall;
	public GameObject slimeStraight;

	[Header("Shooting Timer")]
	private float shootingTimer;
	public float timeBetweenShots;
	public float newTimeBetweenShots;
	#endregion

	#region STATES
	public enum State {idle, angry, rage, lastStand};
	public State bossState;
	#endregion

	public void Update(){

		// Start taking time.delta time from the countdown variable
		countdown -= Time.deltaTime;

		// if countdown is less than or equal to zero
		if (countdown <= 0) {

			#region PHASE 1 - THE IDLE STATE
			// If the BossState is equal to State.idle
			if (bossState == State.idle){
				Debug.Log("Current State: " + bossState);
				// If Time.time - shooting timer is less than the Time Between Shots value
				if (Time.time - shootingTimer > timeBetweenShots){
					// Shoot a slime enemy projectile
					GameObject slimeEnemProj = Instantiate(slimeEnemy, transform.position, Quaternion.identity) as GameObject;
					Debug.Log("Slime Enemy Shot");
					// Reset the timer
					shootingTimer = Time.time;
				}
			}
			#endregion

			#region PHASE 2 - THE ANGRY STATE
			if (bossState == State.angry){
				Debug.Log("Current State: " + bossState);
				timeBetweenShots = newTimeBetweenShots;
				// if the shooting timer is less than the timeBetweenShots value
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Instantiate the slimeball prefab
					GameObject slimeballOBJ = Instantiate (slimeBall, transform.position, Quaternion.identity);
					Debug.Log ("Shot Right");
					shootingTimer = Time.time;
					}
			}
			#endregion

			#region PHASE 3 - THE RAGE PHASE
			if (bossState == State.rage) {
				Debug.Log ("Current State: " + bossState);
				// NOTE: WHEN THESE BULLETS DESTROY IN THIS STATE, INSTANTIATE A SLIMEY BOI IN THEIR PLACE
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Instantiate the projectile prefab at 135 on the Z axis
					GameObject projUP = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 0.0f)); // The Random Range creates a bullet spread effect
					GameObject projDOWN = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 180.0f));
					GameObject projLEFT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 90.0f));
					GameObject projRIGHT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 270.0f));
					shootingTimer = Time.time;
				} 
			}
			#endregion

			#region PHASE 4 - THE LAST STAND
			if (bossState == State.lastStand){
				Debug.Log ("Current State: " + bossState);
				timeBetweenShots = newTimeBetweenShots;
				if (Time.time - shootingTimer > timeBetweenShots){
					GameObject projUP = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 0.0f));
					GameObject projUPLEFT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 45.0f));

					GameObject projDOWN = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 180.0f));
					GameObject projDOWNLEFT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 135.0f));

					GameObject projLEFT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 90.0f));
					GameObject projRIGHT = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, 270.0f));

					GameObject projRIGHTUP = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, -45.0f));
					GameObject projRIGHTDOWN = Instantiate (slimeStraight, transform.position, Quaternion.Euler (0.0f, 0.0f, -135.0f));

					shootingTimer = Time.time;
				}
			}
			#endregion
	}

	/*
	PHASES


	PHASE 3 - REPEAST PHASE 2 THOUGH THIS TIME THE BOSS SHOOTS SLIME BALLS AT THE
				PLAYER'S POSITION

	PHASE 4 - BOSS BOUNCES TOWARDS THE PLAYER, SHOOTING IN 4 DIRECTIONS 
				( THE SKIME BALLS TURN INTO SLIME ENEMIES ON IMPACT WITH WALLS)

	PHASE 5 - REPEAT PHASE 4 BUT THE BOSS MOVES SLIGHTY QUICKER AND SHOOTS IN 8
				DIRECTIONS


	*/
	}
}
