using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public GameObject target;
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);	
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime*speed);

	}
}
