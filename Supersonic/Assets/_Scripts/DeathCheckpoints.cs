using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheckpoints : MonoBehaviour {

	public int checkpointNumber;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerControllerv3> ().HitCheckPoint (checkpointNumber);
			Debug.Log ("Hiya!!!!!!!!!!!!!!!!!");
		}
	}
}
