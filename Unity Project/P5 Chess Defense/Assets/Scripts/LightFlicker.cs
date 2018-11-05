using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    private Light l;
    public float min;
    public float max;
    private float timer;
    public float time;

	// Use this for initialization
	void Start () {
        l = gameObject.GetComponent<Light>();
        timer = time;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            l.intensity = Random.Range(min, max);
            timer = time;
        }
	}
}
