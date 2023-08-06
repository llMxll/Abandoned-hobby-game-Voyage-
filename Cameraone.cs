using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraone : MonoBehaviour {

    public float camspeed = 10;
    public float zoomspeed = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*camspeed, Input.GetAxis("Vertical") * Time.deltaTime * camspeed, 0f);
        Camera.main.orthographicSize = (Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomspeed);

        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            transform.position = new Vector3 (GameObject.Find("Playership").transform.position.x, transform.position.y, GameObject.Find("Playership").transform.position.z);
        }
	}
}
