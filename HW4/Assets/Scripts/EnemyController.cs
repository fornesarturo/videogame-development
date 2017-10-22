using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Waypoint[] path;
	private float treshold = 1;
	private int current;
	private Animator anim;
	private Rigidbody rigidBody;
	private int life = 3;

	private State currentState;
	private Symbol a, d, w; 
	private MonoBehaviour currentBehaviour;

	void Start () {
		current = 0;
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();

		// State Machine
		a = new Symbol("angry");
		d = new Symbol ("dead");
		w = new Symbol ("walk");

		State attack = new State ("Attacking", typeof(Attack));
		State dead = new State ("Dead", typeof(Dead));
		State walk = new State ("Walk", typeof(Walk));

		attack.AddTransition (d, dead);
		attack.AddTransition (w, walk);

		walk.AddTransition (a, attack);
		walk.AddTransition (d, dead);

		currentState = walk;
		currentBehaviour = gameObject.AddComponent (currentState.Behaviour) as MonoBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(path[current].transform);


		float distance = Vector3.Distance(transform.position, path[current].transform.position);

		if(distance < treshold) {
			current++;
			current %= path.Length;
		}
	}

	void OnCollisionEnter(Collision c) {
		switch(c.transform.gameObject.tag) {
		case "Projectile":
			Destroy (c.transform.gameObject);
			Debug.Log ("Collision with Projectile at" + Time.time);
			anim.SetTrigger ("Hit");
			if (life > 0) {
				rigidBody.velocity = new Vector3 ();
				life--;
				anim.SetInteger ("Life", life);
				if (life == 0) {
					Apply (d);
				}
			}

			break;
		case "Player":
			Apply (a);
			break;
		}
	}

	void OnCollisionExit(Collision c) {
		switch (c.transform.gameObject.tag) {
		case "Player":
			Apply (w);
			break;
		}
	}

	void Apply(Symbol s) {
		State previous = currentState;
		currentState = currentState.ApplySymbol (s);
		if (previous != currentState) {
			Destroy (currentBehaviour);
			currentBehaviour = gameObject.AddComponent (currentState.Behaviour) as MonoBehaviour;
		}
	}

}
