using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour {

	public int difficulty = 0;
	public GameObject objectMaker;
	public addSpheres sphereAdderScript;
	public GameObject startButton;
	public GameObject gameUI;
	public timeKeeper timeScript;
	public GameObject spheres;
	public GameObject scoreDisplay;
	public GameObject cameraHolder;

	Text scoreText;

	public Vector3 eyeLocation = new Vector3 (12f, 6.5f, 0);

	public bool isPlaying = false;
	public bool didPlay = false;
	public bool didWin = false;

	int levelScore;

	public static int level = 1;
	public static int totalScore = 0;

	// Use this for initialization
	void Start () {
		scoreText = scoreDisplay.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Update score text if game is in session
		if (isPlaying == true) {
			levelScore = spheres.transform.childCount;
			scoreText.text = levelScore.ToString ();
		}

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
		cameraHolder.transform.position = eyeLocation;

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

		totalScore += levelScore;

		isPlaying = false;
		didPlay = true;
		didWin = true;

		Debug.Log ("isPlaying: " + isPlaying + ", didPlay: " + didPlay + ", didWin: " + didWin);

		gameLogic.level++;
		Debug.Log ("level: " + gameLogic.level + ", total score: " + totalScore);



	}



}
