using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	[SerializeField] private Transform target;

	// How fast will the enemy move
	public float speed;

	private float waitTime;
	public float startWaitTime;

	public List<GameObject> moveSpot;
	public int randSpot;

	void Start(){

		// For each GameObject with the Tag "MoveSpot" in the scene -> add it to the moveSpot list
		foreach (GameObject spot in GameObject.FindGameObjectsWithTag("MoveSpot")) {
			moveSpot.Add(spot);
		}


		// Set the random spot equal to a random posiion between zero and the max count of the move spots list
		randSpot = Random.Range(0, moveSpot.Count);

		target = FindObjectOfType<PlayerController> ().GetComponent<Transform> ();
		waitTime = startWaitTime;
	}

	void Update(){
		// The enemies position is equal to a randomly chosen moveSpot transform -> it will move there at the speed value multiplied by Time.deltaTime
		if (target != null) {
			transform.position = Vector2.MoveTowards (transform.position, moveSpot[randSpot].transform.position, speed * Time.deltaTime);

			// If the enemy HAS reached the random position, move to another
			if (Vector2.Distance(transform.position, moveSpot[randSpot].transform.position) < 0.2f){
				// If the wait time is less than OR equal to zero
				if (waitTime <= 0) {
					// Set the random spot equal to a random posiion between zero and the max count of the move spots list
					randSpot = Random.Range(0, moveSpot.Count);
					waitTime = startWaitTime;
				} else {
					// Slowly decrease Time.delatTime from the waitTime value
					waitTime -= Time.deltaTime;
				}
			}
		}
	}

}
