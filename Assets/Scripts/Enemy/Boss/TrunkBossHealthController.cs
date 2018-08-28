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
		tbc = FindObjectOfType<TrunkBossController> ();
		health = startHealth;
	}

	void Update(){

		// If the Boss' health is less than OR equal to 75, their state is 
		// ANGRY
		if (health <= 75f) {
			// Set the Boss State equal to State.Angry (This will activate PHASE 2)
			tbc.bossState = TrunkBossController.State.angry;
		}
		// If the Boss; health is less than OR equal to 50, their state is
		// LAST STAND
		if (health <= 50f) {
			// Set the Boss State equal to State.LasStand (This will activate their FINAL PHASE);
			tbc.bossState = TrunkBossController.State.lastStand;
		}
	}

	public void TakeDamage(int damageToDeal){
		health -= damageToDeal;
	} 
}
