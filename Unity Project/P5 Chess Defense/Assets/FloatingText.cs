using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float destroyTime;
    public Vector3 ofset;
    
	void Start ()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += ofset;
	}
}

