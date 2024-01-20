using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour {
    public GameObject Pipe;
    public GameObject GithubPower;
    public float spawnRate = 2.0f;
    private float timer = 0;
    private int pipeCounter = 0;
    public float heightOffset = 5;

    // Start is called before the first frame update
    void Start() {
        spawnPipe(transform.position.y);
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            float lowestPoint = transform.position.y - heightOffset;
            float heighestPoint = transform.position.y + heightOffset;
            float positionY = Random.Range(lowestPoint, heighestPoint);
            spawnPipe(positionY);
            pipeCounter += 1;
            timer = 0;
            if (pipeCounter % 10 == 0) {
                spawnGithubPower(positionY);
                if (spawnRate >= 1.2f) {
                    spawnRate -= 0.08f;
                }
            }
        }
    }

    void spawnPipe(float positionY) {
        Instantiate(
            Pipe, 
            new Vector3(transform.position.x, positionY, 0), 
            transform.rotation
        );
    }

    void spawnGithubPower(float positionY) {
        // The hard coding here aim at making the buff be the middle of the two pipe.
        Instantiate(
            GithubPower, 
            new Vector3(transform.position.x - 0.3f, positionY - 2.0f, 0), 
            transform.rotation
        );
    }
}
