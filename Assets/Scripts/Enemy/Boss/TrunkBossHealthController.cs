using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBossHealthController : MonoBehaviour {

	[SerializeField] private TrunkBossController tbc;
	[SerializeField] private GameManager gm;
	public int scoreValue;
	[HideInInspector] public bool isDead = false;

	public float startHealth;
	public float health;

	void Start(){
		// Get reference to the TrunkBossController
		tbc = FindObjectOfType<TrunkBossController> ();
		// Set the health to the starting health
		health = startHealth;
	}

	void Update(){

		// ANGRY
		if (health <= 75f) {
			// Set the Boss State equal to State.Angry (This will activate PHASE 2)
			tbc.bossState = TrunkBossController.State.angry;
		}
		// If the Boss' health is less than OR equal to 50, their state is
		// RAGE
		if (health <= 50f) {
			// Set the Boss State equal to State.LastStand (This will activate their FINAL PHASE);
			tbc.bossState = TrunkBossController.State.rage;
		}

		// LAST STAND
		if (health <= 25f) {
			// Set the Boss State equal to State.Rage
			tbc.bossState = TrunkBossController.State.lastStand;
		}

		// If the Boss' health is less than OR equal to 0 -> Call the Die function
		if (health <= 0) {
			// Call the Die function
			Debug.Log("Trunk Boss is Dead");
		}
	}

	public void TakeDamage(int damageToDeal){
		health -= damageToDeal;
	} 
}
