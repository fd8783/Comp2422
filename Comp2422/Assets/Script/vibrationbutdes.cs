using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vibrationbutdes : MonoBehaviour {

    public int lightnum = 0;
    public Material Matcoveron, Matcoveroff, Matlighton, Matlightoff;

    private GameObject lighter;
    private Renderer coverRend, lighterRend;
    private GameObject parentball;
    private ballmovement ballscript;
    public Button relatebutton;
    private int butnum;
    public GameObject butlist;
    private leftsidebut butscript;
    private buttonopen butlistscript;

    // Use this for initialization
    void Start()
    {
        parentball = transform.root.gameObject;
        ballscript = parentball.GetComponent(typeof(ballmovement)) as ballmovement;
        butscript = relatebutton.GetComponent(typeof(leftsidebut)) as leftsidebut;
        butlistscript = butlist.GetComponent(typeof(buttonopen)) as buttonopen;
        coverRend = GetComponent<Renderer>();
        lighter = transform.Find("light").gameObject;
        lighterRend = lighter.GetComponent<Renderer>();
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

            if (Input.GetMouseButtonDown(2))
            {
                butlistscript.Click(butnum);
            }
        }
    }

    void OnMouseExit()
    {
        butscript.Left();
    }

    public void levelupdate(int level)
    {
        if (level == 0)
        {
            coverRend.sharedMaterial = Matcoveroff;
            lighterRend.sharedMaterial = Matlightoff;
        }
        else
        {
            if (level >= lightnum)
            {
                coverRend.sharedMaterial = Matcoveron;
                lighterRend.sharedMaterial = Matlighton;
            }
        }
        if (lightnum > level)
        {
            coverRend.sharedMaterial = Matcoveroff;
            lighterRend.sharedMaterial = Matlightoff;
        }
    }
}
