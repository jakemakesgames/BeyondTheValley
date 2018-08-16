using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	[SerializeField] private EnemyController enemyController;
	[SerializeField] private GameManager gm;
	public int scoreValue;

	[Header("Enemy Health")]
	public int health;

	void Awake(){
		// Finding reference to the Game Manager GameObject
		gm = FindObjectOfType<GameManager>();
		enemyController = GetComponent<EnemyController> ();
	}

	void Start(){

		// Setting the health variable to the enemy scriptable health value attached to this GameObject
		//health = enemyController.health;

	}

	private void Update()
	{
		// If the enemy's health is less than or equal to 0 -> cap the health at 0.
		if (health <= 0){
			health = 0;
			// Call the EnemyDie function
			EnemyDie();
		}
	}

	public void TakeDamage (int damageToDeal){
		health -= damageToDeal;

		if (health <= 0) {
			health = 0;
			EnemyDie ();
		}
	}

	// This is called when the enemy is Dead
	void EnemyDie(){
		// Creating a Vector2 called enemyDeathSpot at the current gameObjects transform.position
		Vector2 enemyDeathSpot = this.gameObject.transform.position;
		// Call the ItemDrop function in the Game Manager, passing in the Vector2 created above -> an Item should drop (unless the randNum is equal to 3 OR 4)
		gm.GetComponent<GameManager>().ItemDrop(enemyDeathSpot);
		// Add score
		gm.AddScore(scoreValue);
		// Destroy this enemy
		Destroy(this.gameObject);
		}
	}
