using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateSpherelocation : MonoBehaviour {

	List<Vector3> origins = new List<Vector3> ();
	List<Vector3> destinations = new List<Vector3> ();
	List<float> distances = new List<float> ();
	List<float> journeyLengths = new List<float> ();
	List<Vector3> vecPaths = new List<Vector3> ();

	public GameObject eyeHolder;
	public GameObject winner;
	public GameObject colliderHolder;

	float startTime = 0f;
	bool isClicked = false;
	bool isAnimating = false;
	bool didFinishAnimating = false;
	bool isFoggy = false;
	bool needToPenalize = false;
	gameLogic gameLogicScript;

	float speed = 3.0F;

	public Color fogColor = new Color32 (0x00, 0x00, 0x51, 0xFF);

	// Select distortion method
	int caseSwitch;


	// Use this for initialization
	void Start () {
		gameLogicScript = GameObject.Find ("gameLogic").GetComponent<gameLogic> ();
		RenderSettings.fogDensity = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		isAnimating = gameLogicScript.isAnimating;

		// Initialize vectors when triggered
		if (isClicked) {
			InitializeVectors ();
		}
			
		// Animate when triggered
		if (isAnimating) {

			// Get camera location
			Vector3 eyeLocation = gameLogic.eyeLocation;

			// Set speed based on difficulty level
			if (gameLogic.level < 10.0f) {

				speed = 8.0f - gameLogic.level/2.0f;
			} else {
				speed = 3.0f / gameLogic.level;
			}

			// Animate spheres
			for (int i = 0; i < this.gameObject.transform.childCount; i++) {
				var currentSphere = this.gameObject.transform.GetChild (i);

				// Determine how far sphere should be at this point in time
				float distCovered = (Time.time - startTime) / speed;

				// Move sphere to new location
				currentSphere.transform.position = Vector3.Lerp (origins [i], destinations [i], distCovered);

				// Determine current sphere scale and apply
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
				if (distCovered >= 1) {
					
					gameLogicScript.isAnimating = false;
					didFinishAnimating = true;


					gameLogicScript.gameBegins ();
					eyeHolder.transform.position = gameLogic.eyeLocation;


				}

			}

		}

		if (!isAnimating && didFinishAnimating) {
			didFinishAnimating = false;
			determineWinningSphere ();

		}


		// Add fog to scene gradually
		if (isFoggy) {

			// If fog should be increasing, increase it
			if (RenderSettings.fogDensity < 0.15f) {
				RenderSettings.fogDensity += 0.01f;
			
			// Once fog is done increasing, penalize (if designated)
			} else if (needToPenalize) {
				spherePenalty ();
				needToPenalize = false;
				isFoggy = false;
			}
		}
	}


	// Initialize vector values
	public void InitializeVectors() {
		isClicked = true;

		Vector3 eyeLocation = gameLogic.eyeLocation;
		colliderHolder.transform.rotation = Random.rotation;

		caseSwitch = 4;
//		caseSwitch = Random.Range (0, 5);
		Debug.Log (caseSwitch);

		// Temporarily turn on collider object to test for collisions
		colliderHolder.SetActive (true);

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

		// Turn off raycatching geometry 
		colliderHolder.SetActive (false);

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

	public void addFog() {
		Debug.Log ("add fog");
//		RenderSettings.fog = true;
//		RenderSettings.fogColor = (fogColor);
//		RenderSettings.fogDensity = 0.15f;
//		RenderSettings.fogMode = FogMode.ExponentialSquared;

		isFoggy = true;

		Debug.Log (eyeHolder.GetComponent<Camera> ().clearFlags);
		eyeHolder.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
		Debug.Log (eyeHolder.GetComponent<Camera> ().clearFlags);
		eyeHolder.GetComponent<Camera> ().backgroundColor = fogColor;

		needToPenalize = true;
	}


	void determineWinningSphere() {

		Transform bestTarget = null;
		float furthestDistanceSqr = 0;

		foreach (Transform child in this.gameObject.transform) {
			
			Vector3 directionToTarget = child.position - gameLogic.eyeLocation;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget > furthestDistanceSqr) {
				furthestDistanceSqr = dSqrToTarget;
				bestTarget = child;
			}
		}

		bestTarget.parent = winner.transform;
		bestTarget.tag = "winningSphere";

	}



	public void spherePenalty() {

		Debug.Log ("penalizing");

		GameObject spheresAll = this.gameObject;

		int startCount = spheresAll.transform.childCount;

		for (int i = startCount - 1 ; i > 0; i--) {

			float rFloat = Random.value;
			GameObject spheresDone = GameObject.Find ("spheresDone");

			if (rFloat > 0.75f) {

				Transform currentSphere = spheresAll.transform.GetChild(i);
				currentSphere.GetComponent<Rigidbody> ().useGravity = true;
				currentSphere.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

				currentSphere.gameObject.transform.parent = spheresDone.transform;
			
			}


		}



		// !!BUG!! Fix would allow modulo or random to eliminate a percentage of spheres

		//		GameObject spheresAll = GameObject.Find ("spheres");
		//
		//		for (int i = 0; i < spheresAll.transform.childCount; i++) {
		//
		//			if (i%1 == 0) {
		//				Transform currentSphere = spheresAll.transform.GetChild(i);
		//				currentSphere.GetComponent<Rigidbody> ().useGravity = true;
		//				currentSphere.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		//
		//				GameObject spheresDone = GameObject.Find ("spheresDone");
		//				currentSphere.gameObject.transform.parent = spheresDone.transform;
		//
		//			}
		//		}
		//

	}


}
