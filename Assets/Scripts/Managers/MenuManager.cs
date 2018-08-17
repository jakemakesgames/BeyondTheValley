using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[Header("Temp Intro")]
	// Temp story panel
	public GameObject introCanvas;

	[Header("Main Menu Variables")]
	// Canvas Variables
	public GameObject menuCanvas;
	public GameObject controlsCanvas;
	public GameObject optionsCanvas;
	public GameObject quitCanvas;


	void Start(){
		// Setting the correct Canvases to Active or Not
		introCanvas.SetActive(true);

		menuCanvas.SetActive (true);
		controlsCanvas.SetActive (false);
		optionsCanvas.SetActive (false);
		quitCanvas.SetActive (false);
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
	}


}
