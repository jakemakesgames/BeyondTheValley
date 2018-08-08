using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 -> needs a bottom door
	// 2 -> needs a top door
	// 3 -> needs a left door
	// 4 -> needs a right door

	private RoomTemplates templates;
	private int rand;
	private bool spawned = false;

	void Start(){
		templates = GameObject.FindGameObjectWithTag ("Rooms").GetComponent<RoomTemplates>();
		Invoke ("Spawn", 0.1f);
	}

	void Spawn(){
		// If the "spawned" bool returns false -> do the thing
		if (spawned == false) {
			if (openingDirection == 1) {
				// Instantiate a room with a BOTTOM door
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate (templates.bottomRooms [rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 2) {
				// Instantiate a room with a TOP door
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate (templates.topRooms [rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 3) {
				// Instantiate a room with a LEFT door
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate (templates.leftRooms [rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 4) {
				// Instantiate a room with a RIGHT door
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate (templates.rightRooms [rand], transform.position, Quaternion.identity);
			}
			spawned = true;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag ("SpawnPoint")) {
			Destroy (gameObject);
		}
	}
}
