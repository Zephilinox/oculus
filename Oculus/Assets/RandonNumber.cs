using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandonNumber : MonoBehaviour
{
    void Update ()
    {
        string my_string;
        my_string = Random.Range(0, 100).ToString();
        GetComponent<Text>().text = my_string;
	}
}
