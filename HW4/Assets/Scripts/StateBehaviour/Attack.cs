using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	private Animator anim;
	private Coroutine attacking;
	// Use this for initialization
	void Start () {
		Debug.Log ("ATTACK!");
		anim = GetComponent<Animator> ();
		attacking = StartCoroutine (attack ());
	}

//	void OnDestroy() {
//		StopCoroutine (attacking);
//	}

	IEnumerator attack() {
		while (true) {
			anim.SetTrigger ("Attack");
			yield return new WaitForSeconds (0.5f);
		}
	}
}
