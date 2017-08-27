using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // lifecycle.
    // all monobehaviors have a lifecycle.

    void Awake() {
        // same as start but runs before.
        // runs even on disabled game objects.
        print("Good Morning :D");
    }

    // Use this for initialization.
    // - run once when an object is created.
    void Start () {
        Debug.Log("I'M ALIVE! LET ME LIVE, PLEASE!");
    }

    // Update is called once per frame.
    // - game loop.
    // - fps framerate is measured with this.
    
    // update runs once per frame.
    // - user input (responsiveness)
    // - motion / animation (smoother)
    void Update () {
        if ( Input.GetKeyDown(KeyCode.A) ) {
            Debug.Log("Key Down");
        }
        if ( Input.GetKey(KeyCode.A) ) {
            Debug.Log("Key");
        }
        if ( Input.GetKeyUp(KeyCode.A) )
        {
            Debug.Log("Key Up");
        }
        if ( Input.GetMouseButtonDown(0) )
        {
            Debug.Log("Left Click!");
        }
	}

    // you can configure a specific framerate.
    void FixedUpdate () {
        
    }

    // happens after Update each frame.
    void LateUpdate () {
        
    }
}
