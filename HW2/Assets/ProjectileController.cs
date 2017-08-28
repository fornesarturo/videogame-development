using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProjectileController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision c) {
        switch(c.transform.gameObject.tag) {
            case "Brick":
                Destroy(c.transform.gameObject);
                Debug.Log("Collision with Brick");
                break;
        }
        Destroy(gameObject);
    }
}
