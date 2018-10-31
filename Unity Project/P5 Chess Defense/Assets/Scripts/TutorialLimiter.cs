using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLimiter : MonoBehaviour {

    public GameObject shop1;
    public GameObject shop2;
    public GameObject shop3;
    public GameObject shop4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnlockShop(int i)
    {
        if(i == 2)
        {
            shop1.SetActive(true);
        }
        if (i == 4)
        {
            shop2.SetActive(true);
        }
        if (i == 5)
        {
            shop3.SetActive(true);
        }
        if (i == 6)
        {
            shop4.SetActive(true);
        }
    }
}
