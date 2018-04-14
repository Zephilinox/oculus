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
                Vector3 head_forward_horizontal = new Vector3(head.transform.forward.x, 0, head.transform.forward.z);
                Vector3 head_forward_vertical = new Vector3(0, head.transform.forward.y, head.transform.forward.z);
                Vector3 dir = controller.transform.position - head.transform.position;

                if (Vector3.Distance(head.transform.position, controller.transform.position) < 0.6f
                    && Vector3.Distance(head.transform.position, controller.transform.position) > 0.25f &&
                    Vector3.Angle(head.transform.forward, dir) < 45)
                {
                    transform.position = controller.transform.position;
                }

                float y_axis;

                if (controller.name == "RightHand")
                {
                    y_axis = Input.GetAxis("Oculus_GearVR_RThumbstickY");
                }
                else if (controller.name == "LeftHand")
                {
                    y_axis = Input.GetAxis("Oculus_GearVR_LThumbstickY");
                }
                else
                {
                    y_axis = 0;
                    Debug.Log("uhoh");
                }

                if (y_axis != 0)
                {
                    float new_scale = y_axis + transform.localScale.x;
                    if (new_scale > 100)
                    {
                        new_scale = 100;
                    }
                    else if (new_scale < 10)
                    {
                        new_scale = 10;
                    }
                    transform.localScale = new Vector3(new_scale, new_scale, new_scale);
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
