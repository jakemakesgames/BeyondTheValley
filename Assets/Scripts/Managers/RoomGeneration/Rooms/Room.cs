using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {

	public List<GameObject> enemiesInRoom;
	public GameObject portal;
	bool portalOpened;
	//public string bossLevel;

	void Start(){
		portalOpened = false;
		/*
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemiesInRoom.Add (enemy);
		}
		*/	
	}

	void Update(){
		if (enemiesInRoom.Count <= 0) {
			Debug.Log ("All enemies are dead!");

			if (!portalOpened) {
				Instantiate (portal, transform.position, Quaternion.identity);
				portalOpened = true;
			}

			//GoToBossBattle ();
		}
	}

	//void GoToBossBattle(){
		//SceneManager.LoadScene (bossLevel);
	//}


}
