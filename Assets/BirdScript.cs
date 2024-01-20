using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    // If the bird hit a 2D-object: GameOver / Buff
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("GameController")) {
            logic.gameOver();
            birdIsAlive = false;
        } else if (collision.gameObject.CompareTag("Buff")) {
            if (Random.Range(0.0f, 1.0f) < 0.75f) {
                float rushStrength = Random.Range(1.0f, 2.5f);
                myRigidBody.velocity += Vector2.right * rushStrength;
            } else {
                myRigidBody.position += Vector2.right * 6;
            }
        }
    }
}
