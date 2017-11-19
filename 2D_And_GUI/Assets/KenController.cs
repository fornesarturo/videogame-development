using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenController : MonoBehaviour {

	private Animator anim;
	public float speed;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("Speed", h);
		transform.Translate (h * Time.deltaTime * speed, 0, 0);

		if (Input.GetKeyUp (KeyCode.Return)) {
			anim.SetTrigger ("Hadouken");
		}
	}
}
