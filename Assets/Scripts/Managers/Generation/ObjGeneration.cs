using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// THIS NAMESPACE IS ONLY TEMPORARY AND FOR TESTING PURPOSES >>> REMOVE LATER <<<
using UnityEngine.SceneManagement;

public class ObjGeneration : MonoBehaviour {

	[SerializeField] private string sceneToLoad;
	public GameObject[] objectsToSpawn;

	void Awake(){
		// Call the GenerateObject function
		GenerateObject ();
	}

//	void Update(){
//		// If the G key is pressed, reload the scene (test purpose only)
//		if (Input.GetKeyDown (KeyCode.G)) {
//			SceneManager.LoadScene (sceneToLoad);
//		}
//	}

	// This function handles the instantiation of the object
	void GenerateObject(){
		int rand = Random.Range (0, objectsToSpawn.Length);
		// Instantiate a random object from the objectsToSpawn array at this spawner's transform.position with NO rotation
		Instantiate (objectsToSpawn [rand], transform.position, Quaternion.identity);
		// Destroy this gameObject to prevent cluttering the scene with empty gameObjects

	}
}
