using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject canvas;
    public GameObject red;
	void Update ()
    {
        if (canvas.activeInHierarchy)
        {
            red.SetActive(true);
        }
        else
        {
            red.SetActive(false);
        }
	}
}
