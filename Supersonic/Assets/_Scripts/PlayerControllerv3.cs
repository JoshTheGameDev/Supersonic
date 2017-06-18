using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

 //REMAKE SCRIPT, ADD WHEEL COLLIDERS & LESSONS LEARNED FROM CLASS

public class PlayerControllerv3 : MonoBehaviour {
	
	private Rigidbody rigidBody;

	public XboxController controller;

	public float movementSpeed = 60f;
	public float minSpeed = 10f;
	public float maxSpeed = GameManager.maxSpeed;
	public float boostSpeed = 2f;
	public float turnSpeed = 6f;

	public float maxMotorTorque = 4000.0f;

	// Too much of a pain to use both keyboard AND controller inputs at the same time.
	//public KeyCode forwardsKey = KeyCode.W;
	//public KeyCode backwardsKey = KeyCode.S;
	//public KeyCode moveLeftKey = KeyCode.A;
	//public KeyCode moveRightKey = KeyCode.D;
	//public KeyCode boostKey = KeyCode.Space;

	public bool isUsingController = false;
	public bool isUsingKeyboard = false;



	//================================================================ Things From Racing Sim tut =======================================================================================================================

	public GameObject startTimer;

	public List <WheelCollider> wheelList;
	public float enginePower = 250.0f;

	//public float steer = 0.0f;
	//public float maxSteer = 45.0f;
	public float playerSpeed;

	public Vector3 centerOfMass = new Vector3(0, -0.5f, 0.3f);

	public int currentCheckpoint = 0;
	public int cameraPointer = 0;

	public List<GameObject> cameraList;

	//===============================================================================================================================================================================================================================



	// Use this for initialization ===== Keep to functions unless needed. I like clean.
	void Start () {
		
		Debug.Log ("Max Speed is " + maxSpeed);
		GetRBComponents ();

	}

	void Update(){
		
		playerSpeed = GetComponent <Rigidbody> ().velocity.magnitude * 3.6f;
		ControllerCheck ();
		MakeCarGo ();

	}
		

	public void GetRBComponents(){
		rigidBody = GetComponent<Rigidbody> ();

		rigidBody.centerOfMass = centerOfMass;
	}

	//========================================================= Things from Racing Sim tut =================================================================================================================

	public void MakeCarGo(){

		if (startTimer.GetComponent<StartTimer> ().roundStarted == true)
		{
			float axisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
			float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
			Vector3 movement = new Vector3 (axisX, 0, axisZ);
			//rigidBody.AddForce (movement * movementSpeed); // not needed as force is being applied with the movement components (movement.x and movement.z)

						
			for (int i = 0; i < wheelList.Count; i++) {
				wheelList [i].motorTorque = enginePower * Time.deltaTime * 350.0f * movement.z;

				//Debug.Log (wheelList[i].motorTorque);


				//Ensure the player can't go faster than the max speed. **Not working

				if (rigidBody.velocity.magnitude > maxSpeed) {
					rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
					wheelList [i].attachedRigidbody.drag += 5f;
				}
			}
				
			wheelList [0].steerAngle = movement.x * turnSpeed;
			wheelList [1].steerAngle = movement.x * turnSpeed;
			wheelList [2].steerAngle = -movement.x * turnSpeed;
			wheelList [3].steerAngle = -movement.x * turnSpeed;
		}

			//===================================Cycle through Cameras========================================
			if (Input.GetKeyDown (KeyCode.Q) || XCI.GetButtonDown(XboxButton.LeftBumper)) {
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


	public void HitCheckPoint(int checkpointNumber){

		if (checkpointNumber == currentCheckpoint + 1) {
			currentCheckpoint = checkpointNumber;
		} else {
			Debug.Log ("Wrong Checkpoint for " + transform.name);  
		}
	}

	//=================================================== check for controller, if controller is being used, set bool "isUsingController" to true =============================================================================================================
	private void ControllerCheck(){
												// 0 = All controllers, 1 = First, 2 = Second, ect. Got values from XboxCtrlrInput script
		if (XCI.IsPluggedIn (1) == true) {		// Need to fix. P2 reads P1 controller for some reason.
			isUsingController = true;
			isUsingKeyboard = false;			 
		} 

		if (XCI.IsPluggedIn (2) == true) {
			isUsingController = true;
			isUsingKeyboard = false;

		} 


	}

}
