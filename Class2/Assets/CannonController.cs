using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public float speed;
    public GameObject original;
    private GameObject tube;

	// Use this for initialization
	void Start () {
        // Way to retrieve a reference.
        // Can return null reference exception.

	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(0, 0, h * speed * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0, 0, 10 * speed * v * Time.deltaTime));

        // Instancing
        // - We cannot create a new gameobject from scratch.
        // - We have to clone.
        if(Input.GetAxis("Jump") == 1) {
            // Quaternion
            // - 4 value vector
            // - Describe a rotation in 3D space
            GameObject clone = Instantiate(original, transform.position, transform.rotation) as GameObject;

            // Retrieve a reference to someone else's components
            Rigidbody rbClone = clone.GetComponent<Rigidbody>();  
        }
	}
}
