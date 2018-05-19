using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapRoom : MonoBehaviour
{
    public bool topDoor;
    public bool bottomDoor;
    public bool leftDoor;
    public bool rightDoor;
    public float doorRate = 0.66f;
    private Tilemap tilemap;
    public bool generate;
    private RoomArray roomArray;
    public int serialNumber;
    private MinimapGridScript gridScript;
    public IDictionary <string, int> childPositions;
    public bool currentRoom;
    public bool created;

    //[System.Serializable]
    //public struct ChildDictionary
    //{
    //    public string position;
    //    public int serial;

    //    public ChildDictionary(string position, int serial)
    //    {
    //        this.position = position;
    //        this.serial = serial;
    //    }
    //}
    //public List<ChildDictionary> childPositions;

    // Use this for initialization
    void Start ()
    {
        generate = true;
        //Se seleccionan puertas aleatoriamente de entre las 4 que hay.
        tilemap = GetComponent<Tilemap>();
        roomArray = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomArray>();
        roomArray.minimapRooms.Add(gameObject);
        gridScript = transform.parent.transform.parent.GetComponent<MinimapGridScript>();
        //gridScript.globalCounter++;
        //serialNumber = gridScript.globalCounter;
        transform.parent.transform.name = "Default Room " + serialNumber;
        //childPositions = new List<ChildDictionary>();
        childPositions = new Dictionary<string, int>();

        if (serialNumber == 0)
        {
            currentRoom = true;
        }

        InvokeRepeating("generateDoors", 0, Random.Range(0.1f, 0.4f)); //Hay que arreglar esto. Al introducir un minimo y un maximo de habitaciones todo se vuelve loco. ARREGLADO.
        Invoke("deleteSpawnPoints", 2f);//Borrar todos los spawnpoints tras 2 segundos.
        //Invoke("generateDoors", 0.1f);

    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        checkDoors();

        if (currentRoom && !created)
        {
            tilemap.SetTile(new Vector3Int(0, -3, 0), Resources.Load("Cuadrado") as Tile);
            created = true;
        }
        else if (!currentRoom && created)
        {
            tilemap.SetTile(new Vector3Int(0, -3, 0), null);
            created = false;
        }
	}

    /// <summary>
    /// Method that randomly sets a few doors as true, while deleting the corresponding tiles.
    /// </summary>
    private void generateDoors()
    {
        float door = 0f;
        int direction = 0;
        Transform parent = transform.parent;
        GameObject child;

        if (generate && roomArray.minimapRooms.Count < roomArray.maxNumber)
        {
            generate = false;
            for (int i = 0; i < 4; i++)
            {
                door = Random.Range(0f, 1f);

                if (door > doorRate)
                {
                    direction = Random.Range(1, 5);

                    switch (direction)
                    {
                        case 1:
                            //topDoor = true;

                            child = parent.Find("SpawnPoint Top").gameObject;
                            child.SetActive(true);

                            //tilemap.SetTile(new Vector3Int(0, 1, 0), null);
                            //tilemap.SetTile(new Vector3Int(1, 1, 0), null);
                            break;

                        case 2:
                            //bottomDoor = true;

                            child = parent.Find("SpawnPoint Bottom").gameObject;
                            child.SetActive(true);

                            //tilemap.SetTile(new Vector3Int(0, -6, 0), null);
                            //tilemap.SetTile(new Vector3Int(1, -6, 0), null);
                            break;

                        case 3:
                            //leftDoor = true;

                            child = parent.Find("SpawnPoint Left").gameObject;
                            child.SetActive(true);

                            //tilemap.SetTile(new Vector3Int(-3, -2, 0), null);
                            //tilemap.SetTile(new Vector3Int(-3, -3, 0), null);
                            break;

                        case 4:
                            //rightDoor = true;

                            child = parent.Find("SpawnPoint Right").gameObject;
                            child.SetActive(true);

                            //tilemap.SetTile(new Vector3Int(4, -2, 0), null);
                            //tilemap.SetTile(new Vector3Int(4, -3, 0), null);
                            break;
                    }
                }
            }
        }

       
    }

    /// <summary>
    /// Method that checks if there's any new door opened and deletes the necessary tiles.
    /// </summary>
    private void checkDoors()
    {
        if (topDoor)
        {
            tilemap.SetTile(new Vector3Int(0, 1, 0), null);
            tilemap.SetTile(new Vector3Int(1, 1, 0), null);

            if (!childPositions.ContainsKey("T"))
            {
                for (int i = 0; i < roomArray.minimapRooms.Count; i++)
                {
                    foreach (KeyValuePair<string, int> pair in roomArray.minimapRooms[i].GetComponentInChildren<MinimapRoom>().childPositions)
                    {
                        if (pair.Value == serialNumber && pair.Key.Equals("B"))
                        {
                            childPositions.Add("T", roomArray.minimapRooms[i].GetComponent<MinimapRoom>().serialNumber);
                        }
                    }
                }
                
            }
        }

        if (leftDoor)
        {
            tilemap.SetTile(new Vector3Int(-3, -2, 0), null);
            tilemap.SetTile(new Vector3Int(-3, -3, 0), null);

            if (!childPositions.ContainsKey("L"))
            {
                for (int i = 0; i < roomArray.minimapRooms.Count; i++)
                {
                    foreach (KeyValuePair<string, int> pair in roomArray.minimapRooms[i].GetComponentInChildren<MinimapRoom>().childPositions)
                    {
                        if (pair.Value == serialNumber && pair.Key.Equals("R"))
                        {
                            childPositions.Add("L", roomArray.minimapRooms[i].GetComponent<MinimapRoom>().serialNumber);
                        }
                    }
                }

            }
        }

        if (rightDoor)
        {
            tilemap.SetTile(new Vector3Int(4, -2, 0), null);
            tilemap.SetTile(new Vector3Int(4, -3, 0), null);

            if (!childPositions.ContainsKey("R"))
            {
                for (int i = 0; i < roomArray.minimapRooms.Count; i++)
                {
                    foreach (KeyValuePair<string, int> pair in roomArray.minimapRooms[i].GetComponentInChildren<MinimapRoom>().childPositions)
                    {
                        if (pair.Value == serialNumber && pair.Key.Equals("L"))
                        {
                            childPositions.Add("R", roomArray.minimapRooms[i].GetComponent<MinimapRoom>().serialNumber);
                        }
                    }
                }

            }
        }

        if (bottomDoor)
        {
            tilemap.SetTile(new Vector3Int(0, -6, 0), null);
            tilemap.SetTile(new Vector3Int(1, -6, 0), null);

            if (!childPositions.ContainsKey("B"))
            {
                for (int i = 0; i < roomArray.minimapRooms.Count; i++)
                {
                    foreach (KeyValuePair<string, int> pair in roomArray.minimapRooms[i].GetComponentInChildren<MinimapRoom>().childPositions)
                    {
                        if (pair.Value == serialNumber && pair.Key.Equals("T"))
                        {
                            childPositions.Add("B", roomArray.minimapRooms[i].GetComponent<MinimapRoom>().serialNumber);
                        }
                    }
                }

            }
        }
    }

    /// <summary>
    /// Method that deletes all the spawnpoints of the gameobject
    /// </summary>
    private void deleteSpawnPoints()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).CompareTag("SpawnPoint") || transform.parent.GetChild(i).CompareTag("Center"))
            {
                Destroy(transform.parent.GetChild(i).gameObject);
            }
        }
    }
}
