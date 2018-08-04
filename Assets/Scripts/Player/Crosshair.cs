using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Crosshair : MonoBehaviour {

	[SerializeField] private PlayerController playerController;
	public GameObject cursor;
	public Vector2 moveVel;
	public float movementSpeed;
	private Rigidbody2D rb2D;

	void Start(){

		Cursor.visible = false;

		rb2D = GetComponent<Rigidbody2D> ();
		playerController = FindObjectOfType<PlayerController> ();
	}

	void Update(){

		if (playerController.usingGamepad) {
			// Control Cursor with Gamepad
			#region Gamepad Input
			Vector2 moveInputAlt = new Vector2 (XCI.GetAxis (XboxAxis.RightStickX), XCI.GetAxis (XboxAxis.RightStickY));
			moveVel = moveInputAlt.normalized * movementSpeed;
			#endregion


			// Lock and Hide Cursor
		} else {
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = cursorPos;
		}

	}

	void FixedUpdate(){
		if (playerController.usingGamepad) {
			// Gamepad Move Player
			rb2D.MovePosition (rb2D.position + moveVel * Time.fixedDeltaTime);
		}
	}
}
