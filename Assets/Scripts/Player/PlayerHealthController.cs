using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

	// The amount of health the player has
	public int health;
	// The total amount of health the player has
	public int numberOfHearts;
	// The Array of Images
	public Image[] hearts;
	// The Sprite of the Full Heart
	public Sprite fullHeart;
	// The Sprite of the Empty Heart
	public Sprite emptyHeart;

	void Update(){
		
		#region Health Cap
		if (health > numberOfHearts) {
			health = numberOfHearts;
		}
		#endregion

		#region Update the UI
		// This for loop updates the UI elements
		for (int i = 0; i < hearts.Length; i++) {

			// The hearts that the player is missing will not have the full heart sprite
			if (i < health) {
				hearts [i].sprite = fullHeart;
			} else {
				hearts [i].sprite = emptyHeart;
			}

			// This ensures the max amount of hearts on the screen cannot be greater than the numberOfHearts variable
			if (i < numberOfHearts) {
				hearts [i].enabled = true;
			} else {
				hearts [i].enabled = false;
			}
		}
		#endregion
	}

	public void HurtPlayer(int damageToDeal){
		health -= damageToDeal;

		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		Debug.Log ("You Died!");
	}

}
