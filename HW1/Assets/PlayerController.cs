using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int score;
    public float speed;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        //transform.SetPositionAndRotation(0, 1, -23);
        score = 0;
        speed = 20;
        SetScoreText();

    }
	
	// Update is called once per frame
	void Update () {
        
        float h = Input.GetAxisRaw("Horizontal"); // X
        float v = Input.GetAxisRaw("Vertical"); // Z

        transform.Translate(h * speed * Time.deltaTime,
                            0,
                            v * speed * Time.deltaTime);
	}

    public void TakeDamage () {
        score -= 5;
        SetScoreText();
        Debug.Log("You hit an enemy, your score is now: " + score);
    }

    public void Revive () {
        this.transform.position = new Vector3(0f, 1f, -23f);
    }

    void OnCollisionEnter (Collision c) {
        print("Collision with: " + c.transform.name);

        switch(c.transform.name) {
            case "EvilCube":
                TakeDamage();       
                break;
            case "Goal":
                score += 50;
                SetScoreText();
                Debug.Log("You hit the goal, your score is now: " + score);
                Revive();
                break;
        }
    }

    void SetScoreText() {
        scoreText.text = "Score: " + score.ToString();
    }
}
