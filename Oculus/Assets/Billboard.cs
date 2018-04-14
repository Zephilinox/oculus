using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update ()
    {
        GameObject player = Camera.main.gameObject;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("billboard"))
        {
            if ((player.transform.rotation.eulerAngles.x <= 30
                || (player.transform.rotation.eulerAngles.x <= 360
                && player.transform.rotation.eulerAngles.x >= 320))
                || g.GetComponent<NewtonVR.NVRInteractableItem>().IsAttached)
            {
                g.transform.LookAt(player.transform);
                Vector3 rot = g.transform.rotation.eulerAngles;

                g.transform.rotation = Quaternion.Euler(-rot.x, rot.y - 180, player.transform.rotation.eulerAngles.z);
            }
        }
    }
}
