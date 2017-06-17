using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSpheres : MonoBehaviour {

	public GameObject objectToCreate;
	public GameObject eye;
	public GameObject spheres;
	public int archCount;
	public float archSpacing;
	public int caseSwitch;

	List<float> xVals = new List<float>();
	List<float> yVals = new List<float>();
	//List<GameObject> spheres = new List<GameObject>();



	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//updateSphereLocations (spheres);
	}
		

	public void beginSphereAssembly () {

		caseSwitch = 2 ;
//		caseSwitch = Random.Range (0, 2);
		Debug.Log (caseSwitch);

		// POPULATE SPHERES
		switch (caseSwitch)
		{
		case 0: // ARCHWAY
			populateArchway ();
			break;
		case 1: // CYLINDER
			populateCylinder ();
			break;
		case 2: // CUBE
			populateCube ();
			break;
		default:
			break;
		}





	}


	// Instantiate spheres
	public void assembleSpheres () {

		for (int i = 0; i < xVals.Count; i++) {
			for (int j = 0; j < archCount; j++) {

				// initialize position from rhino model
				var initPosition = new Vector3 (xVals [i] + Random.Range (-0.005f, 0.005f), yVals [i], j * archSpacing);
						
				// instantiate sphere at points
				var newSphere = GameObject.Instantiate (objectToCreate, initPosition, Quaternion.identity);
				newSphere.transform.parent = spheres.transform;

			}
		}

	}


	public void updateSphereLocations (List<GameObject> spheres) {

		for (int i = 0; i < spheres.Count; i++) {
			spheres [i].transform.Translate (0, -2.5f * Time.deltaTime, 0, Space.World);
		}

	}


	void populateArchway () {

		// ADD x VALUES! Automate this, please. 
		xVals.Add (11.295607f);
		xVals.Add (	10.628941f);
		xVals.Add (	9.962274f);
		xVals.Add (	13.962274f);
		xVals.Add (	13.295607f);
		xVals.Add (	12.628941f);
		xVals.Add (	11.962274f);
		xVals.Add (	9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (	9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (9.962274f);
		xVals.Add (10.017022f);
		xVals.Add (10.208814f);
		xVals.Add (10.525104f);
		xVals.Add (10.943435f);
		xVals.Add (11.434104f);
		xVals.Add (11.962274f);
		xVals.Add (12.490444f);
		xVals.Add (12.981114f);
		xVals.Add (13.399444f);
		xVals.Add (13.715734f);
		xVals.Add (13.907526f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		xVals.Add (13.962274f);
		//xVals.Add (13.962274f);

		// ADD y VALUES! Automate this, please. 
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (2.589428f);
		yVals.Add (3.123938f);
		yVals.Add (3.658449f);
		yVals.Add (4.192959f);
		yVals.Add (4.727469f);
		yVals.Add (5.26198f);
		yVals.Add (5.79649f);
		yVals.Add (6.331f);
		yVals.Add (6.86551f);
		yVals.Add (7.400021f);
		yVals.Add (7.934531f);
		yVals.Add (8.464754f);
		yVals.Add (8.961966f);
		yVals.Add (9.390878f);
		yVals.Add (9.721036f);
		yVals.Add (9.928999f);
		yVals.Add (10.0f);
		yVals.Add (9.928999f);
		yVals.Add (9.721036f);
		yVals.Add (9.390878f);
		yVals.Add (8.961966f);
		yVals.Add (8.464753f);
		yVals.Add (7.93453f);
		yVals.Add (7.40002f);
		yVals.Add (6.86551f);
		yVals.Add (6.331f);
		yVals.Add (5.796489f);
		yVals.Add (5.261979f);
		yVals.Add (4.727469f);
		yVals.Add (4.192959f);
		yVals.Add (3.658449f);
		yVals.Add (3.123938f);
		//yVals.Add (2.589428f);

		assembleSpheres ();

	}


	void populateCylinder () {

		float cylRadius = 5f;
		int cylPtCount = 40;
		Vector3 cylCenter = GameObject.Find ("GvrViewerMain").transform.position;
		Debug.Log (cylCenter);
		float height = 20f;

		for (int j = 0; j < height; j++) {
			for (int i = 0; i < cylPtCount; i++) {

				float degrees = ((360f / cylPtCount) * i);
				float radians = degrees * Mathf.PI / 180f;

				float posX = Mathf.Cos (radians) * cylRadius + cylCenter.x;
				float posZ = Mathf.Sin (radians) * cylRadius + cylCenter.z;


				// initialize position from rhino model
				var initPosition = new Vector3 (posX, j/2, posZ);

				// instantiate sphere at points
				var newSphere = GameObject.Instantiate (objectToCreate, initPosition, Quaternion.identity);
				newSphere.transform.parent = spheres.transform;


			}
		}
	}



	void populateCube () {
		
		// Define cube dimensions and spacing
		float edgeCount = 10f;
		float ptSpc = 1f;

		// Calculate amount to move cube to center on camera
		Vector3 cubeCenter = GameObject.Find ("GvrViewerMain").transform.position;
		Vector3 cA = new Vector3 (cubeCenter.x - ptSpc*(edgeCount-1)/2 , cubeCenter.y - ptSpc*(edgeCount-1)/2, cubeCenter.z - ptSpc*(edgeCount-1)/2);

		// populate cube
		for (int k = 0; k < 2; k++) {  						// Generate opposite sides
			for (int j = 0; j < edgeCount; j++) {			// Generate rows
				for (int i = 0; i < edgeCount; i++) {		// Generate columns

					// Add minor variation to location to prevent spheres from sticking on top of each other
					cA += new Vector3 (Random.Range (-0.005f, 0.005f), Random.Range (-0.005f, 0.005f), Random.Range (-0.005f, 0.005f));

					// Populate horizontal planes
					var initPosition = new Vector3 (i*ptSpc, k * (edgeCount - 1) * ptSpc, j*ptSpc);
					initPosition += cA;
					var newSphere = GameObject.Instantiate (objectToCreate, initPosition, Quaternion.identity);
					newSphere.transform.parent = spheres.transform;

					// Populate left and right planes
					var initPosition2 = new Vector3 (i*ptSpc, j*ptSpc,  k * (edgeCount - 1) * ptSpc);
					initPosition2 += cA;
					var newSphere2 = GameObject.Instantiate (objectToCreate, initPosition2, Quaternion.identity);
					newSphere2.transform.parent = spheres.transform;

					// Populate front and back planes
					var initPosition3 = new Vector3 (k * (edgeCount - 1) * ptSpc, j*ptSpc,  i*ptSpc);
					initPosition3 += cA;
					var newSphere3 = GameObject.Instantiate (objectToCreate, initPosition3, Quaternion.identity);
					newSphere3.transform.parent = spheres.transform;

				}
			}
		}
	}

}
