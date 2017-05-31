using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackAndPan : MonoBehaviour {
	
	public GameObject target;
	public float speed;

	//Use for game end camera, track winner

	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);	
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime*speed);

	}
}
