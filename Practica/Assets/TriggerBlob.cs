using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlob : MonoBehaviour {

    private GameObject blob;
    private SpriteRenderer spriteJugador;
    private SpriteRenderer spriteBlob;

    // Use this for initialization
    private void Start () {
	}

    // Update is called once per frame
    private void Update () {
		
	}

    private void OnTriggerEnter (Collider collider)
    {
        Debug.Log("Has entrado crack");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Has salido makinote");
    }
}
