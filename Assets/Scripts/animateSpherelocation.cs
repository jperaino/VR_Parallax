using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateSpherelocation : MonoBehaviour {

	List<Vector3> origins = new List<Vector3> ();
	List<Vector3> destinations = new List<Vector3> ();
	List<float> distances = new List<float> ();
	List<float> journeyLengths = new List<float> ();
	List<Vector3> vecPaths = new List<Vector3> ();

	public GameObject eye;

	float startTime = 0f;
	bool isClicked = false;
	bool isAnimating = false;

	float speed = 5.0F;
	//private float startTime;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Check if Triggered is true and assign it to a variable
//		if (GvrViewer.Instance.Triggered) {
//			isClicked = true;
//		}

		// Initialize vectors when triggered
		if (isClicked) {
			InitializeVectors ();

		}

		// Animate when triggered
		if (isAnimating) {
			for (int i = 0; i < this.gameObject.transform.childCount; i++) {
				var currentSphere = this.gameObject.transform.GetChild (i);

				float distCovered = (Time.time - startTime) * speed;
				float fracJourney = distCovered / journeyLengths [i];
				currentSphere.transform.position = Vector3.Lerp (origins [i], destinations [i], fracJourney);

				// Make balls editable again once animation has finished
				if (distCovered >= speed) {
					isAnimating = false;
				}

			}

		}

	}


	// Initialize vector values
	public void InitializeVectors() {
		isClicked = true;

		Vector3 eyeLocation = eye.transform.position;

		//Get origin points from spheres
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			//origins.Add (this.gameObject.transform.GetChild (i).transform.position);
			Vector3 origin = this.gameObject.transform.GetChild (i).transform.position;
			origins.Add (origin);

			//Get relationship to camera
			float dist = Vector3.Distance(eyeLocation, origin);
			distances.Add (dist);

			Vector3 vecPath = (origin - eyeLocation).normalized;
			vecPaths.Add (vecPath);

			//Calculate new point
			//PATTERN 0: ORIGINAL
			//			Vector3 newPosition = (vecPath * dist) + eyeLocation;

			//PATTERN 1: SINE CURVE
			Vector3 newPosition = (vecPath * dist * Mathf.Abs(Mathf.Sin(i))) + eyeLocation;
			destinations.Add (newPosition);

			//PATTERN 2: COSINE CURVE
			//			Vector3 newPosition = (vecPath * dist * Mathf.Abs(Mathf.Tan(i+j))) + eyeLocation;

			//PATTERN 3: Log CURVE
			//			Vector3 newPosition = (vecPath * dist * dist / 10f) + eyeLocation;

			//PATTERN 4: vertical skew
			//			Vector3 newPosition = (vecPath * dist * tempPosition.y/30) + eyeLocation;

			//PATTERN 4: vertical sin skew
			//			Vector3 newPosition = (vecPath * dist * Mathf.Abs(Mathf.Sin(tempPosition.y))) + eyeLocation;

			float journeyLength = Vector3.Distance (origin, newPosition);
			journeyLengths.Add (journeyLength);
		}

		isClicked = false;
		startTime += Time.time;
		isAnimating = true;
	}


	public void onClick () {
		Debug.Log ("you did it!!!!!!");
		isClicked = true;
	}

	public void scaleItUp() {
		this.gameObject.transform.localScale += new Vector3 (10, 10, 10);
	}

}
