using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerbutdes : MonoBehaviour
{

    private float presstime = 0f;
    private bool press = false,thisclick = false;

    private GameObject parentball;
    private GameObject buttonmodel;
    private Vector3 startpos, movepos;
    private ballmovement ballscript;
    public Button relatebutton;
    private int butnum;
    public GameObject butlist;
    private leftsidebut butscript;
    private buttonopen butlistscript;

    private AudioSource[] clicksound;
    private AudioSource onclicksound;
    private AudioSource offclicksound;

    // Use this for initialization
    void Start()
    {
        parentball = transform.root.gameObject;
        ballscript = parentball.GetComponent(typeof(ballmovement)) as ballmovement;
        butscript = relatebutton.GetComponent(typeof(leftsidebut)) as leftsidebut;
        butlistscript = butlist.GetComponent(typeof(buttonopen)) as buttonopen;
        buttonmodel = transform.Find("buttonmodel").gameObject;
        startpos = buttonmodel.transform.localPosition;
        movepos = startpos;
        movepos.z -= 0.05f;
        clicksound = GetComponents<AudioSource>();
        onclicksound = clicksound[0];
        offclicksound = clicksound[1];
        for (butnum = 0; butnum < butlistscript.thisbut.Length; butnum++)
        {
            if (butlistscript.thisbut[butnum] == relatebutton)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (!tutor.tutopen)
        {
            butscript.Enter();
            //Debug.Log("button");
            if (Input.GetMouseButtonDown(0))
            {
                PlaySound(true);
                press = true;
                thisclick = true;
                presstime = Time.time;
                if (ballscript.started)
                {
                    ballscript.levelchange();
                }
                buttonmodel.transform.localPosition = movepos;
            }
            if (Input.GetMouseButton(0))
            {
                if (press && thisclick)
                {
                    if (Time.time - presstime > 3f)
                    {
                        ballscript.turnonoff();
                        thisclick = false;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                PlaySound(false);
                press = false;
                buttonmodel.transform.localPosition = startpos;
            }

            if (Input.GetMouseButtonDown(2))
            {
                butlistscript.Click(butnum);
            }
        }
        
    }

    void OnMouseExit()
    {
        butscript.Left();
        press = false;
        buttonmodel.transform.localPosition = startpos;
    }

    void PlaySound(bool onoff)
    {
        if (onoff)
        {
            onclicksound.Play();
            offclicksound.Stop();
        }
        else
        {
            onclicksound.Stop();
            offclicksound.Play();
        }
    }
}
