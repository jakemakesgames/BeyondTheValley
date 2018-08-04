using System.Collections;
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

	private Vector3 target;

	public GameObject shot;
	[SerializeField] private Transform playerPos;

	// Shooting Variables
	[SerializeField] private float shootingTimer;
	public float timeBetweenShots;

	// The position in which the projectile is instantiated
	public GameObject shotPos;

	void Start(){

		// The rb2D varible is set the to Rigidbody 2D component on the Player GameObject
		rb2D = GetComponent<Rigidbody2D> ();

		// Setting Ranged Attack Variables
		playerPos = GetComponent<Transform> ();
		shootingTimer = Time.time;
		shotPos = GameObject.FindGameObjectWithTag ("shotPos");

	}

	void Update(){

		#region MOVEMENT

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

		if (usingGamepad) {
			#region Gamepad Input
			Vector2 moveInputAlt = new Vector2 (XCI.GetAxis (XboxAxis.LeftStickX), XCI.GetAxis (XboxAxis.LeftStickY));
			moveVelocityAlt = moveInputAlt.normalized * movementSpeed;
			#endregion

			#region Gamepad Ranged Attack
			// If the A button is being held down (Do the thing)
			if (XCI.GetButton(XboxButton.A)){
				// If Time.time minus the shootingTimer variable is GREATER THAN the timeBetweenShots varibale
				if (Time.time - shootingTimer > timeBetweenShots) {
					// Call the Shoot function
					Shoot();
					// Reset the shooting timer
					shootingTimer = Time.time;
				}
			}

			#endregion

		} else {
			#region Keyboard Input
			// The moveInput Vector2 is equal to a new Vector2 - The Horizontal Axis (for X axis movement), and The Vertical Axis (for Y axis movement)
			// Left = -1 | Right = 1 | Up = 1 | Down = -1 (Use GetAxisRaw for snappier movements)
			Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Hori"), Input.GetAxisRaw ("Vert"));
			// Set the moveVelocity equal to the moveInput multiplied by the movementSpeed variable (Normalized so the speed is the same in all directions)
			moveVelocity = moveInput.normalized * movementSpeed;
			#endregion

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
		}

		#endregion
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

	void Shoot(){
		// Instantiate the shot gameObject from the shot position
		Instantiate (shot, shotPos.transform.position, Quaternion.identity);
	}

}
