using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	#region COMPONENTS AND VARIABLES

	// Unity Components
	[SerializeField] private Rigidbody2D rb2D;
	public XboxController controller;

	// Movement Speed Variables
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

	// Projectile and Bomb Prefabs
	[Header("Projectile Prefabs")]
	public GameObject projectileOBJ;
	public GameObject projectileInst;	// Particle effect when the projectile is instantiated
	public GameObject bombOBJ;
	public int bombCount;
	public Text bombCountText;

	// Shooting Timers
	[Header("Shooting Timers")]
	private float shootingTimer; // shootingTimer does need to be a public variable
	public float timeBetweenShots;

	#endregion


	void Start(){

		#region REFERENCING COMPONENTS/ SETTING VALUES
		// The rb2D varible is set the to Rigidbody 2D component on the Player GameObject
		rb2D = GetComponent<Rigidbody2D>();

		// Set the bomb text to the bomb count
		bombCountText.text = bombCount.ToString();
		#endregion
	}

	void Update(){

		#region MOVEMENT

		if (usingGamepad) {
			#region Gamepad Input
			Vector2 moveInputAlt = new Vector2 (XCI.GetAxis (XboxAxis.LeftStickX), XCI.GetAxis (XboxAxis.LeftStickY));
			moveVelocityAlt = moveInputAlt.normalized * movementSpeed;
			#endregion

		} else {
			#region Keyboard Input
			// The moveInput Vector2 is equal to a new Vector2 - The Horizontal Axis (for X axis movement), and The Vertical Axis (for Y axis movement)
			// Left = -1 | Right = 1 | Up = 1 | Down = -1 (Use GetAxisRaw for snappier movements)
			Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Hori"), Input.GetAxisRaw ("Vert"));
			// Set the moveVelocity equal to the moveInput multiplied by the movementSpeed variable (Normalized so the speed is the same in all directions)
			moveVelocity = moveInput.normalized * movementSpeed;
			#endregion

			#endregion

			#region DIAGONAL SHOOTING

			// If the Up Arrow AND the Right Arrow are being held at the same time
			if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightArrow)))
			{
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots)
				{
					// Instantiate the projectile prefab at -45 on the Z axis.
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-40.0f, -50.0f))); // The Random Range creates a bullet spread effect
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
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(40.0f, 50.0f))); // The Random Range creates a bullet spread effect
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
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-130.0f, -140.0f))); // The Random Range creates a bullet spread effect
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
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(130.0f, 140.0f))); // The Random Range creates a bullet spread effect
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
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-2.0f, 2.0f))); // The Random Range creates a bullet spread effect
					// Reset the timer
					shootingTimer = Time.time;
				}
			// Else If the RIGHT ARROW is being held down, Instantiate a bullet with the rotation of 0, 0, 270.
			} else if (Input.GetKey(KeyCode.RightArrow)){
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(265.0f, 275.0f))); // The Random Range creates a bullet spread effect
					// Reset the timer
					shootingTimer = Time.time;
				}
			// Else If the DOWN ARROW is being held down, Instantiate a bullet with the rotation of 0, 0, 180.
			} else if (Input.GetKey(KeyCode.DownArrow)){
				// if Time.time minue the shooting timer variable is GREATER THAN the timeBetweenShots variable
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(175.0f, 185.0f))); // The Random Range creates a bullet spread effect
					// Reset the timer
					shootingTimer = Time.time;
				}
			// If the Left ARROW is pressed, Instantiate a bullet with the rotation of 0, 0, 270.
			} else if (Input.GetKey(KeyCode.LeftArrow)){
				if (Time.time - shootingTimer > timeBetweenShots){
					// Instantiate the projectile prefab
					GameObject projectile = Instantiate(projectileOBJ, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(85.0f, 95.0f))); // The Random Range creates a bullet spread effect
					// Reset the timer
					shootingTimer = Time.time;
					}
				}
			#endregion

			#region DROPPIN' BOMBS
			// If the player presses the Spacebar -> Do the thing
			if (Input.GetKeyDown(KeyCode.Space)){
				if (bombCount > 0){
					// Instantate the Bomb
					GameObject bomb = Instantiate(bombOBJ, transform.position, Quaternion.identity);
					bombCount--;
					UpdateBombUI();
				} else {
					Debug.Log("You have no more bombs!");
				}
			}
				
			#endregion

		}
	}

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

	// This function Instantiates a small particle effect when the player fires a projectile
	void InstantiateShotEffect(){
		// Instantiate the particle effect
		GameObject particle = Instantiate(projectileInst, transform.position, Quaternion.identity) as GameObject;
		// Destroy the particle effect after 1 second.
		Destroy(particle, 1f);
	}

	public void UpdateBombUI(){
		
		#region UPDATE BOMB TEXT
		// Update the bomb text to the bomb count
		bombCountText.text = bombCount.ToString();
		#endregion
	}
}