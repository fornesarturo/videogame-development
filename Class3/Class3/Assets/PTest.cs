using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTest : MonoBehaviour {

	public Waypoint a,b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Return)) {
			List<Waypoint> bw = PathFinding.Breadthwise (a, b);
			List<Waypoint> dw = PathFinding.Depthwise (a, b);
			List<Waypoint> aStar = PathFinding.AStar (a, b);

			for (int i = 0; i < bw.Count; i++) {
				print ("BREADTHWISE: " + bw [i].transform.name);
			}

			for (int i = 0; i < dw.Count; i++) {
				print ("DEPTHWISE: " + dw [i].transform.name);
			}

			for (int i = 0; i < aStar.Count; i++) {
				print ("A STAR: " + aStar [i].transform.name);
			}
		}
	}
}
