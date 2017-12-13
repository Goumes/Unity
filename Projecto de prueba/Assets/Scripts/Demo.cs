using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Comenzando shavale...");
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
	}
}
