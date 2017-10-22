using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {
	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		Debug.Log ("Gonna die now");
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = new Vector3 ();
		StartCoroutine (destroyGameObject());
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.velocity = new Vector3 ();
	}

	IEnumerator destroyGameObject() {
		yield return new WaitForSeconds(1.3f);
		Debug.Log ("Destroyed enemy at " + Time.time);
		Destroy (gameObject);
	}
}
