using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform cameraTarget;

    void Start () {
		
	}
	
	void Update () {
        transform.position = new Vector3(cameraTarget.position.x + 3, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
