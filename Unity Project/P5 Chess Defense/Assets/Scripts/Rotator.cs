using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 r;

    void Update()
    {
        RotateDirection();
    }

    void RotateDirection()
    {
        transform.Rotate(r * Time.deltaTime);
    }
}
