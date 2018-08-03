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

	void Start(){
		// The rb2D varible is set the to Rigidbody 2D component on the Player GameObject
		rb2D = GetComponent<Rigidbody2D> ();
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
		} else {
			#region Keyboard Input
			// The moveInput Vector2 is equal to a new Vector2 - The Horizontal Axis (for X axis movement), and The Vertical Axis (for Y axis movement)
			// Left = -1 | Right = 1 | Up = 1 | Down = -1 (Use GetAxisRaw for snappier movements)
			Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Hori"), Input.GetAxisRaw ("Vert"));
			// Set the moveVelocity equal to the moveInput multiplied by the movementSpeed variable (Normalized so the speed is the same in all directions)
			moveVelocity = moveInput.normalized * movementSpeed;
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
}
