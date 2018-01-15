using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    Vector3 lastPosition;
    Transform player;
    public bool habitacion2;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Character").GetComponent<Transform> ();
        lastPosition = player.position;
        habitacion2 = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Recoger la ultima posicion en la que ha estado el jugador
        Vector3 delta = player.position - lastPosition;
        //Sumarle esta diferencia a la camara
        /*this.transform.position += delta;*/
        if (habitacion2 && lastPosition.y < 27.39 && lastPosition.y > 17.83)
        {
            Debug.Log(this.transform.position.y);
            this.transform.position += new Vector3(0, delta.y, 0);
        }
        //Guarda posicion para el siguiente frame
        lastPosition = player.position;
    }
}
