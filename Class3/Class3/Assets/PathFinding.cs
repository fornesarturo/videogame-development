using System.Collections;
using System.Collections.Generic;

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

		start.history = List<Waypoint> ();

		List<Waypoint> result = new List<Waypoint> ();

		while (work.Count > 0) {
			current = work.Dequeue ();
			if (current == end) {
				result = current.history;
				result.Add (current);
			} else {
				// Add the neighbors to the queue.
				for(int i = 0; i < current.neighbors.Length; i++) {
					Waypoint currentNeighbor = current.neighbors [i];
					if (!visited.Contains (currentNeighbor)) {
						work.Enqueue ();
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
        return null;
    }

    public static List<Waypoint> AStar(Waypoint start, Waypoint end) {
        return null;
    }

}
