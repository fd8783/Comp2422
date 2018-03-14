using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonopen : MonoBehaviour {

    static public bool listbuttonopen = false;

    public Button[] thisbut;

    private int[] buttonstate;
    private int openingbut = -1;
    private leftsidebut butscript;

	// Use this for initialization
	void Start () {
        buttonstate = new int[thisbut.Length];
        for (int i = 0; i < thisbut.Length; i++)
        {
            int tempInt = i;
            thisbut[i].onClick.AddListener(() => Click(tempInt));
            Debug.Log(buttonstate[i]+ " " + i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		/*if (openingbut >= 0)
        {
            openingbut = -2;
        }*/
	}

    public void Click(int num)
    {
        listbuttonopen = true;
        Debug.Log(num + "ask for open");
        for (int i = 0; i < thisbut.Length; i++)
        {
            butscript = thisbut[i].GetComponent(typeof(leftsidebut)) as leftsidebut;
            if (i == num)
            {
                Debug.Log(num + " " + buttonstate[num]);
                if (buttonstate[num] == 1)
                {
                    buttonstate[num] = 0;
                    butscript.open = false;
                    listbuttonopen = false;
                }
                else
                {
                    buttonstate[num] = 1;
                    butscript.open = true;
                    Debug.Log(num + "open");
                }
                Debug.Log(num + " " + buttonstate[num]);
            }
            else
            {
                butscript.open = false;
                buttonstate[i] = 0;
            }
        }

    }

}
