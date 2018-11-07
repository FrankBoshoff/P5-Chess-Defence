using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float destroyTime;
    public Vector3 ofset;

    public float z;
    public float y;
    public float x;

    
	void Start ()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += ofset;


        transform.eulerAngles += new Vector3(x,y,z);
	    
    }
}

