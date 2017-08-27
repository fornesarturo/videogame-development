using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileController : MonoBehaviour {

    public Text displayText;
	// Use this for initialization
	void Start () {
        displayText.text = "";
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
            case "Player 1":
                Destroy(c.transform.gameObject);
                Debug.Log("Player 2 wins!");
                break;
            case "Player 2":
                Destroy(c.transform.gameObject);
                Debug.Log("Player 1 wins!");
                break;
        }
        Destroy(gameObject);
    }


}
