﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public static int scorePyOne = 0;
	public static int scorePyTwo = 0;
	Text Score;

	// Use this for initialization
	void Start () {
		Score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Score.text = scorePyOne + " vs " + scorePyTwo;
	}

    
}
