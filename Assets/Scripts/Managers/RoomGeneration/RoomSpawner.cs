using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 -> needs a bottom door
	// 2 -> needs a top door
	// 3 -> needs a left door
	// 4 -> needs a right door

	void Update(){
		if (openingDirection == 1) {
			// Instantiate a room with a BOTTOM door
		} else if (openingDirection == 2) {
			// Instantiate a room with a TOP door
		} else if (openingDirection == 3) {
			// Instantiate a room with a LEFT door
		} else if (openingDirection == 4) {
			// Instantiate a room with a RIGHT door
		}
	}
}
