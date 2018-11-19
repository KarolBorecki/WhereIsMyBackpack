using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWall : MonoBehaviour {
    public float pushForce = 500f;
    public bool right = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (right ? 1 : -1) * pushForce);
    }
}
