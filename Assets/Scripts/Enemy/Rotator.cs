using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed;


	public void Update(){
		transform.Rotate (0, 0, speed * Time.deltaTime);
	}
}
