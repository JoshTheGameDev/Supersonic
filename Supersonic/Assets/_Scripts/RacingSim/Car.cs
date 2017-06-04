using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public GameObject startTimer;

	public List <WheelCollider> wheelList;
	public float enginePower = 150.0f;

	public float steer = 0.0f;
	public float maxSteer = 25.0f;

	public Vector3 centerOfMass = new Vector3(0, -0.5f, 0.3f);

	public int currentCheckpoint = 0;
	public int cameraPointer = 0;

	public List<GameObject> cameraList;



	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().centerOfMass = centerOfMass;
	}
	
	// Update is called once per frame
	void Update () {
		
		MakeCarGo ();

	}

	//============================================================================= Functions ============================================================================================================

	public void HitCheckPoint(int checkpointNumber){
		
		if (checkpointNumber == currentCheckpoint + 1) {
			currentCheckpoint = checkpointNumber;
		} else {
			Debug.Log ("Wrong Checkpoint for " + transform.name);
		}
	}


	public void MakeCarGo(){
		
		if (startTimer.GetComponent<StartTimer> ().roundStarted == true)
		{

			for (int i = 0; i < wheelList.Count; i++) {
				wheelList [i].motorTorque = enginePower * Time.deltaTime * 250.0f * Input.GetAxis ("Vertical");
			}
			//change negative to positive to flip turning angle
			wheelList [0].steerAngle = Input.GetAxis ("Horizontal") * maxSteer;
			wheelList [1].steerAngle = Input.GetAxis ("Horizontal") * maxSteer;

			if (Input.GetKeyDown (KeyCode.Q)) {
				cameraPointer++;
				if (cameraPointer + 1 > cameraList.Count) {
					cameraPointer = 0;
				}

				foreach (GameObject cam in cameraList) {
					cam.SetActive (false);
				}

				cameraList [cameraPointer].SetActive (true);
			}

		}
	}

}
