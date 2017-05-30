using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

 

public class PlayerControllerv2 : MonoBehaviour {
	
	private Rigidbody rigidBody;

	public XboxController controller;

	public float movementSpeed = 60f;
	public float minSpeed = 10f;
	public float maxSpeed = 100f;
	public float boostSpeed = 2f;
	public float magnetSpeed = 2f;
	public GameObject anchor;

	public Vector3 previousRotationDirection = Vector3.forward;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode moveLeftKey = KeyCode.A;
	public KeyCode moveRightKey = KeyCode.D;
	public KeyCode boostKey = KeyCode.Space;

	public bool isUsingController;
	public bool isUsingKeyboard;
	public bool isMagnetOn;

	public float controllerHorizontalSpeed = 2.0F;



	//===============================================================================================================================================================================================================================



	// Use this for initialization
	void Start () {
		
		rigidBody = GetComponent<Rigidbody> ();

	}

	void Update(){

		RotatePlayer ();

	}

	void FixedUpdate () {
		MovePlayer ();
	}



	private void MovePlayer(){

		//------------------------------------------------------------------------------Controller------------------------------------------------------------------------------------------------------

		if (isUsingController == true) {

			float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
			float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
			Vector3 movement = new Vector3 (axisX, 0f, axisZ);

			rigidBody.AddForce (movement * movementSpeed);


			if (rigidBody.velocity.magnitude > minSpeed) {
				rigidBody.velocity = rigidBody.velocity.normalized * minSpeed;
			}


			//------------------------------------------------------------------------Speed Boost code----------------------------------------------------------------------------------------------------
			if (XCI.GetAxis (XboxAxis.RightTrigger) >= 0.5f) {
				if (XCI.GetAxis (XboxAxis.LeftStickY) >= 0.5f) {
					
					rigidBody.velocity = rigidBody.velocity.normalized * movementSpeed * boostSpeed;
				}
			
			
			}
			//-------------------------------------------------------Ensure the player can't go faster than the max speed--------------------------------------------------------------------------------
			
			if (rigidBody.velocity.magnitude > maxSpeed) {
				rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
			}
			
			if (movementSpeed > maxSpeed) {
				rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
			}

		}

		//--------------------------------------------------------------------------------Keyboard-----------------------------------------------------------------------------------------------------------
		if (isUsingKeyboard == true) {
			
			if (Input.GetKey (KeyCode.W)) {
				gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * -movementSpeed*movementSpeed);
			}

			if (Input.GetKey (KeyCode.A)) {
				gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * -movementSpeed*movementSpeed);

			}

			if (Input.GetKey (KeyCode.S)) {
				gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * movementSpeed*movementSpeed);

			}

			if (Input.GetKey (KeyCode.D)) {
				gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * movementSpeed*movementSpeed);


			}

			if (rigidBody.velocity.magnitude > maxSpeed) {
         	rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
         }

			if (movementSpeed > maxSpeed) {
				rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
			}

		}


		//-----------------------------------------magnet to track------------------------------------------------------------------------------------------
		if (isMagnetOn == true){
		transform.position = Vector3.MoveTowards (transform.position, anchor.transform.position *2.5f, Time.deltaTime * magnetSpeed);
		}
	}
		//=====================================================================================================================================================

	private void RotatePlayer(){
		if (isUsingController == true) {
			float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
	
			float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);
	
			Vector3 directionVector = new Vector3 (rotateAxisX, 0f, rotateAxisZ);
	
			//Checks to see if the right thumbstick is not being used, if not, keep shooting in the same direction that it was previously
			if (directionVector.magnitude < 0.001f) {
				directionVector = previousRotationDirection;
			}
			directionVector = directionVector.normalized;
			previousRotationDirection = directionVector;
			transform.rotation = Quaternion.LookRotation (directionVector);
		}
		if (isUsingKeyboard == true) {
			
			float h = controllerHorizontalSpeed * Input.GetAxis("Mouse X");
			transform.Rotate(0f, h, 0f);

			float rotateMouseAxisX = Input.mousePosition.x;
			float rotateMouseAxisZ = Input.mousePosition.z;
			Vector3 directionVector = new Vector3 (rotateMouseAxisX, 0f, rotateMouseAxisZ);
		}
	}
}
