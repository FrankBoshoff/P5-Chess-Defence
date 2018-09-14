using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public int health;

    public virtual void Death()
    {
        if (health <= 0)
        {
            //play particals and sound
            Destroy(gameObject);
        }
    }
}
