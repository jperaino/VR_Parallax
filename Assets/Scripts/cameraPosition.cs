using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour {

	float stepSize = 3.0f;
	int position;
	int positionCount = 4;
	public GameObject movingUI;
	public GameObject eye;

	// Use this for initialization
	void Start () {
		position = 2;
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void rightClick () {

		if ( position != positionCount) {

			eye.transform.Translate (stepSize, 0, 0, Space.World); // move eye
			movingUI.transform.Translate (stepSize, 0, 0, Space.World);
			position += 1; // increment position

		}
	}

	public void leftClick () {

		if ( position != 0) {
			eye.transform.Translate ((stepSize * -1), 0, 0, Space.World); // move eye
			movingUI.transform.Translate ((stepSize * -1), 0, 0, Space.World);
			position -= 1; // increment position

		}

	}



}
