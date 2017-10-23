using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	public Waypoint[] neighbors;
	public List<Waypoint> history;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere (transform.position, 0.5f);
		Gizmos.color = Color.yellow;
		for(int i = 0; i < neighbors.Length; i++) {
			Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (transform.position, 0.5f);
		for(int i = 0; i < neighbors.Length; i++) {
			Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
		}
	}
}
