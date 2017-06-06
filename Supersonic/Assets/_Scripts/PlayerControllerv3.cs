using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

 //REMAKE SCRIPT, ADD WHEEL COLLIDERS & LESSONS LEARNED FROM CLASS

public class PlayerControllerv3 : MonoBehaviour {
	
	private Rigidbody rigidBody;

	public XboxController controller;

	//public float movementSpeed = 60f;
	public float minSpeed = 10f;
	public float maxSpeed = 100f;
	public float boostSpeed = 2f;
	//public float magnetSpeed = 2f;

	//public Vector3 previousRotationDirection = Vector3.forward;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode moveLeftKey = KeyCode.A;
	public KeyCode moveRightKey = KeyCode.D;
	public KeyCode boostKey = KeyCode.Space;

	public bool isUsingController = false;
	public bool isUsingKeyboard = false;

	//public float controllerHorizontalSpeed = 2.0F;
	//public float sensitivity = 0.001f;


	//================================================================ Things From Racing Sim tut =======================================================================================================================

	public GameObject startTimer;

	public List <WheelCollider> wheelList;
	public float enginePower = 250.0f;

	public float steer = 0.0f;
	public float maxSteer = 45.0f;

	public Vector3 centerOfMass = new Vector3(0, -0.5f, 0.3f);

	public int currentCheckpoint = 0;
	public int cameraPointer = 0;

	public List<GameObject> cameraList;

	//===============================================================================================================================================================================================================================



	// Use this for initialization ===== Keep to functions unless needed. I like clean.
	void Start () {

		GetRBComponents ();

	}

	void Update(){

		ControllerCheck ();
		MakeCarGo ();
		RotatePlayer ();

	}
		

//===================================================================Rotate Player==============================================================================================

	private void RotatePlayer(){
				
			float rotateMouseAxisX = Input.mousePosition.x;
			float rotateMouseAxisZ = Input.mousePosition.z;
			Vector3 directionVector = new Vector3 (rotateMouseAxisX, 0f, rotateMouseAxisZ);

		if (isUsingController == true) {
			
		}

	}

	public void GetRBComponents(){
		rigidBody = GetComponent<Rigidbody> ();

		GetComponent<Rigidbody> ().centerOfMass = centerOfMass;
	}

	//========================================================= Things from Racing Sim tut =================================================================================================================

	public void MakeCarGo(){

		if (startTimer.GetComponent<StartTimer> ().roundStarted == true)
		{
			
			for (int i = 0; i < wheelList.Count; i++) {
			wheelList [i].motorTorque = enginePower * Time.deltaTime * 250.0f * Input.GetAxis ("Vertical");
			}
				
			wheelList [0].steerAngle = Input.GetAxis ("Horizontal") * maxSteer;
			wheelList [1].steerAngle = Input.GetAxis ("Horizontal") * maxSteer;


			//===================================Cycle through Cameras========================================
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

	public void HitCheckPoint(int checkpointNumber){

		if (checkpointNumber == currentCheckpoint + 1) {
			currentCheckpoint = checkpointNumber;
		} else {
			Debug.Log ("Wrong Checkpoint for " + transform.name);  
		}
	}

	//=================================================== check for controller, if controller is being used, set bool "isUsingController" to true =============================================================================================================
	private void ControllerCheck(){
												// 0 = All controllers, 1 = First, 2 = Second, ect.
		if (XCI.IsPluggedIn (1) == true) {		// Need to fix.
			isUsingController = true;
			isUsingKeyboard = false;
			 
		} 

		if (XCI.IsPluggedIn (2) == true) {
			isUsingController = true;
			isUsingKeyboard = false;

		} 

		if (XCI.IsPluggedIn (1) == false && XCI.IsPluggedIn (2) == false) {
			isUsingKeyboard = true;
		}

	}

}
