using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttondes : MonoBehaviour {
    
    private GameObject parentball;
    private ballmovement ballscript;
    public Button relatebutton;
    private int butnum;
    public GameObject butlist;
    private leftsidebut butscript;
    private buttonopen butlistscript;

	// Use this for initialization
	void Start () {
        parentball = transform.root.gameObject;
        ballscript = parentball.GetComponent(typeof(ballmovement)) as ballmovement;
        butscript = relatebutton.GetComponent(typeof(leftsidebut)) as leftsidebut;
        butlistscript = butlist.GetComponent(typeof(buttonopen)) as buttonopen;
        for (butnum = 0; butnum < butlistscript.thisbut.Length; butnum++)
        {
            if (butlistscript.thisbut[butnum] == relatebutton)
            {
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {   if (!tutor.tutopen)
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
}
