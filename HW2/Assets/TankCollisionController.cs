using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankCollisionController : MonoBehaviour {

    public Text displayText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision c) {
        switch (c.transform.gameObject.tag) {
            case "Floor":
                Destroy(gameObject);
                Debug.Log("Collision with Floor");
                displayText.text = transform.gameObject.tag + " lost.";
                StartCoroutine("waitAndReload");
                break;
            case "Cannonball":
                displayText.text = transform.gameObject.tag + " lost.";
                Destroy(gameObject);
                StartCoroutine("waitAndReload");
                break;
        }
    }

    IEnumerator waitAndReload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(2f);
    }
}
