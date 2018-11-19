using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    public float run = 1.3f;
    public float jump = 10f;
    public bool isgrounded = true;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool isWalking = false;
    public bool isrunning = false;

    private float runningAdd = 1f;
    [HideInInspector] public MenuAudio audio;

    void Start () {
        audio = FindObjectOfType<MenuAudio>();
    }

    void Update () {
        float x = Input.GetAxis("Horizontal");

        if (spriteRenderer.flipX ? (x > 0) : (x < 0)) spriteRenderer.flipX = !spriteRenderer.flipX;

        Vector2 transforming = Vector2.left * x * speed * Time.deltaTime * runningAdd;
        if (Input.GetButton("Run"))
        {
            animator.SetBool("Is Running", isrunning);
            isrunning = true;
            if(isgrounded)
                runningAdd = run;
        }
        else
        {
            animator.SetBool("Is Running", isrunning);
            isrunning = false;
            runningAdd = 1f;

        }
        transform.Translate(transforming);
        animator.SetFloat("Speed", Mathf.Abs(x));

        if (Mathf.Abs(x) <= 0) 
            isWalking = true;
        
        else isWalking = false;

        if (Input.GetButtonDown("Jump") && isgrounded){
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            animator.SetBool("Is Jumping", true);
        }

    }

    void OnCollisionStay2D(Collision2D Collision){
        if (Collision.gameObject.tag == "floor") isgrounded = true;
        
    }

    void OnCollisionEnter2D(Collision2D Collision){
        if (Collision.gameObject.tag == "floor") animator.SetBool("Is Jumping", false);
    }

    void OnCollisionExit2D(Collision2D Collision){
        if (Collision.gameObject.tag == "floor") isgrounded = false;

    }
}
