using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisible : MonoBehaviour
{
    float timer;
    Color color;

    // Use this for initialization
    void Start ()
    {
        color = GetComponent<MeshRenderer>().material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (GetComponentInParent<HeadgearUI>().isAttached)
        {
            if (color.a > 0.01f)
            {
                timer += Time.deltaTime;
                if (timer >= 0.01f)
                {
                    color.a -= 0.02f;

                    GetComponent<MeshRenderer>().material.color = color;

                    timer = 0;
                }
            }
            else 
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            color.a = 1.0f;
            GetComponent<MeshRenderer>().material.color = color;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
