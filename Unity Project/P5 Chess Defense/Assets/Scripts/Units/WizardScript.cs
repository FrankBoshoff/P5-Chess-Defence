using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : Units
{
    public override void Death()
    {
        //add/change particals and sound
        print("Game Over");
        base.Death();
    }
}
