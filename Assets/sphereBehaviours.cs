using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehaviours : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fallDown () {
		//Debug.Log ("You called it");
		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

	}
}
