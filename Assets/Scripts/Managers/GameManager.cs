using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header("Scoring")]
	public int playerScore;
	public Text playerScoreText;

	[Header("Pickups")]
	public GameObject healthPickup;
	public GameObject gemPickup;
	public GameObject rapidFirePickup;

	// This function determines which item will be dropped when an enemy is killed
	public void ItemDrop(Vector2 enemyDeathSpot){

		int randomNum;
		GameObject HP;
		GameObject gem;
		GameObject rapidFire;

		// The random number equals a number between 1 & 5
		randomNum = Random.Range(1, 5);

		// If the randNum variable is equal to 1 -> a health pickup has been dropped
		if (randomNum == 1){
			// Instantiate the healthPickup GameObject at the enemy's death spot.
			HP = Instantiate(healthPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log("Health Pickup dropped");
		}

		// If the randNum variable is equal to 2 -> a gem has been dropped
		if (randomNum == 2){
			// Instantiate the gemPickup GameObject at the enemy's death spot.
			gem = Instantiate(gemPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log("Gem dropped");
		}

		// If the randNum is equal is 3 -> a rapid fire pickup has been dropped
		if (randomNum == 3){
			// Instantiate the rapidFirePickup GameObject at the enemy's death spot.
			rapidFire = Instantiate(rapidFirePickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log("Rapid Fire dropped");
		}

		// If the randNum is equal is 4 -> nothing is dropped
		if (randomNum == 4){
			// No item is to be dropped 
			Debug.Log("Nothing dropped");
		}

		// If the randNum is equal is 5 -> nothing is dropped
		if (randomNum == 5) {
			Debug.Log ("Nothing dropped");
		}
	}


}
