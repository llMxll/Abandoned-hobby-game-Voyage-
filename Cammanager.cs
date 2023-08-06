using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammanager : MonoBehaviour {
    public static float setmaincamerato;
    public static bool changethemaincamera = false;

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;

    public GameObject quitov;
    public GameObject[] inventories;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (changethemaincamera == true)
        {
            changecam();
        }
    }

    void gotocam2()
    {
        setmaincamerato = 2;
        changecam();
    }

    void changecam()
    {
               if (setmaincamerato == 1)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            cam3.gameObject.SetActive(false);
            cam4.gameObject.SetActive(false);

            quitov.SetActive(true);

            inventories = GameObject.FindGameObjectsWithTag("Inventory");
            foreach (GameObject inv in inventories)
            {
                inv.SetActive(false);
            }
            inventories = GameObject.FindGameObjectsWithTag("Quickbar");
            foreach (GameObject inv in inventories)
            {
                inv.SetActive(false);
            }
        }

        if (setmaincamerato == 2)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            cam3.gameObject.SetActive(false);
            cam4.gameObject.SetActive(false);

            inventories = GameObject.FindGameObjectsWithTag("Inventory");
            foreach (GameObject inv in inventories)
            {
                inv.SetActive(true);
            }
            inventories = GameObject.FindGameObjectsWithTag("Quickbar");
            foreach (GameObject inv in inventories)
            {
                inv.SetActive(true);
            }
            quitov.SetActive(false);
        }
        changethemaincamera = false;
    }
}
