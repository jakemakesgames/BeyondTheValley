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
	}

	void Update(){


//		if (health <= 75f) {
//			tbc.bossState = tbc.State.angry;
//			Debug.Log ("BOSS.IS.ANGRY!");
//		}
	}
}
