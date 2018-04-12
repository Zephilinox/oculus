using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideyBar : MonoBehaviour
{
    bool empty = false;

    void Update ()
    { 
        if (GetComponent<Image>().fillAmount <= 0)
        {
            empty = true;
        }
        else if (GetComponent<Image>().fillAmount >= 1)
        {
            empty = false;
            
        }
        if (empty)
        {
            GetComponent<Image>().fillAmount += Time.deltaTime * 0.1f;
        }
        else
        {
            GetComponent<Image>().fillAmount -= Time.deltaTime * 0.1f;
        }
	}
}
