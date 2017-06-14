using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeKeeper : MonoBehaviour {

	Text timeText;
	float timeRemaining;
	int maxFall = 15;
	//public bool isPlaying = false;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		timeRemaining = 25.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (timeRemaining > 0) {
			timeRemaining -= Time.deltaTime;
			timeText.text = timeRemaining.ToString ("0.00");

		} else {

			timeRemaining = 0;
			timeText.text = "GAME OVER";
			StartCoroutine ("allFallDown");
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
