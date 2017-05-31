using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tie speed to player speed. Instead of default fast speed

public class SpeedLines : MonoBehaviour {

	public GameObject player;

	public float speed;
	Vector2 offset;

	void Update () {

		//Scrolls the texture across the Y axis 

		offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;

	}
}
