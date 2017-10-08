using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour {

	Coroutine c;
	// Use this for initialization
	void Start () {
		// StartCoroutine (Example ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			c = StartCoroutine (Example ());
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			StopCoroutine (c);
			// Coroutines are related to a component (your script)
		}
	}

	// Coroutine
	// - A way to simulate concurrent behavior (SIMULATION )
	// - Coroutine methods must return IEnumerator
	// - When to use it:
	// - - repetitive task that you don't want to add to update
	// - - - shooting at a certain frequency, spawning points.
	// - - async task


	IEnumerator Example() {
		while (true) {
			yield return new WaitForSeconds (0.5f);
			print ("Hey, this works!");
		}
	}

}
