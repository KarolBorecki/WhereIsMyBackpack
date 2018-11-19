using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 1f;

    void Start(){
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
