using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapSpawnPoint : MonoBehaviour
{
    private GameObject parent;
    private bool generated = false;
    private GameObject generatedRoom;
    private MinimapRoom ownRoomScript;
    private MinimapRoom childRoomScript;
    private MinimapGridScript gridScript;
    private Tilemap roomTileMap;
    
    // Use this for initialization
    void Start ()
    {
        parent = transform.parent.transform.parent.gameObject;
        ownRoomScript = transform.parent.GetComponentInChildren<MinimapRoom>();
        gridScript = GetComponentInParent<MinimapGridScript>();
        roomTileMap = ownRoomScript.transform.parent.GetComponent<Tilemap>();
        //generateRoom();
        Invoke("generateRoom", Random.Range(0.1f, 0.8f));
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
            childRoomScript = generatedRoom.transform.GetComponentInChildren<MinimapRoom>();
            gridScript.globalCounter++;
            childRoomScript.serialNumber = gridScript.globalCounter;
            //ownRoomScript.childPositions.Add(new MinimapRoom.ChildDictionary(transform.name.Substring(11, 1), childRoomScript.serialNumber));
            ownRoomScript.childPositions.Add(transform.name.Substring(11, 1), childRoomScript.serialNumber);

            switch (transform.name)
            {
                case "SpawnPoint Right":
                    generatedRoom.GetComponentInChildren<MinimapRoom>().leftDoor = true;
                    ownRoomScript.rightDoor = true;
                    break;

                case "SpawnPoint Left":
                    generatedRoom.GetComponentInChildren<MinimapRoom>().rightDoor = true;
                    ownRoomScript.leftDoor = true;
                    break;

                case "SpawnPoint Top":
                    generatedRoom.GetComponentInChildren<MinimapRoom>().bottomDoor = true;
                    ownRoomScript.topDoor = true;
                    break;

                case "SpawnPoint Bottom":
                    generatedRoom.GetComponentInChildren<MinimapRoom>().topDoor = true;
                    ownRoomScript.bottomDoor = true;
                    break;
            }

            generated = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Center") && !generated)
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

            //switch (transform.name)
            //{
            //    case "SpawnPoint Right":
            //        ownRoomScript.rightDoor = false;
            //        roomTileMap.SetTile(new Vector3Int(4, -2, 0), Resources.Load("Cuadrado") as Tile);
            //        roomTileMap.SetTile(new Vector3Int(4, -3, 0), Resources.Load("Cuadrado") as Tile);
            //        break;

            //    case "SpawnPoint Left":
            //        ownRoomScript.leftDoor = false;
            //        roomTileMap.SetTile(new Vector3Int(-3, -2, 0), Resources.Load("Cuadrado") as Tile);
            //        roomTileMap.SetTile(new Vector3Int(-3, -3, 0), Resources.Load("Cuadrado") as Tile);
            //        break;

            //    case "SpawnPoint Top":
            //        ownRoomScript.topDoor = false;
            //        roomTileMap.SetTile(new Vector3Int(0, 1, 0), Resources.Load("Cuadrado") as Tile);
            //        roomTileMap.SetTile(new Vector3Int(1, 1, 0), Resources.Load("Cuadrado") as Tile);
            //        break;

            //    case "SpawnPoint Bottom":
            //        ownRoomScript.bottomDoor = false;
            //        roomTileMap.SetTile(new Vector3Int(0, -6, 0), Resources.Load("Cuadrado") as Tile);
            //        roomTileMap.SetTile(new Vector3Int(1, -6, 0), Resources.Load("Cuadrado") as Tile);
            //        break;
            //}

            generated = true;

           


            //Destroy(gameObject); //Si algo peta sin sentido es porque he comentado esta linea. Pero no debería de dar problemas
        }
    }
}
