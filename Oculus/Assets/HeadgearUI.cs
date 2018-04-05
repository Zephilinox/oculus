using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadgearUI : MonoBehaviour 
{

	public bool insideHead;
	bool isAttached = false;
	public GameObject head;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isAttached) 
		{
			gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.15f - Camera.main.transform.up * 0.015f;
			gameObject.transform.rotation = Camera.main.transform.rotation;
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
	 
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Head")
		{
			gameObject.transform.GetChild (1).gameObject.SetActive (true);

			insideHead = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Head")
		{
			Debug.Log ("off head");
			//gameObject.transform.GetChild (0).gameObject.SetActive (true);
			gameObject.transform.GetChild (1).gameObject.SetActive (false);

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
