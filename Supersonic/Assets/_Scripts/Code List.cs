using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RockPaperScissors : MonoBehaviour {

	private int playerLives;
	private int enemyLives;
	private int randomNumber;

	public Text gameOutputText;
	public Text playerLifeCounter;
	public Text enemyLifeCounter;

	void Start () {

		playerLives = 3;
		enemyLives = 3;
		SetUpGame();

	}

	private void SetUpGame(){
		//Changte the text of the textbox
		gameOutputText.text = "Choose a move to make: Rock, Paper, Scissors";

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
		playerLifeCounter.text = playerLives.ToString ();
		enemyLifeCounter.text = enemyLives.ToString ();

	}
		

}