﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public Transform target;

	public float distance = 8.0f;
	public float height = 3.0f;
	public float damping = 5.0f;

	public bool smoothRotation = true;
	public bool followBehind = true;

	public float rotationDamping = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 wantedPosition;
		if (followBehind)
			wantedPosition = target.TransformPoint (0, height, -distance);
		else
			wantedPosition = target.TransformPoint (0, height, distance);

		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
			
		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation (target.position - transform.position, target.up);
				
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		} else
			transform.LookAt (target, target.up);
	}
}
