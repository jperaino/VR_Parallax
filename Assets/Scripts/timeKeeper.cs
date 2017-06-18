using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeKeeper : MonoBehaviour {

	Text timeText;
	float timeRemaining;
	int maxFall = 15;
	public bool isPlaying = false;
	public bool didPlay = false;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		timeText = GetComponent<Text> ();
	}

	public void startTimer () {
		timeText = GetComponent<Text> ();
		timeRemaining = 20000.0f;
		isPlaying = true;
		didPlay = true;
	}

	
	// Update is called once per frame
	void Update () {

		// If game is playing and time remains
		if (timeRemaining > 0) {
			timeRemaining -= Time.deltaTime;
			timeText.text = timeRemaining.ToString ("0.00");
			isPlaying = true;

		// If game is not playing
		} else {

			timeRemaining = 0;
			isPlaying = false;
			StartCoroutine ("allFallDown");
		
			if (didPlay == true) {
				timeText.text = "GAME OVER";
			} else {
				timeText.text = "Click start to begin";
			}

		}
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
