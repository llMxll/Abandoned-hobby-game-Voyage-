﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handlecanvas : MonoBehaviour {

    private CanvasScaler scaler;
	// Use this for initialization
	void Start () {
        scaler = GetComponent<CanvasScaler>();

        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
