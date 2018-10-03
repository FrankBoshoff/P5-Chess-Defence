using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGallery : MonoBehaviour {

    public List<GameObject> Frames = new List<GameObject>();
    private int i;
    private Vector3 v;

	// Use this for initialization
	void Start () {
        i = 0;
        v = Frames[i].transform.position;
        v.x = Frames[i].transform.position.x + 9;
        transform.position = v;
        transform.eulerAngles = new Vector3(0, -90, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            i++;
            if(i > 36)
            {
                i = 0;
            }
            if(i >= 0 && i <= 15)
            {
                v = Frames[i].transform.position;
                v.x = Frames[i].transform.position.x + 9;
                transform.position = v;
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            if(i >= 16 && i <= 31)
            {
                v = Frames[i].transform.position;
                v.x = Frames[i].transform.position.x - 9;
                transform.position = v;
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            if(i == 32)
            {
                transform.position = new Vector3(8, 20, -18);
                transform.eulerAngles = new Vector3(30, -210, 0);
            }
            if (i == 33)
            {
                transform.position = new Vector3(-8.5f, 17, -18);
                transform.eulerAngles = new Vector3(30, -150, 0);
            }
            if (i == 34)
            {
                transform.position = new Vector3(0, 18, 60);
                transform.eulerAngles = new Vector3(30, -360, 0);
            }
            if (i == 35)
            {
                transform.position = new Vector3(7, 20, 62);
                transform.eulerAngles = new Vector3(30, -315, 0);
            }
            if (i == 36)
            {
                transform.position = new Vector3(-10, 18, 65);
                transform.eulerAngles = new Vector3(30, -405, 0);
            }
        }
		
	}
}
