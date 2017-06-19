using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehaviours : MonoBehaviour {

	public AudioClip impact;
	GvrAudioSource audio;
	GameObject timeKeeperHolder;
	GameObject gameLogic;
	bool gamePlayMode;

	// Use this for initialization
	void Start () {
		timeKeeperHolder = GameObject.Find ("RemainingTime");
		gameLogic = GameObject.Find ("gameLogic");
	}
	
	// Update is called once per frame
	void Update () {
		
		gamePlayMode = timeKeeperHolder.GetComponent<timeKeeper> ().isPlaying;
		//Debug.Log (gamePlayMode);
	}

	public void fallDown () {

		// Disable if scene is animating
		if (!gameLogic.GetComponent<gameLogic>().isAnimating) {

			// Test if the sphere is the winner
			if (this.gameObject.tag == "winningSphere") {
				// End the game
				Debug.Log ("you hit the winning sphere");
				gameLogic.GetComponent<gameLogic> ().gameIsWon ();
			}

			// Apply rigidbody so that the sphere falls
			this.GetComponent<Rigidbody> ().useGravity = true;
			this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

			// Move to spheresDone parent gameObject
			GameObject spheresDone = GameObject.Find ("spheresDone");
			this.gameObject.transform.parent = spheresDone.transform;
		}
	}
		

	void OnCollisionEnter()
	{
		// Do something only if gamePlayMode is true
		if (gamePlayMode == true) {

			// Play collision sound
			this.gameObject.GetComponent<GvrAudioSource> ().Play ();

		}
	}
		

}
