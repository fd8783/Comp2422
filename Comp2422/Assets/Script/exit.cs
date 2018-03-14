using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour {

    private Button exitbut;

	// Use this for initialization
	void Start () {
        exitbut = GetComponent<Button>();
        exitbut.onClick.AddListener(quit);
	}
	
	// Update is called once per frame
	void Update () {
    }

    void quit()
    {
        Application.Quit();
    }
}
