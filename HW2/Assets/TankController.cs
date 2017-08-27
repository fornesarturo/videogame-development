using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public GameObject cannonBall;

    private float speed = 10f;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.parent.Translate(h * speed * Time.deltaTime, 0, 0, Space.Self);
        transform.GetChild(0).Rotate(new Vector3(10 * speed * v * Time.deltaTime, 0, 0));

        // Instancing
        // - We cannot create a new gameobject from scratch.
        // - We have to clone.
        if (Input.GetKeyDown(KeyCode.F)) {
            GameObject clone = Instantiate(cannonBall, transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).position, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(transform.GetChild(0).up * 18, ForceMode.Impulse);
        }
    }
}
