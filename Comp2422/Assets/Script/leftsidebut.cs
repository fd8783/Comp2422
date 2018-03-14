using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftsidebut : MonoBehaviour {

    private Vector3 startpos, curpos;
    public float targetx, opentargetx;
    private bool enter = false;
    public bool open = false;

	// Use this for initialization
	void Start () {
        startpos = transform.localPosition;
        targetx = 20 + startpos.x;
        opentargetx = 310 + startpos.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            if (transform.localPosition.x <= opentargetx)
            {
                curpos = transform.localPosition;
                curpos.x = Mathf.Lerp(curpos.x, opentargetx + 1, 0.2f);
                transform.localPosition = curpos;
            }
        }
        else
        {
            if (enter)
            {
                GetComponent<Image>().color = Color.green;
                if (transform.localPosition.x < targetx)
                {
                    curpos = transform.localPosition;
                    curpos.x = Mathf.Lerp(curpos.x, targetx + 1, 0.2f);
                    transform.localPosition = curpos;
                }
                else
                {
                    if (transform.localPosition.x >= targetx + 1)
                    {
                        curpos = transform.localPosition;
                        curpos.x = Mathf.Lerp(curpos.x, targetx, 0.3f);
                        transform.localPosition = curpos;
                    }
                }
            }
            else
            {
                GetComponent<Image>().color = Color.white;
                if (transform.localPosition.x > startpos.x)
                {
                    curpos = transform.localPosition;
                    curpos.x = Mathf.Lerp(curpos.x, startpos.x - 1, 0.3f);
                    transform.localPosition = curpos;
                }
            }
        }
    }

    public void Enter()
    {
        enter = true;
    }

    public void Left()
    {
        enter = false;
    }

}
