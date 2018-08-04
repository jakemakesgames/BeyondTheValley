using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {

	public int damageToDeal;

	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthController> ().HurtPlayer (damageToDeal);
		}
	}
}
