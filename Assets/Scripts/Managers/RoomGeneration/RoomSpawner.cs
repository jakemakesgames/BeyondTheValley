using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	// Private variables
	private RoomTemplates roomTemplates;
	private int rand;

	[Header("Room Opening Direction"), Tooltip(" 1 = Bottom Door, 2 = Top Door, 3 = Left Door, 4 = Right Door")]
	public int openingDirection;
	// 1 -> needs a bottom door
	// 2 -> needs a top door
	// 3 -> needs a left door
	// 4 -> needs a right door

	public bool spawned;


	void Start(){
		roomTemplates = GameObject.FindGameObjectWithTag ("Rooms").GetComponent<RoomTemplates> ();
		Invoke ("Spawn", 0.1f);
	}

	void Spawn(){
		// If the spawned bool is false, instantaite rooms
		if (!spawned) {
			if (openingDirection == 1) {
				// Instantiate a (random) room with a BOTTOM door
				rand = Random.Range(0, roomTemplates.bottomRooms.Length);
				Instantiate (roomTemplates.bottomRooms[rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 2) {
				// Instantiate a (random) room with a TOP door
				rand = Random.Range(0, roomTemplates.topRooms.Length);
				Instantiate (roomTemplates.topRooms[rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 3) {
				// Instantiate a (random) room with a LEFT door
				rand = Random.Range(0, roomTemplates.leftRooms.Length);
				Instantiate (roomTemplates.leftRooms[rand], transform.position, Quaternion.identity);
			} else if (openingDirection == 4) {
				// Instantiate a (random) room with a RIGHT door
				rand = Random.Range(0, roomTemplates.rightRooms.Length);
				Instantiate (roomTemplates.rightRooms[rand], transform.position, Quaternion.identity);
			}
			// spawned is now true, no more rooms can spawn
			spawned = true;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		// If the other gameObject we have collided with has the tag "SpawnPoint" and that object's spawned bool is equal to true -> Do the thing
		if (other.CompareTag ("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true){
			Destroy (gameObject);
		}
	}
}
