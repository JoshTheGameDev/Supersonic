using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

	public float speedBoost = 10000;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Rigidbody> ().AddForce
			(other.transform.forward * speedBoost, ForceMode.Impulse);
		}
	}
}
