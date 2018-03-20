using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public float spawnDelay;
    public float timer;
    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            timer = 0;
            //GameObject gameobj = Instantiate(prefab);
            //gameobj.transform.position = transform.position;
            //gameobj.AddComponent<MoveTo>();
            //gameobj.GetComponent<MoveTo>().speed = speed;
        }
    }
}
