using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke("Deactivate", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
