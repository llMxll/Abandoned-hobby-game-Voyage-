using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapgen : MonoBehaviour {

    public static Texture2D currentmap;
    public static Texture2D nextmap;
    public static int currentmapno;
    public static bool callmapchange = false;

    public static Vector3 playerspawnpoint;

    public Texture2D staticcheck;
    public Texture2D staticcheck2;
    public int staticcheck3;

    public Texture2D startmap;
    public Texture2D secondmap;

    private int mapwidth;
    private int mapheight;
    private Color[] tilecolors;

    //ADD OBJECTS
    public Transform tilesteel;
    public Color tilesteelcolor;
    public Transform wallsteel;
    public Color wallsteelcolor;
    public Transform player;
    public Color playerspawnpointcolor;
    public Transform portlocked;
    public Color portlockedcolor;
    public Transform portunlocked;
    public Color portunlockedcolor;
    public Transform exit;
    public Color exitcolor;
    public Transform floorlight;
    public Color floorlightcolor;
    public Transform ionengine;
    public Color ionenginecolor;
    public Transform terminal;
    public Color terminalcolor;

    //ADD ITEMS
    public Transform medbottle;
    public Color medbottlecolor;
    public Transform crowbar;
    public Color crowbarcolor;
    public Transform handgun;
    public Color handguncolor;


    void Start () {

        currentmap = startmap;
        currentmapno = 0;
        nextmap = secondmap;
        loadmap () ;
	}
	
	void Update () {
		if (callmapchange == true)
        {
            loadmap();
            callmapchange = false;
        }
    }
   
    void loadmap ()
    {

        //Static check
        staticcheck = currentmap;
        staticcheck2 = nextmap;
        staticcheck3 = currentmapno;

        //Delete oldmap

        foreach (GameObject cleanuptagging in Object.FindObjectsOfType<GameObject>())
        {
            if (cleanuptagging.gameObject.tag != "GameController"
                && cleanuptagging.gameObject.tag != "MainCamera"
                && cleanuptagging.gameObject.tag != "Inventory"
                && cleanuptagging.gameObject.tag != "Quickbar")
            {
                cleanuptagging.gameObject.tag = "killme";
            }
        }
        GameObject[] cleanup = GameObject.FindGameObjectsWithTag("killme");
        foreach (GameObject clean in cleanup)
           Destroy(clean);
        
        // Initiate new map 

        mapwidth = currentmap.width;
        mapheight = currentmap.height;

        tilecolors = new Color [mapwidth * mapheight];
        tilecolors = currentmap.GetPixels();

//SPAWN OBJECTS and ITEMS
        for(int y = 0; y < mapheight; y++ )
        {
            for(int x = 0; x < mapwidth; x++)
            {
                if(tilecolors[x + y * mapwidth] == tilesteelcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == wallsteelcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(wallsteel, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == playerspawnpointcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    playerspawnpoint = new Vector3(x, y, 0);
                    Playermove.moveplayertospawn = true;
                }
                if (tilecolors[x + y * mapwidth] == portlockedcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(portlocked, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == portunlockedcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(portunlocked, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == exitcolor)
                {
                    Instantiate(exit, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == floorlightcolor)
                {
                    Instantiate(floorlight, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == ionenginecolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(ionengine, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == terminalcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(terminal, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == medbottlecolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(medbottle, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == crowbarcolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(crowbar, new Vector3(x, y, 0), Quaternion.identity);
                }
                if (tilecolors[x + y * mapwidth] == handguncolor)
                {
                    Instantiate(tilesteel, new Vector3(x, y, 0), Quaternion.identity);
                    Instantiate(handgun, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
}
