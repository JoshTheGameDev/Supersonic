using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour {

	public WheelCollider[] wheels;
	Rigidbody rb;
	WheelAxle frontAxle;
	WheelAxle rearAxle;
	public float antiRollFront = 3000f;
	public float antiRollRear = 3000f;

	void Start()
	{
		frontAxle= new WheelAxle { LeftWheel = wheels[0], RightWheel = wheels[1], AntiRollForce = antiRollFront };
		rearAxle = new WheelAxle { LeftWheel = wheels[2], RightWheel = wheels[3], AntiRollForce = antiRollRear };
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		WheelHit hit;
		foreach (var wheel in wheels)
			if (wheel.GetGroundHit(out hit))
				rb.AddForceAtPosition(wheel.transform.up * AntiRollForce(wheel), wheel.transform.position);
	}

	float AntiRollForce(WheelCollider wheel)
	{
		WheelAxle axle;
		if (frontAxle.LeftWheel == wheel || frontAxle.RightWheel == wheel)
			axle = frontAxle;
		else
			axle = rearAxle;
		WheelHit hit;
		float travelL = 1f;
		float travelR = 1f;
		if (axle.LeftWheel.GetGroundHit(out hit))
			travelL = (-axle.LeftWheel.transform.InverseTransformPoint(hit.point).y - axle.LeftWheel.radius) / axle.LeftWheel.suspensionDistance;
		if (axle.RightWheel.GetGroundHit(out hit))
			travelR = (-axle.RightWheel.transform.InverseTransformPoint(hit.point).y - axle.RightWheel.radius) / axle.RightWheel.suspensionDistance;
		if (wheel == axle.LeftWheel)
			return -(travelL - travelR) * axle.AntiRollForce;
		return (travelL - travelR) * axle.AntiRollForce;
	}
}
