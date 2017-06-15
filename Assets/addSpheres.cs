using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSpheres : MonoBehaviour {

	public GameObject objectToCreate;
	public GameObject eye;
	public GameObject spheres;
	public int archCount;
	public float archSpacing;

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


}
