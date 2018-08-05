using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptable : ScriptableObject {

	// The Enemy type
	public enum enemyType { neutral, ranged, aggressive }; 

	// The enemy GFX
	public Sprite enemySprite;

	// The Enemy Health Variable
	public int enemyHealth;
	// The Damage Amount dealth
	public int enemyDamageAmount;

	// Movement Variables
	public float enemyMovementSpeed;
	public float enemyMoveRange;

	// How many points the Player scores when they kill the Enemy
	public int enemyScoreValue;

	// Worry about Item Drops later	
	public bool enemyCanDropItem;
}
