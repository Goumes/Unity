using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Deactivate", 0.1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Deactivate()
    {
        if (transform.CompareTag("Submenu"))
        {
            gameObject.SetActive(false);
        }
    }
}
