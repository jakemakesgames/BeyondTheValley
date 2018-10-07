using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

	private GameManager gm;

	#region COMPONENTS AND VARIABLES
	[Header("UI Components")]
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

	#endregion

	#region BLINKING VARIABLES
	[Header("Damage Blinking Effect")] // The follow variables and their values are simply tests/ placholder to see if this method works
	[SerializeField] private float blinkingTimer = 0.0f;
	[SerializeField] private float blinkingMinDuration = 0.1f;
	[SerializeField] private float blinkingTotalTimer = 0.0f;
	[SerializeField] private float blinkingTotalDuration = 1.0f;
	[SerializeField] private bool startBlinking = false;
	#endregion

	void Start(){
		gm = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update(){

		if (startBlinking) {
			StartBlinkingEffect ();
		}
		
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
		
	public void GainHealth(int healthGained){
		if (health < numberOfHearts) {
			health += healthGained;
		}

	}

	public void HurtPlayer(int damageToDeal){

		startBlinking = true;

		health -= damageToDeal;

		if (health <= 0) {
			health = 0;
			Die ();
		}
	}

	#region BLINKING EFFECT
	void StartBlinkingEffect (){
		blinkingTotalTimer += Time.deltaTime;

		if (blinkingTotalTimer >= blinkingTotalDuration) {
			startBlinking = false;
			blinkingTotalTimer = 0.0f;

			gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
			return;
		}

		blinkingTimer += Time.deltaTime;
		if (blinkingTimer >= blinkingMinDuration) {
			blinkingTimer = 0.0f;

			if (gameObject.GetComponentInChildren<SpriteRenderer> ().enabled == true) {
				gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = false;
			} else {
				gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
			}
		}
	}
	#endregion

	void Die(){
		gm.GameOver ();
		Destroy (gameObject);
	}

}
