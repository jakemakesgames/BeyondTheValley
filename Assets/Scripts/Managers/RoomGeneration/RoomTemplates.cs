using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour {

	[Header("TESTING PURPOSES ONLY/ REMOVE LATER")]
	[SerializeField] private string scene;

	[Header("Spawnable Rooms")]
	public GameObject[] topRooms;
	public GameObject[] bottomRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			SceneManager.LoadScene (scene);
		}
	}
}
