using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject shot;
	[SerializeField] private Transform playerPos;

	// Shooting Variables
	[SerializeField] private float shootingTimer;
	public float timeBetweenShots;

	// The position in which the projectile is instantiated
	public GameObject shotPos;

	void Start(){
		playerPos = GetComponent<Transform> ();
		shootingTimer = Time.time;
		shotPos = GameObject.FindGameObjectWithTag ("shotPos");
	}

	void Update(){
		// If the left mouse button is clicked (Do the thing)
		if (Input.GetMouseButton(0)){
			// If Time.time minus the shootingTimer variable is GREATER THAN the timeBetweenShots varibale
			if (Time.time - shootingTimer > timeBetweenShots) {
				// Call the Shoot function
				Shoot();
				// Reset the shooting timer
				shootingTimer = Time.time;
			}
		}
	}

	void Shoot(){
		// Instantiate the shot gameObject from the shot position
		Instantiate (shot, shotPos.transform.position, Quaternion.identity);
	}
}
