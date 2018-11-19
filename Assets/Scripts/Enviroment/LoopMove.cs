using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMove : MonoBehaviour {

    public float speed = 5f;
    public float range = 10; 
    public bool vertical = true;

    private Vector2 turn;
    private float actuallrange;
    public int dir = -1;

    void Start()
    {
        turn = vertical ? Vector2.right : Vector2.up;
        actuallrange = range * dir;
    }

    void Update()
    {
        if (Mathf.RoundToInt(System.Math.Abs(actuallrange)) < range){
            Vector2 r = getTransformingValue();
            gameObject.transform.Translate(r);
            actuallrange += speed * dir * Time.deltaTime;
        }
        else
        {
            changeDirection();
        }

    }

    void changeDirection()
    {
        actuallrange = Mathf.RoundToInt(range - System.Math.Abs(actuallrange));
        dir *= -1;
    }

    public Vector2 getTransformingValue() { return turn * speed * dir * Time.deltaTime; }

}
