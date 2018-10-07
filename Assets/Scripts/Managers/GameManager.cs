using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	#region COMPONENTS AND VARIABLES
	private static bool created = false;

	PlayerController playerController;
	Shake shake;

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

	[SerializeField] private bool pickups;

	[SerializeField] private int itemDropAmt;
	[SerializeField] private int itemDropMax;

	[Header("UI")]
	// The reference to the Game Over UI
	public GameObject gameOverUI;

	[Header("Public Variables")]
	public string retryScene;
	public string backToMenu;

	#endregion

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}

	}

	void Start(){
		pickups = true;
		// Find a reference to the PlayerController
		playerController = FindObjectOfType<PlayerController> ();
		// Set the GameOverUI to false (not visible)
		gameOverUI.SetActive (false);


		gemText = GameObject.FindGameObjectWithTag ("CoinCount").GetComponent<Text>();
		playerScoreText = GameObject.FindGameObjectWithTag ("PlayerScore").GetComponent<Text>();
		shake = GetComponentInChildren<Shake> ();
		shake.camAnim = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Animator>();
	}


	void Update(){
		UpdateGemText ();
		UpdateScoreText ();
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
		if (pickups){
			// If the randNum variable is equal to 1 -> a health pickup has been dropped
			if (randomNum == 1){
				// Instantiate the healthPickup GameObject at the enemy's death spot.
				HP = Instantiate(healthPickup, enemyDeathSpot, Quaternion.identity);
				Debug.Log("Health Pickup dropped");

				ItemDropCounter();
			}

			// If the randNum variable is equal to 2 -> a gem has been dropped
			if (randomNum == 2){
				// Instantiate the gemPickup GameObject at the enemy's death spot.
				gem = Instantiate(gemPickup, enemyDeathSpot, Quaternion.identity);
				Debug.Log("Gem dropped");

				ItemDropCounter();
			}

			// If the randNum is equal is 3 -> a rapid fire pickup has been dropped
			if (randomNum == 3){
				// Instantiate the rapidFirePickup GameObject at the enemy's death spot.
				rapidFire = Instantiate(rapidFirePickup, enemyDeathSpot, Quaternion.identity);
				Debug.Log("Rapid Fire dropped");

				ItemDropCounter();
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
		}

		#endregion
	}

	public void ItemDropCounter(){
		// Increase the amount of items dropped
		itemDropAmt++;

		if (itemDropAmt >= itemDropMax) {
			pickups = false;
		}
	}

	public void AddScore(int scoreAmount){
		// Add the score amount in passed in to the playerScore
		playerScore += scoreAmount;
		// Update the PlayerScoreText
		UpdateScoreText();
	}

	public void UpdateGemText(){
		// Update the GemText
		gemText.text = gemCount.ToString ();
	}

	public void UpdateScoreText(){
		// Update the PlayerScoreText
		playerScoreText.text = playerScore.ToString ();
	}

	public void GameOver(){
		Debug.Log ("You Died! Game Over...");
		// Show the GameOverUI
		gameOverUI.SetActive(true);
	}

	public void Retry(){
		// Reload level 1-1
		SceneManager.LoadScene(retryScene);
	}

	public void ReturnToMenu(){
		// Return to the Menu
		SceneManager.LoadScene(backToMenu);
	}
}
