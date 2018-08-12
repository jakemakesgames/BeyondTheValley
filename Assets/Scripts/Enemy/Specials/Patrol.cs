using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	// How fast will the enemy move
	public float speed;

	private float waitTime;
	public float startWaitTime;

	// All of the transforms the enemy will be able to move to
	public Transform moveSpot;

	[Header("XY CoOrds")]
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	void Start(){
		waitTime = startWaitTime;

		moveSpot.position = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));
	}

	void Update(){
		// The enemies position is equal to a randomly chosen moveSpot transform -> it will move there at the speed value multiplied by Time.deltaTime
		transform.position = Vector2.MoveTowards (transform.position, moveSpot.transform.position, speed * Time.deltaTime);

		if (Vector2.Distance (transform.position, moveSpot.position) < 0.2f) {
			if (waitTime <= 0) {
				moveSpot.position = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));
				// The randSpot int value is equal to a random number between 0 and the amount of Transforms in the moveSpot array
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
		}
	}

}
