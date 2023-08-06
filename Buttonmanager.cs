using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Changescene(string changescene)
    {
        SceneManager.LoadScene(changescene);
    }
    
    public void Quitbtn()
    {
        Application.Quit();
    }
}
