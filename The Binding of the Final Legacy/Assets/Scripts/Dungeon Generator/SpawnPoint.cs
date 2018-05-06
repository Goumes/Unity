using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject parent;
    private bool generated = false;
    private GameObject generatedRoom;
    private Room ownRoomScript;
    private Room childRoomScript;
    
    // Use this for initialization
    void Start ()
    {
        parent = transform.parent.transform.parent.gameObject;
        ownRoomScript = transform.parent.GetComponentInChildren<Room>();
        //generateRoom();
        Invoke("generateRoom", Random.Range(0.1f, 0.4f));
	}

    /// <summary>
    /// Method that generates a room and sets it's corresponding doors as true
    /// </summary>
    private void generateRoom()
    {
        if (!generated)
        {
            generatedRoom = Instantiate(Resources.Load("Default Room") as GameObject, transform.position, Quaternion.identity);
            generatedRoom.transform.parent = parent.transform;
            childRoomScript = generatedRoom.transform.GetComponentInChildren<Room>();
            childRoomScript.parentNumber = ownRoomScript.serialNumber;
            childRoomScript.relativePosition = transform.name.Substring(11, 1);

            switch (transform.name)
            {
                case "SpawnPoint Right":
                    generatedRoom.GetComponentInChildren<Room>().leftDoor = true;
                    break;

                case "SpawnPoint Left":
                    generatedRoom.GetComponentInChildren<Room>().rightDoor = true;
                    break;

                case "SpawnPoint Top":
                    generatedRoom.GetComponentInChildren<Room>().bottomDoor = true;
                    break;

                case "SpawnPoint Bottom":
                    generatedRoom.GetComponentInChildren<Room>().topDoor = true;
                    break;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Center"))
        {
            //Esto hace que cuando una rama se encuentre con otra, se fusionen

            //switch (transform.name)
            //{
            //    case "SpawnPoint Right":
            //        collision.transform.parent.GetComponentInChildren<Room>().leftDoor = true;
            //        break;

            //    case "SpawnPoint Left":
            //        collision.transform.parent.GetComponentInChildren<Room>().rightDoor = true;
            //        break;

            //    case "SpawnPoint Top":
            //        collision.transform.parent.GetComponentInChildren<Room>().bottomDoor = true;
            //        break;

            //    case "SpawnPoint Bottom":
            //        collision.transform.parent.GetComponentInChildren<Room>().topDoor = true;
            //        break;
            //}

            generated = true;
            //Destroy(gameObject); //Si algo peta sin sentido es porque he comentado esta linea. Pero no debería de dar problemas
        }
    }
}
