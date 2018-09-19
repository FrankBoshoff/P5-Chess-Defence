using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    //Dit script is tijdelijk om te testen als alles werkt gooi ik hem weg //Jorrit
    public GameObject projectal;
    public ParticleSystem partical;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectal.SetActive(true);
        }
        if (partical.IsAlive() == false)
        {
            projectal.SetActive(false);
        }
    }

}
