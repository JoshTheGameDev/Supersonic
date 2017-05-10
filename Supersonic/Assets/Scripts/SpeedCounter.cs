using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCounter : MonoBehaviour {

	private GameObject player;
	private Text text;


	// Use this for initialization
	void Start () {
		text = this.gameObject.GetComponent<Text> ();
		player = GameObject.FindGameObjectWithTag ("pSpeed");

	}
	
	// Update is called once per frame
	void Update () {
		text = player.gameObject.GetComponent<PlayerController> ().playerSpeed;
	}
}
