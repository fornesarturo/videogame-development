using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Waypoint[] path;
	private float treshold = 1;
	private int current;
	private Animator anim;
	private Rigidbody rigidBody;
	private float speed = 3;
	// Use this for initialization
	void Start () {
		current = 0;
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(path[current].transform);
		transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

		float distance = Vector3.Distance(transform.position, path[current].transform.position);

		if(distance < treshold) {
			current++;
			current %= path.Length;
		}
	}

	void OnCollisionEnter(Collision c) {
		switch(c.transform.gameObject.tag) {
		case "Projectile":
			speed = 0;
			rigidBody.velocity = new Vector3();
			Destroy (c.transform.gameObject);
			Debug.Log ("Collision with Projectile at" + Time.time);
			anim.SetTrigger ("Hit");
			StartCoroutine (destroyGameObject());
			break;
		}
	}

	IEnumerator destroyGameObject() {
		yield return new WaitForSeconds(1.5f);
		Debug.Log ("Destroyed enemy at " + Time.time);
		Destroy (gameObject);
	}
}
