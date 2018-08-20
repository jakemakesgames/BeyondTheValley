using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;

	void Awake(){
		// Call  the SpawnEnemy function
		SpawnEnemy();
	}

	void SpawnEnemy(){
		// Instantiate a random enemy prefab at this gameObjects position
		Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
	}
}
