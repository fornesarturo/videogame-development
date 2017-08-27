using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody rb;

    private static GameObject instance;

    // Property
    // - Better accessor methods.
    public static GameObject Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        instance = this.gameObject;
    }

    // Use this for initialization
    void Start () {

        // Retrieve a reference to a component.
        rb = GetComponent<Rigidbody>();

        // rb.AddForce(new Vector3(0, 500 , 0));
        // transform.up is unit vector.
        rb.AddForce(transform.up * 50, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
