using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySineController : MonoBehaviour {
    
    private float speed = 7f;
    private Vector3 startPoint;

	// Use this for initialization
	void Start () {
        startPoint = transform.position;
	}

	// Update is called once per frame
	void Update () {
        float mv = 15 * Mathf.Sin(Time.time * speed);
        Vector3 fromPoint = startPoint;
        fromPoint.x += mv;
        this.transform.position = fromPoint;
        //if (Mathf.Abs(transform.position.x) >= 20) {
        //    speed *= -1;
        //}
        //transform.Translate(speed * Time.deltaTime,
        //                    0,
        //                    0
        //);
	}

    void OnCollisionEnter (Collision c) {
        c.gameObject.GetComponent<PlayerController>().TakeDamage();
    }
}