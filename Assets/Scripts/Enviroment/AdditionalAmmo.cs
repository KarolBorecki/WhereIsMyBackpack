using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalAmmo : MonoBehaviour {
    public int amount = 5;
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            PlayerShoot player = collision.gameObject.GetComponent<PlayerShoot>();
            player.addBullets(amount);
            player.move.audio.play(4);
            Destroy(gameObject);
        }
    }
}
