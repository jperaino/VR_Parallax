using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour {

	public int difficulty = 0;
	public GameObject objectMaker;
	public addSpheres sphereAdderScript;
	public GameObject startButton;
	public GameObject gameUI;
	public timeKeeper timeScript;

	public bool isPlaying = false;
	public bool didPlay = false;
	public bool didWin = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void gameIsEasy () {
		sphereAdderScript.archCount = 5;
		sphereAdderScript.archSpacing = 2;
		gameBegins ();
	}

	public void gameIsHard () {
		sphereAdderScript.archCount = 25;
		sphereAdderScript.archSpacing = 1;
		gameBegins ();
	}


	public void gameBegins () {
		Debug.Log ("game is beginning");
		sphereAdderScript.beginSphereAssembly ();
		startButton.SetActive (false);
		gameUI.SetActive (true);
		timeScript.startTimer ();

	}


	public void Reset () {
		Application.LoadLevel (0);
	}


	public void gameIsWon () {
		Debug.Log ("you win");

		isPlaying = false;
		didPlay = true;
		didWin = true;

	}



}
