using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			anim.SetTrigger ("Move");
		}
	}
}
