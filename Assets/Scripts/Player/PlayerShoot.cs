using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {
    public Rigidbody2D bullet;
    public Transform barrel;
    public Animator animator;

    public Text bulletInfo;
    public float bulletspeed;
    public float shootDelay = 0.1f;
    [HideInInspector]public int shootsLeft = 0;

    private float actualShootDelay;
    [HideInInspector]public PlayerMovement move;

    void Start () {
        actualShootDelay = shootDelay;
        move = GetComponent<PlayerMovement>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	void Update () {
        actualShootDelay -= Time.deltaTime;

        if (actualShootDelay<=0) animator.SetBool("Is Attacking", false);
        
        if (Input.GetButton("Fire1") && actualShootDelay <= 0 && shootsLeft > 0 && move.isWalking && move.isgrounded)
            Shoot();

    }

    void Shoot(){
        animator.SetBool("Is Attacking", true);
        Rigidbody2D bulletRig = Instantiate(bullet, barrel.position, barrel.rotation) as Rigidbody2D;
        move.audio.play(3);
        bulletRig.AddForce(new Vector2(bulletspeed, 0) * (move.spriteRenderer.flipX ? -1 : 1));
        actualShootDelay = shootDelay;
        addBullets(-1);
    }

    public void addBullets(int amount){
        setBullets(shootsLeft += amount);
    }

    public void setBullets(int amount){
        shootsLeft = amount;
        bulletInfo.text = shootsLeft.ToString();
    }
}
