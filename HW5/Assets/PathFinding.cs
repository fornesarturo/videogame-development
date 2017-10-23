using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding {
	public static List<Waypoint> BFS(Waypoint start, Waypoint end) {
		Queue<Waypoint> q = new Queue<Waypoint> ();
		List<Waypoint> result = new List<Waypoint> ();
		List<Waypoint> visited = new List<Waypoint> ();
		Waypoint current;

		start.history = new List<Waypoint> ();

		q.Enqueue (start);
		visited.Add (start);

		while (q.Count > 0) {
			current = q.Dequeue ();

			if (current == end) {
				result = current.history;
				result.Add (current);
			} else {
				for (int i = 0; i < current.neighbors.Length; i++) {
					Waypoint neighbor = current.neighbors[i];
					if (!visited.Contains (neighbor)) {
						q.Enqueue (neighbor);
						visited.Add (neighbor);
						neighbor.history = new List<Waypoint> (current.history);
						neighbor.history.Add (current);
					}

				}
			}
		}

		return result;
	}
}
