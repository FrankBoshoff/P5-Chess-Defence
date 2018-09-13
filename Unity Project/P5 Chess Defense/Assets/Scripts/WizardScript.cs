using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    public int wizardHealth;
    public Vector3 wizardPos;

    void OnCollisionExit(Collision collision)
    {
        this.gameObject.transform.position = wizardPos;
    }
}
