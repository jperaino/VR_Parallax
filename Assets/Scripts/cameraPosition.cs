using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour {

	float stepSize = 5.0f;
	int position = 2;
	int positionCount = 4;
	bool isPressed = false;
	bool isAscending = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Check if Triggered is true and assign it to a variable
		if (GvrViewer.Instance.Triggered) {
			isPressed = true;
		}

		// Move if triggered
		if (isPressed) {

			//Check if isAscending
			if (isAscending) {

				this.gameObject.transform.Translate (stepSize, 0, 0, Space.World); // move eye
				position += 1; // increment position

				//Check if maxed out 
				if (position == positionCount) {
					isAscending = false;
				}
			} else {
				this.gameObject.transform.Translate ((stepSize * -1), 0, 0, Space.World); // move eye
				position -= 1; // increment position

				//Check if minned out
				if (position == 0) {
					isAscending = true;
				}
			}
				
			isPressed = false;
		}


	}
}
