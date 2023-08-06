using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor : MonoBehaviour {

    public Texture portopen;
    public Texture portunlocked;

    void Start () {
		
	}
	
	void Update () {
        
    }
    private void OnCollisionEnter(Collision col)
    { 
            gameObject.GetComponent<Material>().mainTexture = portopen;
    }
    private void OnCollisionExit(Collision col)
    {
        gameObject.GetComponent<Material>().mainTexture = portunlocked;
    }
}
