﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	// Components
	private Rigidbody2D rb2D;
	public XboxController controller;

	[Header("Movement Speed Variables")]
	public float movementSpeed;
	public float maxSpeed;

	// Keyboard Variables
	private Vector2 moveVelocity;

	[Header("Gamepad Variables")] // Gamepad Variables
	private Vector2 moveVelocityAlt;
	// Gamepad Detection
	private int gamepad = 0;
	public bool usingGamepad;


	[Header("Ranged Attack Variables")]
	public GameObject projectileOBJ;

	// Shooting Variables
	[SerializeField] private float shootingTimer;
	public float timeBetweenShots;

	/*
	private Vector3 target;

	[SerializeField] private Transform playerPos;  

	// The position in which the projectile is instantiated
	public GameObject shotPos;*/

	void Start(){

		// The rb2D varible is set the to Rigidbody 2D component on the Player GameObject
		rb2D = GetComponent<Rigidbody2D> ();

		// Setting Ranged Attack Variables
		//playerPos = GetComponent<Transform> ();
		//shootingTimer = Time.time;
		//shotPos = GameObject.FindGameObjectWithTag ("shotPos");

	}

	void Update(){

		#region MOVEMENT

		/*
		#region Gamepad Detection
		string[] names = Input.GetJoystickNames();
		for (int i = 0; i < names.Length; i++) {
			// A Gamepad has been connected
			if (names[i].Length == 33){
				Debug.Log("XBOX 360 CONTROLLER DETECTED");
				gamepad = 1;
				usingGamepad = true;
			}

			// A Gamepad has been disconnected
			if (names[i].Length != 33){
				Debug.Log("XBOX 360 CONTROLLER DISCONNECTED");
				gamepad = 0;
				usingGamepad = false;
			}
		}

		#endregion
		*/


		if (usingGamepad) {
			#region Gamepad Input
			Vector2 moveInputAlt = new Vector2 (XCI.GetAxis (XboxAxis.LeftStickX), XCI.GetAxis (XboxAxis.LeftStickY));
			moveVelocityAlt = moveInputAlt.normalized * movementSpeed;
			#endregion

			/*
			#region Gamepad Ranged Attack
			// If the Right Trigger is being held down (Do the thing)
			if (XCI.GetAxis(XboxAxis.RightTrigger) > 0.1f){
				// If Time.time minus the shootingTimer variable is GREATER THAN the timeBetweenShots varibale
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Call the Shoot function
					//Shoot();
					// Reset the shooting timer
					shootingTimer = Time.time;
				}
			}

			#endregion
			*/

		} else {
			#region Keyboard Input
			// The moveInput Vector2 is equal to a new Vector2 - The Horizontal Axis (for X axis movement), and The Vertical Axis (for Y axis movement)
			// Left = -1 | Right = 1 | Up = 1 | Down = -1 (Use GetAxisRaw for snappier movements)
			Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Hori"), Input.GetAxisRaw ("Vert"));
			// Set the moveVelocity equal to the moveInput multiplied by the movementSpeed variable (Normalized so the speed is the same in all directions)
			moveVelocity = moveInput.normalized * movementSpeed;
			#endregion

			// SHOOTING WITH THE ARROW KEYS
			#region Shooting With Arrow Keys

			bool shoot = false;
			Vector3 direction = transform.position;

			// If the Up Arrow is being held down
			if (Input.GetKey(KeyCode.UpArrow)){
				// Set the direction vector += to Vector3.forward
				direction += Vector3.up;
				// Shoot bool is equal to true
				shoot = true;
				Debug.Log("Up Vector: " + direction);
			}

			// If the Right Arrow is being held down
			if (Input.GetKey(KeyCode.RightArrow)){
				// Set the direction vector += to Vector3.right
				direction += Vector3.right;
				// Shoot bool is equal to true
				shoot = true;
				Debug.Log("Right Vector: " + direction);

			}

			if (shoot == true && direction != transform.position){
				Vector3 relativePos = direction - transform.position;
				Quaternion rotation = Quaternion.LookRotation(relativePos);

				GameObject projectile = Instantiate(projectileOBJ, transform.position, rotation);
				//GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(direction.x, direction.y, direction.z));
				//shoot = false;
				//direction = Vector3.zero;
			}


			/*
			 OLD SHOOTING CODE
			// Replace this later with the option to hold the key down and shoot on a fixed timer (This can be tweaked with a temporary upgrade later on)
			// If the UP ARROW is being held down, Instantiate a bullet with the rotation of 0, 0, 0.
			if (Input.GetKey(KeyCode.UpArrow)){
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			// Else If the RIGHT ARROW is being held down, Instantiate a bullet with the rotation of 0, 0, 270.
			} else if (Input.GetKey(KeyCode.RightArrow)){
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 270.0f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			// Else If the DOWN ARROW is being held down, Instantiate a bullet with the rotation of 0, 0, 180.
			} else if (Input.GetKey(KeyCode.DownArrow)){
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 180.0f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			// If the Left ARROW is pressed, Instantiate a bullet with the rotation of 0, 0, 270.
			} else if (Input.GetKey(KeyCode.LeftArrow)){
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 90.0f));
					// Reset the timer
					shootingTimer = Time.time;
					}
				}
			*/




			}

			#endregion

			// Old code using the mouse to shoot
			/*
			#region Mouse Ranged Attack

			// If the left mouse button is clicked (Do the thing)
			if (Input.GetMouseButton(0)){
				// If Time.time minus the shootingTimer variable is GREATER THAN the timeBetweenShots varibale
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Call the Shoot function
					Shoot();
					// Reset the shooting timer
					shootingTimer = Time.time;
				}
			}
			#endregion
			*/
		}

		#endregion

	void FixedUpdate(){

		#region MOVEMENT PHYSICS

		if (usingGamepad) {
			// Gamepad Move Player
			rb2D.MovePosition (rb2D.position + moveVelocityAlt * Time.fixedDeltaTime);
		} else {
			// Keyboard Move Player
			rb2D.MovePosition (rb2D.position + moveVelocity * Time.fixedDeltaTime);
		}

		#endregion
	}

}
