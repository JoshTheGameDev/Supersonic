using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartTimer : MonoBehaviour {

	public Text countdownText;

	[HideInInspector]
	public bool roundStarted = false;

	private float timeElapsed;

	private float roundTimer = 4.0f;

	private float count3 = 3.0f;
	private float count2 = 2.0f;
	private float count1 = 1.0f;
	private float count0 = 0.0f;

	private bool countdown = true;


	// Update is called once per frame
	void Update () {
		
		Timer ();
		CountDown ();
	}

	private void CountDown(){

		if (countdown == true) {
			
			if (timeElapsed >= count3) {

				countdownText.text = ("3");
				//Debug.Log ("3");
				return;
			}

			if (timeElapsed >= count2) {

				countdownText.text = ("2");
				//Debug.Log ("2");
				return;
			}

			if (timeElapsed >= count1) {

				countdownText.text = ("1");
				//Debug.Log ("1");
				return;
			}

			if (timeElapsed >= count0) {
				
				timeElapsed = 0.0f;
				countdownText.text = ("GO!");
				//Debug.Log ("Go!");
				roundStarted = true;
				return;
			}

			if (roundStarted == true) {
				Destroy (countdownText, 0.5f);
				return;
			}
		}

	}


	private void Timer(){
		
		timeElapsed = roundTimer -= Time.deltaTime;

	}



}
