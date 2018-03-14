using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutpanel : MonoBehaviour {

    private GameObject parent;

	// Use this for initialization
	void Start () {
        parent = transform.gameObject;
	}

    // Update is called once per frame
    void Update() {
        if (parent.activeSelf)
        {
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
            {
                parent.SetActive(false);
                tutor.tutopen = false;
            }
        }
	}
}
