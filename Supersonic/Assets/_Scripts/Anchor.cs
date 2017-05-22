using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {

	public GameObject track;
	public GameObject player;
	public bool isMagnetOn;	

	public float magnetSpeed = 2;

	private float yValue = track.transform.localPosition.y;

	// Update is called once per frame
	void FixedUpdate () {
		
		Magnet ();		
	}

	private void Magnet(){
		//magnet to track
		if (isMagnetOn == true){
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime * magnetSpeed);
		}
	}

}
