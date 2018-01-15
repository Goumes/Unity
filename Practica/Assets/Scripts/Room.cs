using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log(this.name);
        Debug.Log(collision.tag); //Arreglar el trigger de la camara, que al parecer no lo encuentra.
        if (this.name == "Habitacion_Simple_2" && collision.tag == "MainCamera")
        {
            camera.habitacion2 = true;
        }
    }
}
