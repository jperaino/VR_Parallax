using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehaviours : MonoBehaviour {

	public AudioClip impact;
	GvrAudioSource audio;
	GameObject timeKeeperHolder;
	bool gamePlayMode;

	// Use this for initialization
	void Start () {
		timeKeeperHolder = GameObject.Find ("RemainingTime");
	}
	
	// Update is called once per frame
	void Update () {
		
		gamePlayMode = timeKeeperHolder.GetComponent<timeKeeper> ().isPlaying;
		//Debug.Log (gamePlayMode);
	}

	public void fallDown () {
		GameObject spheresDone = GameObject.Find ("spheresDone");

		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		this.gameObject.transform.parent = spheresDone.transform;

	}
		

	void OnCollisionEnter()
	{
		if (gamePlayMode == true) {
			this.gameObject.GetComponent<GvrAudioSource> ().Play ();
		}


		if (this.gameObject.tag == "winningSphere") {
			Debug.Log ("you hit the winning sphere");
		}

	}
		

}
