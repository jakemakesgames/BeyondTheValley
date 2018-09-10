using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SlimeBossController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	[Header("Encounter Countdown Timer")]
	public float countdown;

	[Header("Projectiles")]
	public GameObject slimeEnemy;
	//public GameObject slimeBall;

	[Header("Shooting Timer")]
	private float shootingTimer;
	public float timeBetweenShots;
	#endregion

	#region STATES
	public enum State {idle, irritated, angry, rage, lastStand};
	public State bossState;
	#endregion

	public void Update(){

		countdown -= Time.deltaTime;

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

			if (bossState == State.irritated){
				Debug.Log("Current State: " + bossState);
			}


			#endregion
		}
	}

	/*
	PHASES

	PHASE 1 - BOSS STAYS STATIC, SHOOTS SLIME ENEMIES OUT AT RANDOM DIRECTIONS
			- SLIME ENEMIES WORK AS USUAL ENEMIES DO (BREAK DOWN INTO SMALLER
				ENEMIES ONCE THEY'RE KILLED)

	PHASE 2 - BOSS STAYS STATIC THOUGH THE SLIMES THAT ARE SHOT OUT START MOVING
				TOWARDS THE PLAYER, QUICKER THAN THE PREVIOUS PHASE

	PHASE 3 - REPEAST PHASE 2 THOUGH THIS TIME THE BOSS SHOOTS SLIME BALLS AT THE
				PLAYER'S POSITION

	PHASE 4 - BOSS BOUNCES TOWARDS THE PLAYER, SHOOTING IN 4 DIRECTIONS 
				( THE SKIME BALLS TURN INTO SLIME ENEMIES ON IMPACT WITH WALLS)

	PHASE 5 - REPEAT PHASE 4 BUT THE BOSS MOVES SLIGHTY QUICKER AND SHOOTS IN 8
				DIRECTIONS


	*/
}
