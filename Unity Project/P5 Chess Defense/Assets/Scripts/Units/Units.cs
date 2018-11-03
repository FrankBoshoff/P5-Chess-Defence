using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Units : MonoBehaviour
{
    public Image healthBar;
    public float startHealth;
    public float curHealth;

    void Start()
    {
        
        curHealth = startHealth;
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int dmg)
    {
        curHealth -= dmg;
        healthBar.fillAmount = curHealth / startHealth;
        if(curHealth <= 0)
        {
            Death();
        }
    }

}
