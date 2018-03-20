using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveshit : MonoBehaviour {

    bool dragging = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dragging)
        {
            GameObject controller = GameObject.FindGameObjectWithTag("RightController");
            transform.position = controller.transform.position;
        }
	}

    public void dragThingy()
    {
        Debug.Log("StarteInteracting");
        dragging = true;
    }

    public void stopDragThingy()
    {
        Debug.Log("StoppedInteracting");
        dragging = false;
    }
}
