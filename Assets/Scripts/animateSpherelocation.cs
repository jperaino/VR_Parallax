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
	public GameObject winner;
	public GameObject colliderHolder;

	float startTime = 0f;
	bool isClicked = false;
	bool isAnimating = false;

	float speed = 100.0F;

	// Select distortion method
	int caseSwitch;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		// Initialize vectors when triggered
		if (isClicked) {
			InitializeVectors ();

		}
			
		// Animate when triggered
		if (isAnimating) {

			Vector3 eyeLocation = eye.transform.position;

			List<GameObject> children = this.gameObject.GetChildren ();

			for (int i = 0; i < this.gameObject.transform.childCount; i++) {
				var currentSphere = this.gameObject.transform.GetChild (i);

				float distCovered = (Time.time - startTime) * speed;

				float fracJourney = distCovered / journeyLengths [i];

				currentSphere.transform.position = Vector3.Lerp (origins [i], destinations [i], fracJourney);

				float newDistance = Vector3.Distance (eyeLocation, currentSphere.transform.position);
				float scaleProportion = newDistance / distances[i];

				float x = scaleProportion * .15f;
				currentSphere.transform.localScale = new Vector3 (x, x, x);


				// Asign color to spheres on animation
				// This feature has been turned off because of a bug in the GVR SDK
				// To turn on, uncomment and assign the 'Unlit/Color' shader to the sphere prefab

//				float cA = Random.value; 
//				float cB = Random.value;
//				float cC = Random.value; 
//				children[i].GetComponent<Renderer>().material.color = new Color (cA,cB,cC,1);


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
		determineWinningSphere ();

		Vector3 eyeLocation = eye.transform.position;

		caseSwitch = 4;
//		caseSwitch = Random.Range (0, 5);
		Debug.Log (caseSwitch);

		//Get origin points from spheres
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {

			//origins.Add (this.gameObject.transform.GetChild (i).transform.position);
			Vector3 origin = this.gameObject.transform.GetChild (i).transform.position;
			origins.Add (origin);

			// Initialize new position
			Vector3 newPosition = origin;

			//Get relationship to camera
			float dist = Vector3.Distance(eyeLocation, origin);
			distances.Add (dist);

			Vector3 vecPath = (origin - eyeLocation).normalized;
			vecPaths.Add (vecPath);

			// Calculate new points based on distortion model
			switch (caseSwitch)
			{
			case 0: // SINE CURVE
				newPosition = (vecPath * dist * Mathf.Abs (Mathf.Sin (i))) + eyeLocation;
				break;
			case 1: // LOG CURVE
				newPosition = (vecPath * dist * dist / 10f) + eyeLocation;
				break;
			case 2: // VERTICAL SKEW
				newPosition = (vecPath * dist * origins[i].y/30) + eyeLocation;
				break;
			case 3: // VERTICAL SINE SKEW
				newPosition = (vecPath * dist * Mathf.Abs(Mathf.Sin(origins[i].y))) + eyeLocation;
				break;
			case 4: // RAYCAST INTERSECTION

				Collider coll = colliderHolder.GetComponent<Collider> ();

				Ray ray = new Ray (eyeLocation, vecPath);
				RaycastHit hit;

				if (coll.Raycast (ray, out hit, 10000f)) {
					newPosition = hit.point;
				}
				break;

			default:
				break;
			}

			destinations.Add (newPosition);

			// Calculate relationship between new and old positions
			float journeyLength = Vector3.Distance (origin, newPosition);
			journeyLengths.Add (journeyLength);

		}

		isClicked = false;
		startTime += Time.time;
		isAnimating = true;
	}


	public void onClick () {
		isClicked = true;
	}

	public void scaleItUp() {
		this.gameObject.transform.localScale += new Vector3 (10, 10, 10);
	}


	public void determineWinningSphere() {

		// Randomly select sphere
		int ct = this.gameObject.transform.childCount;
		int rnd = Random.Range (0, ct);
		Transform winningSphere = this.gameObject.transform.GetChild (rnd);

		// Assign winning sphere to winning parent gameObject
		winningSphere.parent = winner.transform;

	}


}
