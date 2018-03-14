using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutor : MonoBehaviour {
    public static bool tutopen = true;

    public GameObject tutpanel;

    private Button tutbut;

	// Use this for initialization
	void Start () {
        tutbut = GetComponent<Button>();
        tutbut.onClick.AddListener(Click);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Click()
    {
        tutpanel.SetActive(true);
        tutopen = true;
    }
}
