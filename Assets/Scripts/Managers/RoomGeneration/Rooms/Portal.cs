using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	public GameObject promptText;
	public bool prompted;
	public string levelToLoad;

	void Start(){
		promptText.SetActive (false);
		prompted = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.E) && prompted) {
			SceneManager.LoadScene (levelToLoad);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			promptText.SetActive (true);
			prompted = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			promptText.SetActive (false);
			prompted = false;
		}
	}
}
