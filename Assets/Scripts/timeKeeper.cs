using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeKeeper : MonoBehaviour {

	Text timeText;
	float timeRemaining;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		timeRemaining = 30.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		timeRemaining -= Time.deltaTime;
		timeText.text = timeRemaining.ToString("0.00");

	}
}
