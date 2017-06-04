using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCarTut : MonoBehaviour {

	public int checkPointNumber;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Car> ().HitCheckPoint (checkPointNumber);
			Debug.Log ("Hiya!!!!!!!!!!!!!!!!!");
		}
	}
}
