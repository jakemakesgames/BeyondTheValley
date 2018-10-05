using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {

	private Animator anim;
	[SerializeField] private bool isBush;
	[SerializeField] private GameObject leavesParticle;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			anim.SetTrigger ("Move");
			if (isBush) {
				GameObject leaves = Instantiate (leavesParticle, transform.position, Quaternion.identity) as GameObject;
				Destroy (leaves, 2f);
			}


		}
	}
}
