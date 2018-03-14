using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftsidebutrecover : MonoBehaviour {

    private Vector3 startpos, curpos;
    private float targetx;

    // Use this for initialization
    void Start()
    {
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
        if (transform.localPosition.x > startpos.x)
        {
            curpos = transform.localPosition;
            curpos.x = Mathf.Lerp(curpos.x, startpos.x - 1, 0.4f);
            transform.localPosition = curpos;
        }
    }
}
