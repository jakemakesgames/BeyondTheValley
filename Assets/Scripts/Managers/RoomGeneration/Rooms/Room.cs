using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {

	public List<GameObject> enemiesInRoom;
	public GameObject portal;
	//public string bossLevel;

	void Start(){

		/*
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemiesInRoom.Add (enemy);
		}
		*/	
	}

	void Update(){
		if (enemiesInRoom.Count <= 0) {
			Debug.Log ("All enemies are dead!");
			Instantiate (portal, transform.position, Quaternion.identity);
			//GoToBossBattle ();
		}
	}

	//void GoToBossBattle(){
		//SceneManager.LoadScene (bossLevel);
	//}


}
