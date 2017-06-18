using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeKeeper : MonoBehaviour {

	public GameObject gameLogicHolder;
	public gameLogic gameLogicScript;

	Text timeText;
	float timeRemaining;
	int maxFall = 15;
	public bool isPlaying;
	public bool didPlay;
	public bool didWin;
	public bool isAnimating;

	// Use this for initialization
	void Start () {
		gameLogicHolder = GameObject.Find ("gameLogic");
		gameLogicScript = gameLogicHolder.GetComponent<gameLogic> ();

		isPlaying = false;
		timeText = GetComponent<Text> ();

	}
		
	// Update is called once per frame
	void Update () {

		// Check on game status
		isPlaying = gameLogicScript.isPlaying;
		didPlay = gameLogicScript.didPlay;
		didWin = gameLogicScript.didWin;
		isAnimating = gameLogicScript.isAnimating;

		// If it's before the game has started
		if (!didPlay && !isAnimating) {
			timeText.text = "Click the sphere to begin";
	
		// Don't do anything during initial animation
		} else if (isAnimating) {
			timeText.text = "About to begin";
		// If game is playing and time remains
		} else {
			
			if (isPlaying && timeRemaining > 0) {
				timeRemaining -= Time.deltaTime;
				timeText.text = timeRemaining.ToString ("0.00");
				gameLogicScript.isPlaying = true;
			
				// Else if the player won the game
			} else if (didWin) {
				timeRemaining = 0;
				gameLogicScript.isPlaying = false;
				StartCoroutine ("allFallDown");

				timeText.text = "YOU WIN!";
					 
				// If game is not playing
			} else {

				timeRemaining = 0;
				gameLogicScript.isPlaying = false;
				StartCoroutine ("allFallDown");
			
				// If the player lost
				if (didPlay == true) {
					timeText.text = "GAME OVER";

					// If the game has not yet begun
				} else {
					timeText.text = "Click start to begin";
				}
			}
		}
	}


	public void startTimer () {

		// Get text component of display
		timeText = GetComponent<Text> ();

		// Set length of game
		timeRemaining = 20000.0f;

		// Update game status
		gameLogicScript.isPlaying = true;
		gameLogicScript.didPlay = true;

	}


	IEnumerator allFallDown () {

		GameObject spheres = GameObject.Find ("spheres");
		GameObject spheresDone = GameObject.Find ("spheresDone");
		//Debug.Log ("here");

		if (spheres.transform.childCount > maxFall) {
			//Debug.Log ("here 2");

			for (int i = 0; i < maxFall; i++) {

				int r = Random.Range (0, spheres.transform.childCount);

				GameObject sphere = spheres.transform.GetChild (r).gameObject;

				sphere.GetComponent<Rigidbody> ().useGravity = true;
				sphere.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				sphere.transform.parent = spheresDone.transform;
			
			}
				

		} else if (spheres.transform.childCount > 0) {

			GameObject sphere = spheres.transform.GetChild (0).gameObject;

			sphere.GetComponent<Rigidbody> ().useGravity = true;
			sphere.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			sphere.transform.parent = spheresDone.transform;

		} else {
			yield break;
		}


	}
		


}
