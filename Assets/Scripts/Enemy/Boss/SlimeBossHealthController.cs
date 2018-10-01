using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlimeBossHealthController : MonoBehaviour {

	[SerializeField] private SlimeBossController sbc;
	[SerializeField] private GameManager gm;
	public int scoreValue;
	[HideInInspector] public bool isDead = false;

	public float startHealth;
	private float health;

	private GameObject healthBar;
	public Image healthBarImg;
	public Text healthText;

	public GameObject deathParticleEffect;

	void Start(){
		// Get the reference to the SlimeBossController
		sbc = FindObjectOfType<SlimeBossController>();
		// Set the heal to the starting health
		health = startHealth;

		// Get a reference to the HealthBar gameObject
		healthBar = GameObject.FindGameObjectWithTag("BossHB");
		healthText.text = health.ToString ();
	}

	void Update(){

		healthText.text = health.ToString ();

		// ANGRY
		if (health <= 75f){
			// Set the Boss State equal to State.Angry
			sbc.bossState = SlimeBossController.State.angry;
		}

		// RAGE
		if (health <= 50f) {
			// Set the Boss State equal to State.Rage
			sbc.bossState = SlimeBossController.State.rage;
		}

		// LAST STAND
		if (health <= 25f) {
			// Set the Boss state equal to State.LastStand (This will activate their FINAL PHASE)
			sbc.bossState = SlimeBossController.State.lastStand;
		}

		if (health <= 0) {
			// The boss is DEAD
			Debug.Log("Slime Boss is Dead");
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
		// Disable the Slime Boss Controller
		sbc.enabled = false;
		// DEstroy the Healthbar
		Destroy(healthBar);
		// Instantiate the death particle effect
		GameObject deathFX = Instantiate(deathParticleEffect, transform.position, Quaternion.identity) as GameObject;
		// Destroy the Boss Game Object
		Destroy(this.gameObject);
		// Destroy the particle effect
		Destroy(deathFX, 1f);
	}
}
