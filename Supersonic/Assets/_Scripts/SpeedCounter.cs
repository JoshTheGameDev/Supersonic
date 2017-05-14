using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCounter : MonoBehaviour {

	private GameObject player;
	private float speedText;



	// Use this for initialization
	void Start () {
		//speedText = this.gameObject.GetComponent<PlayerController>
		//player = GameObject.FindGameObjectWithTag ("pSpeed");
	}
	
	// Update is called once per frame
	void Update () {
		//speedText = player.gameObject.GetComponent<PlayerController> ().playerSpeed.ToString("0.###");
	}
}

