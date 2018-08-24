using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	public Animator camAnim;

	public void CamShake(){
		// Choose a random animation to play
		int rand = Random.Range(0, 3);
		// If rand is equal to 0 -> Play the "Shake1" animation
		if (rand == 0) {
			camAnim.SetTrigger ("Shake1");
		// Else if rand is equal to 1 -> Play the "Shake2" animation
		} else if (rand == 1) {
			camAnim.SetTrigger ("Shake2");
		// Else if rand is equal to 2 -> Play the "Shake3" animation
		} else if (rand == 2) {
			camAnim.SetTrigger ("Shake3");
		}
	}

	public void CamMiniShake(){
		// Choose a random animation to play
		int miniRand = Random.Range(0, 3);
		// If rand is equal to 0 -> Play the "MiniShake1" animation
		if (miniRand == 0) {
			camAnim.SetTrigger ("MiniShake1");
			// Else if rand is equal to 1 -> Play the "MiniShake2" animation
		} else if (miniRand == 1) {
			camAnim.SetTrigger ("MiniShake2");
			// Else if rand is equal to 2 -> Play the "MiniShake1" animation
		} else if (miniRand == 2) {
			camAnim.SetTrigger ("MiniShake3");
		}
	}
}
