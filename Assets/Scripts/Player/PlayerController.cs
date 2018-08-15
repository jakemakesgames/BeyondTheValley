using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	// Unity Components
	[SerializeField] private Rigidbody2D rb2D;
	public XboxController controller;

	[Header("Movement Speed Variables")]
	public float movementSpeed;
	public float maxSpeed;

	// Keyboard Variables
	private Vector2 moveVelocity;

	// Gamepad Variables
	[Header("Gamepad Variables")]
	private Vector2 moveVelocityAlt;

	// Gamepad Detection
	private int gamepad = 0;
	public bool usingGamepad;

	[Header("Projectile Prefabs")]
	public GameObject projectileOBJ;
	public GameObject bombOBJ;

	[Header("Shooting Timers")]
	private float shootingTimer; // shootingTimer does need to be a public variable
	public float timeBetweenShots;

	void Start(){

		// The rb2D varible is set the to Rigidbody 2D component on the Player GameObject
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		#region MOVEMENT

		/* -----> THINK ABOUT PUTTING THIS ON THE GAME MANAGER (WHICH WILL BE "DONT DESTROY ON LOAD"), THIS WILL CLEAN UP THIS SCRIPT A LITTLE MORE
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

			#region DIAGONAL SHOOTING
			// If the Up Arrow AND the Right Arrow are being held at the same time
			if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightArrow)))
			{
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots)
				{
					// Instantiate the projectile prefab at -45 on the Z axis.
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, -45f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			}

			// If the Up Arrow AND the Left Arrow are being held at the same time
			if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow)))
			{
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots)
				{
					// Instantiate the projectile prefab at 45 on the Z axis.
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 45f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			}

			// If the Down Arrow AND the Right Arrow are being held at the same time
			if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightArrow)))
			{
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots)
				{
					// Instantiate the projectile prefab at -135 on the Z axis
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, -135f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			}

			// If the Down Arrow AND the Left Arrow are being held at the same time
			if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow)))
			{
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots)
				{
					// Instantiate the projectile prefab at 135 on the Z axis
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, 135f));
					// Reset the timer
					shootingTimer = Time.time;
				}
			}
			#endregion

			#region STRAIGHT SHOOTING
			 
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
			#endregion

			#region DROPPIN' BOMBS
			// If the player presses the Spacebar -> Do the thing
			if (Input.GetKeyDown(KeyCode.Space)){
				// Instantate the Bomb
				GameObject bomb = Instantiate(bombOBJ, transform.position, Quaternion.identity);
			}
				
			#endregion

			}
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
