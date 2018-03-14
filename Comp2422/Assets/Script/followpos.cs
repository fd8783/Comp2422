using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followpos : MonoBehaviour {

    public Transform followtarget;

    private Vector3 curpos;
    private float origindiff, curdiff;

	// Use this for initialization
	void Start () {
        origindiff = followtarget.position.x - transform.position.x;
        curpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        curdiff = followtarget.position.x - transform.position.x;
        if (origindiff != curdiff)
        {
            curpos = transform.position;
            curpos.x = (curdiff - origindiff);
            transform.position = curpos;
        }
	}
}
