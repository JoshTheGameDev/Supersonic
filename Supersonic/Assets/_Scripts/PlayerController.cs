using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


	public float powerUpSpeed;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode moveLeftKey = KeyCode.A;
	public KeyCode moveRightKey = KeyCode.D;

	public KeyCode boostKey = KeyCode.Space;

	public float playerSpeed;
	//public int enemyLives;

	public Text gameOutputText;
	public Text playerSpeedCounter;
	public Text enemyLifeCounter;

	[HideInInspector]
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		
		//enemyLives = 3;
		SetUpGame();
	}

	private void SetUpGame(){
		//Changte the text of the textbox
		//gameOutputText.text = "Choose a move to make: Rock, Paper, Scissors";

	}
	//Changte the text of the textbox
	public void ClickButton(int buttonClicked){

		if (buttonClicked == 1){
			gameOutputText.text = "You chose Rock";
		} else if (buttonClicked == 2){

			gameOutputText.text = "You chose Paper";
		} else if (buttonClicked == 3){

			gameOutputText.text = "You chose Scissors";
		} 

		gameOutputText.text = "Choose a move to make: Rock, Paper, Scissors?";
		playerSpeedCounter.text = playerSpeed.ToString ();
		//enemyLifeCounter.text = enemyLives.ToString ();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(forwardsKey))
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.right *
				-playerSpeed);

		//if (maxSpeed == 117);
	//gameObject.GetComponent<Rigidbody> ().AddForce (playerSpeed - playerSpeed);
	}

}
