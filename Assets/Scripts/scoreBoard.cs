using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {

	Text scoreText;
	int score;
	public GameObject spheres;

	// Use this for initialization
	void Start () {

		scoreText = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		score = spheres.transform.childCount;
		scoreText.text = score.ToString();

	}
}
