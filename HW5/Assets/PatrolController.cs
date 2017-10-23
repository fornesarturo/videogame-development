using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour {

	public Waypoint[] defaultPath;
	private int current = 0;

	private float speed = 3;
	private float treshold = 1;

	private Vector3 clickedAt;
	private Stack<Waypoint> mission = new Stack<Waypoint>();
	private Waypoint currentWaypoint;

	void Start () {
		
	}

	void Update () {

		if (mission.Count > 0) {
			currentWaypoint = mission.Peek ();
			Debug.Log (currentWaypoint.transform.name);
		} else {
			Debug.Log ("Resuming normal patrolling");
			currentWaypoint = defaultPath [current];
		}

		transform.LookAt (currentWaypoint.transform);
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

		float distance = Vector3.Distance (transform.position, currentWaypoint.transform.position);

		if (distance < treshold) {
			if (mission.Count > 0) {
				mission.Pop ();		
			} else {
				current++;
				current %= defaultPath.Length;
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.name == "Floor") {
					clickedAt = hit.point;
					Waypoint closest = null;
					float minDistance = float.MaxValue;
					float ithDistance;
					int nextCurrent = current;
					for (int i = 0; i < defaultPath.Length; i++) {
						ithDistance = Vector3.Distance (clickedAt, defaultPath [i].transform.position);
						if (ithDistance < minDistance) {
							closest = defaultPath [i];
							minDistance = ithDistance;
							nextCurrent = i;
						}
					}
					if (closest != null) {
						Debug.Log ("Now walking towards: " + closest.name);
						List<Waypoint> whereToGo = PathFinding.BFS (defaultPath [current], closest);
						whereToGo.Reverse();
						mission = new Stack<Waypoint> (whereToGo);
						current = nextCurrent;
						Debug.Log ("Size of Mission = " + mission.Count);
						Debug.Log ("Size of Path = " + whereToGo.Count);
					}

				}
			}
		}


	}
}
