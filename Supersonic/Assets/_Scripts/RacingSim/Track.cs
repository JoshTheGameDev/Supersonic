using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

	public List<Checkpoint> CheckPointList;
	
	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < CheckPointList.Count; i++) {
			CheckPointList [i].checkpointNumber = i + 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
