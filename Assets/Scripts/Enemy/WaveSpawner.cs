﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { Spawning, Waiting, Counting};

	[System.Serializable]
	public class Wave // The Wave Class -> This is where all of the data will be taken from in order to spawn waves
	{
		public string name; // The name of the current wave
		public Transform enemy; // The transform of the enemy that will be spawned (Turn this into an array later to spawn multiple enemies)
		public int count; // The amount of enemies to spawn
		public float rate; // The rate at which the enemies spawn
	}

	[Header("Waves")]
	public Wave[] waves;
	[SerializeField] private int nextWave;

	[SerializeField] private SpawnState state = SpawnState.Counting; // Set the state to SpawnState.Counting by default

	[Header("Wave Timers")]
	public float timeBetweenWaves; // The time that passes between waves
	public float waveCountdown; // A countdown timer til the next wave

	public bool wavesActive;

	void Start(){
		// Set the waveCountdown value equal to the timeBetweenWaves value
		waveCountdown = timeBetweenWaves;
		// Set the wavesActive to true
		wavesActive = true;
	}

	void Update(){
		// If waveCountdown is less than or equal to zero -> Do the thing
		if (waveCountdown <= 0) {
			// If the current SpawnState does NOT equal spawning
			if (state != SpawnState.Spawning) {
				// Start spawning the wave here
				StartCoroutine(SpawnWave(waves[nextWave]));
				Debug.Log("Spawning Wave");
			}
		} else {
			waveCountdown -= Time.deltaTime;
		}
	}

	// Coroutine handling the Wave Spawning
	IEnumerator SpawnWave (Wave _wave){
		// The SpawnState is "Spawning"
		state = SpawnState.Spawning;

		for (int i = 0; i < _wave.count; i++) {
			// Call the SpawnEnemy function
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds (1f/ _wave.rate);
		}

		// The SpawnState is "Waiting"
		state = SpawnState.Waiting;
		yield break;
	}

	// A function to handle the Enemy Spawning
	void SpawnEnemy(Transform _enemy){
		Debug.Log ("Spawning Enemy");
	}

}
