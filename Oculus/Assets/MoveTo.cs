using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
    public GameObject player;
    public float speed;

	// Use this for initialization
	void Start () {
        player = Camera.main.gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(player.name);
        if (collision.gameObject.name == player.name)
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
