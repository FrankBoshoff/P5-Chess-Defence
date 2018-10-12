using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{

    public GameObject UImanager;

    public override void Death()
    {
        //add/change particals and sound
        print("Game Over");
        base.Death();
    }
}
