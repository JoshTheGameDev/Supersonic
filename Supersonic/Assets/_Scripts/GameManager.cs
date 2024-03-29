﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class GameManager : MonoBehaviour {

	public Text p1KphDisplay;
	public Text p2KphDisplay;
	public Text p1Laps;
	public Text p2Laps;

	public Rigidbody p1Rigidbody;
	public Rigidbody p2Rigidbody;

	private int lapCount;

	public static float maxSpeed = 100f;

	// Use this for initialization
	void Start () {

		p1Rigidbody = p1Rigidbody.GetComponent<Rigidbody> ();
		p2Rigidbody = p2Rigidbody.GetComponent<Rigidbody> ();

		lapCount = p1Rigidbody.GetComponent<PlayerControllerv3> ().currentCheckpoint;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Speedo ();

	}

	void FixedUpdate (){
		Reset ();
		Quit ();
		LapCounter ();
	}

	//------------------------------------------------------ Speedometer-----------------------------------------------------------
	private void Speedo(){ 
	
		float p1Kph = (float)(p1Rigidbody.velocity.magnitude * 3.6f);
		float p2Kph = (float)(p2Rigidbody.velocity.magnitude * 3.6f);

		float newP1Kph = Mathf.Round (p1Kph);
		float newP2Kph = Mathf.Round (p2Kph);

		p1KphDisplay.text = newP1Kph + " KPH";
		p2KphDisplay.text = newP2Kph + " KPH";
	}

	private void Reset(){
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	private void Quit(){
		if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.Back))
			Application.Quit();
	}

	private void LapCounter(){

		p1Laps.text = Laps.currentLap.ToString();
		p2Laps.text = Laps.currentLap.ToString();

	}
}
