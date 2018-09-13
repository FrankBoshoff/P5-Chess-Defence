using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public int wizardHealth;
    public Vector3 wizardPos;

    void OnCollisionExit(Collision collision)
    {
        this.gameObject.transform.position = wizardPos;
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
