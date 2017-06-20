using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour {

	public int difficulty = 0;
	public GameObject objectMaker;
	public addSpheres sphereAdderScript;
	public GameObject preGameUI;
	public GameObject gameUI;
	public timeKeeper timeScript;
	public GameObject spheres;
	public GameObject scoreDisplay;
	public GameObject cameraHolder;

	public Text levelText;
	public Text scoreText;

	public static Vector3 eyeLocation = new Vector3 (12f, 6.5f, 0);

	public bool isPlaying = false;
	public bool didPlay = false;
	public bool didWin = false;
	public bool isAnimating = false;

	int levelScore;

	public static int level = 1;
	public static int totalScore = 0;

	// Use this for initialization
	void Start () {
		scoreText = scoreDisplay.GetComponent<Text> ();

		levelText = GameObject.Find ("levelText").GetComponent<Text>();
		levelText.text = level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		// Update score text if game is in session
		if (isPlaying == true) {
			levelScore = spheres.transform.childCount;
			scoreText.text = levelScore.ToString ();
		}

	}
		
	public void animationBegins () {
		Debug.Log ("animation is beginning");
		isAnimating = true;
		isPlaying = false;
		didPlay = false;
		didWin = false;

		sphereAdderScript.archCount = 25;
		sphereAdderScript.archSpacing = 1;

		preGameUI.SetActive (false);
		sphereAdderScript.beginSphereAssembly ();
		spheres.GetComponent<animateSpherelocation> ().onClick ();

	}


	public void gameBegins () {
		Debug.Log ("game is beginning");

		isAnimating = false;
		isPlaying = true;
		didPlay = true;
		didWin = false;


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
