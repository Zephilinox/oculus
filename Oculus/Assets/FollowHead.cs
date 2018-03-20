using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour {

    GameObject head;

	// Use this for initialization
	void Start () {
        head = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = head.transform.position + head.transform.forward * 0.2f;
        transform.position += head.transform.up * 0.3f;
        transform.rotation = head.transform.rotation;
	}
}
