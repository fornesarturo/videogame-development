using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Waypoint[] path;
    public float treshold;

    private int current;

	// Use this for initialization
	void Start () {
        current = 0;
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 3, Space.World);

        float distance = Vector3.Distance(transform.position, path[current].transform.position);

        if(distance < treshold) {
            current++;
            current %= path.Length;
        }
	}
}
