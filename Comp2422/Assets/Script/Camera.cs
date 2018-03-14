using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Vector3 startpos, curpos;
    private float targetx;

	// Use this for initialization
	void Start () {
        startpos = transform.localPosition;
        targetx = startpos.x - 1.8f;
        curpos = startpos;
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonopen.listbuttonopen)
        {
            if (transform.localPosition.x >= targetx)
            {
                curpos = transform.localPosition;
                curpos.x = Mathf.Lerp(curpos.x, targetx - 0.1f, 0.2f);
                transform.localPosition = curpos;
            }
        }
        else
        {
            if (transform.localPosition.x < startpos.x)
            {
                curpos = transform.localPosition;
                curpos.x = Mathf.Lerp(curpos.x, startpos.x + 0.1f, 0.3f);
                transform.localPosition = curpos;
            }
        }
	}
}
