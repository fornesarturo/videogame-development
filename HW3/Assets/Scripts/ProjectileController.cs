using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (transform.forward * 30, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible() {
		Destroy (transform.gameObject);
	}

//	void OnCollisionEnter(Collision c) {
//		switch(c.transform.gameObject.tag) {
//		case "Enemy":
//			Destroy(c.transform.gameObject);
//			Debug.Log("Collision with Brick");
//			break;
//		}
//		Destroy(gameObject);
//	}
}
