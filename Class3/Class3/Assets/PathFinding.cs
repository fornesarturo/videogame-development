using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding {
    // Algorithm to find a route between paths.
    // Normally traversing a structure such as a graph.

    // 3 of them.
    // Breadthwise search (uninformed)
    // Depthwise search (uninformed)
    // A* (heuristic)

	// Uninformed - they don't use any data - no discrimination.
    public static List<Waypoint> Breadthwise(Waypoint start, Waypoint end) {
		Queue<Waypoint> work = new Queue<Waypoint> ();
		List<Waypoint> visited = new List<Waypoint> ();

		Waypoint current;
		work.Enqueue (start);
		visited.Add (start);

		start.history = new List<Waypoint> ();

		List<Waypoint> result = new List<Waypoint> ();

		while (work.Count > 0) {
			current = work.Dequeue ();
			if (current == end) {
				result = current.history;
				result.Add (current);
			}
			else {
				// Add the neighbors to the queue.
				for(int i = 0; i < current.neighbors.Length; i++) {
					Waypoint currentNeighbor = current.neighbors [i];
					if (!visited.Contains (currentNeighbor)) {
						work.Enqueue (currentNeighbor);
						visited.Add (currentNeighbor);
						currentNeighbor.history = new List<Waypoint> (current.history);
						currentNeighbor.history.Add (current);
					}
				}
			}
		}
		return result;
    }

	// Uninformed - they don't use any data - no discrimination.
    public static List<Waypoint> Depthwise(Waypoint start, Waypoint end) {
		Stack<Waypoint> stack = new Stack<Waypoint> ();
		List<Waypoint> visited = new List<Waypoint> ();

		stack.Push (start);
		visited.Add (start);
		start.history = new List<Waypoint> ();

		while (stack.Count > 0) {
			Waypoint actual = stack.Pop ();
			if (actual == end) {
				List<Waypoint> resultado = actual.history;
				resultado.Add (actual);
				return resultado;
			} 
			else {
				for (int i = 0; i < actual.neighbors.Length; i++) {
					Waypoint currentChild = actual.neighbors [i];
					if (!visited.Contains (currentChild)) {
						stack.Push (currentChild);
						visited.Add (currentChild);
						currentChild.history = new List<Waypoint> (actual.history);
						currentChild.history.Add (actual);
					}
				}
			}
		}
        return null;
    }

    public static List<Waypoint> AStar(Waypoint start, Waypoint end) {

		List<Waypoint> visited = new List<Waypoint> ();
		List<Waypoint> work = new List<Waypoint> ();

		work.Add (start);
		visited.Add (start);

		start.history = new List<Waypoint> ();
		start.g = 0;
		start.f = Vector3.Distance (start.transform.position, end.transform.position);

		while (work.Count > 0) {
			Waypoint actual = work [0];
			for (int i = 0; i < work.Count; i++) {
				if (work [i].f < actual.f) {
					actual = work [i];
				}
			}

			work.Remove (actual);

			if (actual == end) {
				List<Waypoint> result = actual.history;
				result.Add (actual);
				return result;
			}
			else {
				for (int i = 0; i < actual.neighbors.Length; i++) {
					Waypoint currentChild = actual.neighbors [i];
					if (!visited.Contains (currentChild)) {

						work.Add (currentChild);
						visited.Add (currentChild);

						currentChild.history = new List<Waypoint> (actual.history);
						currentChild.history.Add (actual);

						currentChild.g = actual.g + Vector3.Distance (actual.transform.position, currentChild.transform.position);
						currentChild.f = currentChild.g + Vector3.Distance (currentChild.transform.position, end.transform.position);

					}
				}
			}
		}
		return null;
    }

}
