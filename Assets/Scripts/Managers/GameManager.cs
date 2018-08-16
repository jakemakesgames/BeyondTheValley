using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	PlayerController playerController;

	[Header("Scoring")]
	public int playerScore;
	public Text playerScoreText;
	public int gemCount;
	public Text gemText;

	[Header("Pickups")]
	public GameObject healthPickup;
	public GameObject gemPickup;
	public GameObject rapidFirePickup;
	public GameObject bombPickup;

	void Start(){
		// Find a reference to the PlayerController
		playerController = FindObjectOfType<PlayerController> ();
	}

	void Update(){
		UpdateGemText ();
	}


	// This function determines which item will be dropped when an enemy is killed
	public void ItemDrop(Vector2 enemyDeathSpot){

		#region Drops
		int randomNum;
		GameObject HP;
		GameObject gem;
		GameObject rapidFire;
		GameObject bomb;

		// The random number equals a number between 1 & 5
		randomNum = Random.Range(1, 6);

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

		// If the randNum is equal is 5 -> a bomb pickup is dropped
		if (randomNum == 4){
			// Instantiate the bombPickup GameObject at the enemy's death spot.
			bomb = Instantiate(bombPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log("Bomb dropped");
		}

		// If the randNum is equal is 5 -> nothing is dropped
		if (randomNum == 5) {
			Debug.Log ("Nothing dropped");
		}

		// If the randNum is equal is 6 -> nothing is dropped
		if (randomNum == 6){
			Debug.Log("Nothing dropped");
		}
		#endregion
	}

	public void UpdateGemText(){
		// Update the GemText
		gemText.text = gemCount.ToString ();
	}
}
