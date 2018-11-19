using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    void die(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "bullet"){
            FindObjectOfType<LevelManager>().EnemyKilled();
            die();
        }
    }

}
