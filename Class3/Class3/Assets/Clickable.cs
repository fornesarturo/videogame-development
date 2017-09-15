using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Mouse events
    // All use raycasts.
    void OnMouseEnter() {
        print("Mouse entering");
    }

    void OnMouseOver() {
        print("Mouse over");
    }

    void OnMouseUp() {
        print("Mouse up");
    }

    void OnMouseUpAsButton() {
        print("Mouse click");
    }


}
