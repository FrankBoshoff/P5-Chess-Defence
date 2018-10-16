using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float destroyTime;
    public Vector3 ofset = new Vector3(0, 2, 0);
    //nog ff naar kijken
    public GameObject worldSprite;
    public Vector3 newOfset = new Vector3(2, 0, 0);
    
	void Start ()
    {
        var v = Instantiate(worldSprite, newOfset, Quaternion.identity);
        Destroy(v, destroyTime);

        Destroy(gameObject, destroyTime);
        transform.localPosition += ofset;
	}
}

