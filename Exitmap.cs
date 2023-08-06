using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitmap : MonoBehaviour {

    public Texture2D mapmaze;
    public Texture2D mapsandbox;


    void Start () {

    }

	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // Switch map
        Mapgen.currentmap = Mapgen.nextmap;


        // Switch next map
        if (Mapgen.currentmapno == 0)
        {
            Mapgen.nextmap = mapmaze;
            Mapgen.currentmapno = 1;
        }

        else
        {
            Mapgen.nextmap = mapsandbox;
            Mapgen.currentmapno = 0;
        }

        // Run mapgen       
        Mapgen.callmapchange = true;
    }
}
