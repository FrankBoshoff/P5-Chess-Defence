﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtSpin : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
	}
}
