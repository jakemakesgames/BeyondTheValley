using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


	[Header("Temp Intro")]
	// Temp story panel
	public GameObject introCanvas;
	public GameObject titleScreenCanvas;
	[SerializeField] private bool pressedSpacebar;

	public Text introText;
	public string[] sentences;
	private int index;
	public float typingSpeed;


	[Header("Main Menu Variables")]
	// Canvas Variables
	public GameObject menuCanvas;
	public GameObject controlsCanvas;
	public GameObject optionsCanvas;
	public GameObject quitCanvas;

	void Start(){
		// Setting the correct Canvases to Active or Not

		introCanvas.SetActive(true);
		titleScreenCanvas.SetActive (false);


		menuCanvas.SetActive (true);
		controlsCanvas.SetActive (false);
		optionsCanvas.SetActive (false);
		quitCanvas.SetActive (false);
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && !pressedSpacebar) {
			titleScreenCanvas.SetActive (false);
			pressedSpacebar = true;

		}
	}

	public void PlayGame(){
		// Change to Game Scene
	}

	public void Back(){
		#region IF MenuActive is TRUE
		menuCanvas.SetActive (true);
		controlsCanvas.SetActive (false);
		optionsCanvas.SetActive (false);
		quitCanvas.SetActive (false);
		#endregion
	}

	public void ControlsMenu(){
		#region IF ControlsActive is TRUE
		menuCanvas.SetActive (false);
		controlsCanvas.SetActive (true);
		optionsCanvas.SetActive (false);
		quitCanvas.SetActive (false);
		#endregion
	}

	public void OptionsMenu(){
		#region IF OptionsActive is TRUE
		menuCanvas.SetActive (false);
		controlsCanvas.SetActive (false);
		optionsCanvas.SetActive (true);
		quitCanvas.SetActive (false);
		#endregion
	}

	public void QuitMenu(){
		#region IF QuitActive is TRUE
		menuCanvas.SetActive (false);
		controlsCanvas.SetActive (false);
		optionsCanvas.SetActive (false);
		quitCanvas.SetActive (true);
		#endregion
	}

	public void ConfirmQuit(){
		// Quit the game
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}


	public void SkipIntro(){
		// Set the intro canvas to false (hiding it from view).
		introCanvas.SetActive(false);
		pressedSpacebar = false;
		titleScreenCanvas.SetActive (true);
	}



}
