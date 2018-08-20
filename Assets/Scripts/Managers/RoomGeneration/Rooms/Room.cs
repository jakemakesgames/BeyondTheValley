using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public List<GameObject> enemiesInRoom;
	public List<GameObject> doorsInRoom;

	void Start(){

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemiesInRoom.Add (enemy);
		}

		foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door")) {
			doorsInRoom.Add (door);
		}
	}

	void Update(){
		if (enemiesInRoom.Count <= 0) {
			Debug.Log ("All enemies are dead!");
			OpenDoors ();
		}
	}

	void OpenDoors(){
		foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door")) {
			door.SetActive (false);
		}
	}


}
