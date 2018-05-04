using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject parent;
    private bool generated = false;
    private GameObject generatedRoom;
    
    // Use this for initialization
    void Start ()
    {
       
        parent = transform.parent.transform.parent.gameObject;
        //generateRoom();
        Invoke("generateRoom", Random.Range(0.1f, 0.4f));
	}

    private void generateRoom()
    {
        if (!generated)
        {
            generatedRoom = Instantiate(Resources.Load("Default Room") as GameObject, transform.position, Quaternion.identity);
            generatedRoom.transform.parent = parent.transform;
            generatedRoom.name = "Default Room";

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
            Destroy(gameObject);
        }
    }
}
