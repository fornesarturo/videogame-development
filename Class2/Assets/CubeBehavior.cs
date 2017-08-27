using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // print("H = " + h);
        // print("V = " + v);

        // OOP.
        transform.Translate(h * speed  * Time.deltaTime, 
                            v * speed * Time.deltaTime, 
                            0);

        // Time.deltaTime
        // - the amount of time in seconds between the last frame and the current one.
        // Example: transform.Translate(1  * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter(Collision c) {
        print("Collision enter with: " + c.transform.name);
        // Destroy(c.gameObject);
    }

    void OnCollisionStay(Collision c) {
        Debug.Log("collision stay");
        print("Collision stay");
    }

    void OnCollisionExit(Collision c) {
        print("Collision exit");
    }
}
