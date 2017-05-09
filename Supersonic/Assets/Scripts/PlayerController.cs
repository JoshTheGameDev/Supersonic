using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float powerUpSpeed;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.right *
				-playerSpeed);

		if (maxSpeed == 117)
			;
	//gameObject.GetComponent<Rigidbody> ().AddForce (playerSpeed - playerSpeed);
	}

}
