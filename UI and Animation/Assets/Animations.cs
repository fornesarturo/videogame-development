using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

	private Animator animator;
	private float life;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		if (Input.GetKeyDown (KeyCode.Return)) {
			life -= 20;
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			animator.SetTrigger ("buttonPressed");
		}
		animator.SetFloat ("speed", h);
		animator.SetFloat ("life", life);
	}

	void ActuallyDie() {
		Destroy (gameObject);
	}
}
