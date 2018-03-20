using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class moveshit : MonoBehaviour {

    bool dragging = false;
    bool move_ui = true;
    GameObject head;
    GameObject controller;

    // Use this for initialization
    void Start () {
        head = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("UILock"))
        {
            move_ui = !move_ui;
        }

        if (dragging && move_ui)
        {
            controller = gameObject.GetComponent<NVRInteractableItem>().AttachedHands[0].gameObject;
            if (controller)
            {
                if (Vector3.Distance(head.transform.position, controller.transform.position) < 0.5f)
                {
                    transform.position = controller.transform.position;
                }
            }
        }
	}

    public void dragThingy()
    {
        Debug.Log("StartedInteracting");
        dragging = true;
    }

    public void stopDragThingy()
    {
        Debug.Log("StoppedInteracting");
        dragging = false;
    }
}
