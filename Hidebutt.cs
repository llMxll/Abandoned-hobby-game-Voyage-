using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidebutt : MonoBehaviour {
    public bool hidden = false;
    public Sprite Retract;
    public Sprite Expand;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onclick()
    {
        if (hidden == false)
        {
            GameObject[] moving = GameObject.FindGameObjectsWithTag("Inventory");
            foreach (GameObject move in moving)
            {
                move.transform.localPosition = move.transform.localPosition + new Vector3(-Inventory.inventorywidth, 0);
            }
            hidden = true;
            GetComponent<Image>().sprite = Expand;
        }
        else
        {
            GameObject[] moving = GameObject.FindGameObjectsWithTag("Inventory");
            foreach (GameObject move in moving)
            {
                move.transform.localPosition = move.transform.localPosition + new Vector3(Inventory.inventorywidth, 0);
            }
            hidden = false;
            GetComponent<Image>().sprite = Retract;
        }
    }
}
