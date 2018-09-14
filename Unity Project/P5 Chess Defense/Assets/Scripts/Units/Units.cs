using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public int health;

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Death();
        }
    }

}
