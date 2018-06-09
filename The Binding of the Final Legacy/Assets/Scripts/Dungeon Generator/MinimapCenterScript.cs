using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCenterScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) //Esto estaba en collision2D
    {
        if (collision.transform.CompareTag("Center"))
        {
            if (collision.gameObject.transform.parent.GetComponentInChildren<MinimapRoom>().serialNumber > gameObject.transform.parent.GetComponentInChildren<MinimapRoom>().serialNumber)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
