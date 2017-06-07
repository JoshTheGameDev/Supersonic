using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int checkpointNumber;


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerControllerv3> ().HitCheckPoint (checkpointNumber);

		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
