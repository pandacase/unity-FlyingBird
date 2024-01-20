using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour {
    public GameObject Cloud;
    public float spawnRate = 2.4f;
    private float timer = 0;
    public float heightOffset = 5;

    // Start is called before the first frame update
    void Start() {
        spawnCloud();
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnCloud();
            timer = 0;
            spawnRate = Random.Range(1.2f, 3.6f);
        }
    }

    void spawnCloud() {
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;
        Instantiate(
            Cloud,
            new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), 
            transform.rotation
        );
    }
}
