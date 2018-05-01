using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;

    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private bool touchingTop = false;
    private bool touchingBot = false;
    private bool touchingLeft = false;
    private bool touchingRight = false;


    public float waitTime = 4f;


	// Use this for initialization
	void Start () {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        Invoke("Spawn", /*Random.Range(0.1f, 0.3f)*/0.1f); //Este random lo he puesto para que no se superpongan las habitaciones en casos especiales
	}

    // Update is called once per frame
    private void Update()
    {
    }
    void Spawn ()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1:
                    // Need to spawn a room with a BOTTOM door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation); //Lo de la rotación es para que spawnee con la rotación por defecto. Si no quiero ninguna rotación, tengo que poner Quaternion.identity
                    break;
                case 2:
                    // Need to spawn a room with a TOP door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);

                    break;
                case 3:
                    // Need to spawn a room with a LEFT door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
                case 4:
                    // Need to spawn a room with a RIGHT door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
            }

            spawned = true;
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }  

            spawned = true;
        }

        else if (other.CompareTag("Center"))
        {
            //Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
