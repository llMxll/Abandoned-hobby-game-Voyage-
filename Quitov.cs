using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitov : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onclick()
    {
                Cammanager.setmaincamerato = 2;
                Cammanager.changethemaincamera = true;
        }
    }
