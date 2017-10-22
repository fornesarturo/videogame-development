using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject projectile;
	private float speed = 3.0f;
	private Animator anim;
	private Rigidbody rigidBody;
	public int life = 10;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		life = 10;
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.velocity = new Vector3 ();
		Ray mousePositionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (mousePositionRay, out hit)) {
			if (hit.transform.name == "Ground") {
				transform.LookAt (hit.point);
			}
		}

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float max = Mathf.Max (Mathf.Abs(h), Mathf.Abs(v));

		anim.SetFloat ("Speed", max);

		transform.Translate (h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime, Space.World);

		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("Click 0 at time: " + Time.time);
			anim.SetTrigger ("Attack");
			GameObject clone = Instantiate (projectile, new Vector3(transform.position.x, 0.25f, transform.position.z), transform.rotation) as GameObject;
		}
	}

	void OnCollisionEnter(Collision c) {
		switch(c.transform.gameObject.tag) {
		case "EnemyProjectile":
			Destroy (c.transform.gameObject);
			Debug.Log ("Collision with EnemyProjectile at" + Time.time);
			anim.SetTrigger ("Hit");
			life--;
			if (life < 0) {
				anim.SetTrigger ("Dead");
				StartCoroutine (destroyGameObject());
			}
			break;
		case "Enemy":
			Debug.Log ("Collision with Enemy at" + Time.time);
			anim.SetTrigger ("Hit");
			life--;
			if (life < 0) {
				anim.SetBool ("Dead", true);
				StartCoroutine (destroyGameObject());
			}
			break;
			
		}
	}

	IEnumerator destroyGameObject() {
		yield return new WaitForSeconds(1.0f);
		Debug.Log ("Destroyed enemy at " + Time.time);
		Destroy (gameObject);
	}
}
