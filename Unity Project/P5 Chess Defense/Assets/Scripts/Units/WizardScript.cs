using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public override void Death()
    {
        //change particals and sound
        Debug.Log("Game Over");
        base.Death();
    }
}
