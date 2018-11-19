using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private LoopMove loopmove;
    public List<GameObject> tome;
    private void Start()
    {
        foreach (GameObject i in tome)
        {
            i.transform.parent = transform;
        }
    }
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision){
        collision.gameObject.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
