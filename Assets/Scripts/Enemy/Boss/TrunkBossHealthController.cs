using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunkBossHealthController : MonoBehaviour {

	[SerializeField] private TrunkBossController tbc;
	[SerializeField] private GameManager gm;
	public int scoreValue;
	[HideInInspector] public bool isDead = false;

	public float startHealth;
	public float health;

	private GameObject healthBar;
	public Image healthBarImg;
	public Text healthText;

	public GameObject deathParticleEffect;

	void Start(){
		// Get reference to the TrunkBossController
		tbc = FindObjectOfType<TrunkBossController> ();
		// Set the health to the starting health
		health = startHealth;

		// Get referencce to the HealthBar GameObject
		healthBar = GameObject.FindGameObjectWithTag("BossHB");
		healthText.text = health.ToString ();
	}

	void Update(){

		healthText.text = health.ToString ();

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

		healthBarImg.fillAmount = health / startHealth;

		if (health <= 0) {
			// Call the Die function
			Die();
		}
	} 

	void Die(){
		// Disable the TrunkBossController so the boss can no longer shoot
		tbc.enabled = false;
		// Destroy the HealthBar
		Destroy(healthBar);
		// Instantiate the death particle effect
		GameObject deathFX = Instantiate(deathParticleEffect, transform.position, Quaternion.identity) as GameObject;
		// Destroy the Game Object
		Destroy(this.gameObject);
		// Destroy the particle effect
		Destroy(deathFX, 1f);

	}
}
