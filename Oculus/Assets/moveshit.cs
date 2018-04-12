using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class moveshit : MonoBehaviour {

    bool dragging = false;
    bool move_ui = true;
    GameObject head;
    GameObject controller;
        
    void Start ()
    {
        head = Camera.main.gameObject;
    }
	
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
                if (Vector3.Distance(head.transform.position, controller.transform.position) < 0.5f
                    && Vector3.Distance(head.transform.position, controller.transform.position) > 0.2f)
                {
                    transform.position = controller.transform.position;
                }
            }
            float y_axis_left = Input.GetAxis("Oculus_GearVR_LThumbstickY");
            if (y_axis_left != 0)
            {
                float scale_speed = y_axis_left / 1;
                float new_scale = scale_speed + transform.localScale.x;
                if (new_scale > 100)
                {
                    new_scale = 100;
                }
                else if (new_scale < 1)
                {
                    new_scale = 1;
                }
                transform.localScale = new Vector3(new_scale, new_scale, new_scale);
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
