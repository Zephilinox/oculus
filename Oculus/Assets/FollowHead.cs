using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour {

    GameObject head;
    Quaternion rot;
    Vector3 pos;
    
	void Start ()
    {
        head = Camera.main.gameObject;
    }
    void Update ()
    { 
        transform.position = head.transform.position + head.transform.forward* 0.2f;
        transform.rotation = head.transform.rotation;
	}
}
