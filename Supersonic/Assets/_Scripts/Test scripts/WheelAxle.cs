using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct WheelAxle
	{
		public WheelCollider LeftWheel { get; set; }
		public WheelCollider RightWheel { get; set; }
		public float AntiRollForce { get; set; }
	}

