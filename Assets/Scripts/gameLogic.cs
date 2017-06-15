using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour {

	public int difficulty = 0;
	public GameObject objectMaker;
	public addSpheres sphereAdderScript;
	public GameObject startButton;
	public GameObject gameUI;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void gameIsEasy () {
		difficulty = 0;
	}

	public void gameIsHard () {
		difficulty = 1;
	}


	public void gameBegins () {
		Debug.Log ("game is beginning");
		sphereAdderScript.beginSphereAssembly ();
		startButton.SetActive (false);
		gameUI.SetActive (true);

	}



	public void Reset () {
		Application.LoadLevel (0);
	}





}
