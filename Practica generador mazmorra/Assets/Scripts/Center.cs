using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour {

    private AddRoom room;

    // Use this for initialization
    void Start () {
        room = GetComponentInParent<AddRoom>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (room == null)
            {
                room = GetComponentInParent<AddRoom>();
            }

            room.counter++;
            string nombre = gameObject.transform.parent.gameObject.name;
            nombre = nombre.Substring(0, nombre.Length - 7);
            switch (nombre.Length)
            {
                case 1:
                    if (room.counter > 1)
                    {
                        //other.GetComponent<RoomSpawner>().spawned = false;
                        //Crear una variable que sea un caracter para la habitación principal. Esta variable regenerará una habitación en la dirección que indique.
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }
                    break;
                case 2:
                    if (room.counter > 2)
                    {
                        //other.GetComponent<RoomSpawner>().spawned = false;
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }
                    break;
                case 3:
                    if (room.counter > 3)
                    {
                        //other.GetComponent<RoomSpawner>().spawned = false;
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }
                    break;
                case 4:
                    if (room.counter > 4)
                    {
                        //other.GetComponent<RoomSpawner>().spawned = false;
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }
                    break;
            }
            //if (other.name.Equals("SpawnPoint T"))
            //{
            //    Debug.Log("lol");
            //}
        }
    }
}
