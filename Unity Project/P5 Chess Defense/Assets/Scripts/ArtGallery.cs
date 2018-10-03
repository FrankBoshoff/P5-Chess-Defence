using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArtGallery : MonoBehaviour {

    public List<GameObject> Frames = new List<GameObject>();
    private int i;
    private Vector3 v;
    public bool b;
    public Button button;
    public GameObject menu;

	// Use this for initialization
	void Start () {
        menu.SetActive(false);
        b = true;
        i = -1;
        v = new Vector3(0, 24, -37);
        transform.position = v;
        transform.eulerAngles = new Vector3(15, 0, 0);
        button.onClick.AddListener(Back);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if(b == true)
            {
                Time.timeScale = 0;
                b = false;
                menu.SetActive(true);
                v = new Vector3(0, 24, -37);
                transform.position = v;
                transform.eulerAngles = new Vector3(15, 0, 0);
            }
            else
            {
                Time.timeScale = 1;
                b = true;
                menu.SetActive(false);
            }
        }

        if (b == true && (Input.GetKeyDown("left") || Input.GetKeyDown("right")))
        {
            if (Input.GetKeyDown("right"))
            {
                i++;
            }
            if (Input.GetKeyDown("left"))
            {
                i--;
            }
            if(i > 36)
            {
                i = 0;
            }
            if(i < 0)
            {
                i = 36;
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

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
