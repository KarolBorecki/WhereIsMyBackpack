using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int score = 0;
    public Text scoreInfo;
    [HideInInspector] public int startAmmo;

    private bool isDead = false;

    public LevelManager levelManager;

    void Start () {
        GetComponent<PlayerShoot>().setBullets(startAmmo);
		
	}
	
	void Update () {
		
	}
    public void die(){
        levelManager.OnPlayerDead();
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Coin"){
            score++;
            levelManager.CoinPickedUp();
            Destroy(collision.gameObject);
        }
    }
}
