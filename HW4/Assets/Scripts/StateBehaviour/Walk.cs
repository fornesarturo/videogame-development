using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	private float speed = 3;
	// Use this for initialization
	void Start () {
		Debug.Log ("Just Walking...");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
	}
}
