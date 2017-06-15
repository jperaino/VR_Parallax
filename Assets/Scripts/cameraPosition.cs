using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour {

	float stepSize = 3.0f;
	int position;
	int positionCount = 4;
	float movementSpeed = 3f;
	public GameObject movingUI;
	public GameObject eye;
	string easeing = "linear";

	// Use this for initialization
	void Start () {
		position = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void rightClick () {

		// If the player isn't too far to the right
		if (position != positionCount) {

			// Generate new position
			Vector3 newPos = eye.transform.position;
			newPos.x += stepSize;

			// Tween between current and new position
			iTween.MoveTo (eye,
				iTween.Hash (
					"position", newPos,
					"time", movementSpeed,
					"easetype", easeing
				)
			);

			position += 1; // increment position
		
		}
			
	}

	public void leftClick () {

		// If the player isn't too far to the right
		if (position != 0) {

			// Generate new position
			Vector3 newPos = eye.transform.position;
			newPos.x -= stepSize;

			// Tween between current and new position
			iTween.MoveTo (eye,
				iTween.Hash (
					"position", newPos,
					"time", movementSpeed,
					"easetype", easeing
				)
			);

			position -= 1; // decrement position

		}
			
	}



}
