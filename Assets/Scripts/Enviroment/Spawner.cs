using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform enemy;
    public float spawnDelay = 2f;

    void Start(){
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
    }

    void SpawnObject(){
        Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
    }
}
