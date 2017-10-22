using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour {

	public GameObject enemyProjectile;
	private float xValue;
	// Use this for initialization
	void Start () {
		StartCoroutine (fireEnemyProjectile ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Gyzmos
	void OnDrawGizmos() {
		// Draw a sphere around the user.
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.5f);
		Gizmos.color = Color.yellow;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}

	IEnumerator fireEnemyProjectile() {
		while (true) {
			yield return new WaitForSeconds (0.5f);
			xValue = Mathf.Clamp (Random.value * 10, 0, 6.4f);
			GameObject clone = Instantiate (enemyProjectile, new Vector3 (transform.position.x + xValue, 0.25f, transform.position.z), transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce ( -1 * transform.forward * 30, ForceMode.Impulse);
		}
	}
}
