using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public EnemyScriptable eS;

	[SerializeField] private enum type{ neutral, ranged, aggressive };
	[SerializeField] private type enemyType;
	public int health;

	public bool canDropItem;

	void Start(){
		// Call the EnemyTypeCheck function
		EnemyTypeCheck ();
		health = eS.enemyHealth;
		canDropItem = eS.enemyCanDropItem;
	}

	// This Function serves the purpose of checking which type this enemy is - this will set the variable values and type specific parameters
	void EnemyTypeCheck(){
		if (enemyType == type.neutral) {
			// Check if the type of this enemy is Neutral
			Debug.Log ("I am Neutral");

			// Do the Neutral Enemy Stuff here

		} else if (enemyType == type.ranged) {
			// Check if the type of this enemy is Ranged
			Debug.Log ("I am Ranged");

			// Do the Ranged Enemy Stuff here

		} else if (enemyType == type.aggressive) {
			// Check if the type of this enemy is Aggressive
			Debug.Log ("I am Aggressive");

			// Do the Aggressive Enemy Stuff here
		}
	}

}
