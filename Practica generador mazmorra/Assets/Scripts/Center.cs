using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour {

    private AddRoom room;
    private RoomTemplates templates;
    private int rand;
    private bool delete = false;

    // Use this for initialization
    void Start () {
        room = GetComponentInParent<AddRoom>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
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

            if (templates == null)
            {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            }

            room.counter++;
            string nombre = gameObject.transform.parent.gameObject.name;
            Vector3 position = other.gameObject.transform.parent.gameObject.transform.position;
            nombre = nombre.Substring(0, nombre.Length - 7);
            switch (nombre.Length)
            {
                case 1:
                    if (room.counter > 1)
                    {
                        delete = true;
                    }
                    break;
                case 2:
                    if (room.counter > 2)
                    {
                        delete = true;
                    }
                    break;
                case 3:
                    if (room.counter > 3)
                    {
                        delete = true;
                    }
                    break;
                case 4:
                    if (room.counter > 4)
                    {
                        delete = true;
                    }
                    break;
            }

            if (delete)
            {
                char direction = other.gameObject.transform.parent.gameObject.GetComponent<AddRoom>().direction;
                templates.rooms.Remove(other.gameObject.transform.parent.gameObject);
                Destroy(other.gameObject.transform.parent.gameObject);
                room.counter--;
                GameObject newRoom;
                

                switch (direction)
                {
                    case 't':
                        rand = Random.Range(0, templates.topRooms.Length);
                        newRoom = Instantiate(templates.topRooms[rand], position, Quaternion.identity);
                        break;

                    case 'b':
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        newRoom = Instantiate(templates.bottomRooms[rand], position, Quaternion.identity);
                        break;

                    case 'l':
                        rand = Random.Range(0, templates.leftRooms.Length);
                        newRoom = Instantiate(templates.leftRooms[rand], position, Quaternion.identity);
                        break;

                    case 'r':
                        rand = Random.Range(0, templates.rightRooms.Length);
                        newRoom = Instantiate(templates.rightRooms[rand], position, Quaternion.identity);
                        break;
                }

                delete = false;
            }
        }
    }
}
