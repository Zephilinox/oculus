using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadgearUI : MonoBehaviour 
{
    Vector3 pos;
    Quaternion rot;
	public bool insideHead;
	public bool isAttached = false;
	public GameObject head;
	// Use this for initialization
	void Start () {
        head = Camera.main.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (isAttached)
        {
            gameObject.transform.position = head.transform.position + head.transform.forward * 0.1f - head.transform.up * 0.03f;
            gameObject.transform.rotation = head.transform.rotation;
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
	 
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Head")
		{
            for (int i = 1; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            insideHead = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Head")
        {
            for (int i = 1; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
			insideHead = false;
		}
	}

	public void OnGlassesDropped()
	{
		if (insideHead) 
		{
			Camera.main.GetComponent<HeadgearHead> ().equipedGlasses = gameObject;
			isAttached = true;

			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		} 
		else if (!insideHead) 
		{
			Camera.main.GetComponent<HeadgearHead> ().equipedGlasses = null;
		}
	}

	public void setAttached()
	{
		isAttached = false;
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
