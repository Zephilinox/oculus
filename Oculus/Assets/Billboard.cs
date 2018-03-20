using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = Camera.main.gameObject;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("billboard"))
        {
            g.transform.LookAt(player.transform);
            Vector3 rot = g.transform.rotation.eulerAngles;
            g.transform.rotation = Quaternion.Euler(-rot.x, rot.y - 180, 0);
        }
	}
}
