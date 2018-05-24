using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class RoomArray : MonoBehaviour
{
    public List<GameObject> minimapRooms;
    public int minNumber = 5;
    public int maxNumber = 10;
    private GameObject lastRoom;
    public float waitTime;
    private bool spawnedBoss;
    private Tilemap tilemap;
    public List<GameObject> realRooms;
    public int roomCounter;
    bool created;
    private GameObject fader;
    private Color tmp;
    GameObject loadingScreen;
    GameObject player;
    GameObject minimap;
    // Use this for initialization
    void Start () {
        roomCounter = 0;
        created = false;
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<RawImage>().color;
        tmp.a = 1f;
        fader.GetComponent<RawImage>().color = tmp;
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen");
        player = GameObject.FindGameObjectWithTag("Player");
        minimap = GameObject.FindGameObjectWithTag("Minimap");
        minimap.SetActive(false);
        //player.SetActive(false);
        InvokeRepeating("checkEnd", 0f, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Invoke("checkArrayLength", 1f);

        //if (waitTime <= 0)
        //{
        //    for (int i = 0; i < minimapRooms.Count && !spawnedBoss; i++)
        //    {
        //        if (i == minimapRooms.Count - 1)
        //        {
        //            tilemap = minimapRooms[i].GetComponent<Tilemap>();
        //            //Cambiar esto por una habitación de boss real
        //            tilemap.SetTile(new Vector3Int(0, -3, 0), Resources.Load("Cuadrado") as Tile);
        //            tilemap.SetTile(new Vector3Int(1, -3, 0), Resources.Load("Cuadrado") as Tile);
        //            tilemap.SetTile(new Vector3Int(0, -2, 0), Resources.Load("Cuadrado") as Tile);
        //            tilemap.SetTile(new Vector3Int(1, -2, 0), Resources.Load("Cuadrado") as Tile);
        //            spawnedBoss = true;

        //            //Aqui se empieza a crear el array con las mazmorras de verdad
        //            createDungeon();
        //        }
        //    }
        //}
        //else
        //{
        //    waitTime -= Time.deltaTime;
        //}


    }

    private void checkEnd()
    {
        if (!spawnedBoss)
        {
            StartCoroutine(waitRoutine());
        }

        if (!created && spawnedBoss)
        {
            createDungeon();
            created = true;
            loadingScreen.SetActive(false);
            player.transform.position = new Vector3(1.87f, -0.32f, 0f);
            minimap.SetActive(true);
        }
    }

    IEnumerator waitRoutine()
    {
        var initLenght = 0;
        initLenght = minimapRooms.Count;
        yield return new WaitForSeconds(1f);
        if (initLenght == minimapRooms.Count && initLenght >= minNumber)
        {
            tilemap = minimapRooms[minimapRooms.Count - 1].GetComponent<Tilemap>();
            tilemap.SetTile(new Vector3Int(0, -3, 0), Resources.Load("Cuadrado") as Tile);
            tilemap.SetTile(new Vector3Int(1, -3, 0), Resources.Load("Cuadrado") as Tile);
            tilemap.SetTile(new Vector3Int(0, -2, 0), Resources.Load("Cuadrado") as Tile);
            tilemap.SetTile(new Vector3Int(1, -2, 0), Resources.Load("Cuadrado") as Tile);
            spawnedBoss = true;
        }
    }

    /// <summary>
    /// Method that checks if the number of rooms is greater than the minimum. If it's smaller, it forces the last room to generate more.
    /// </summary>
    private void checkArrayLength()
    {
        if (minimapRooms.Count < minNumber)
        {
            //Debug.Log("minimo");
            lastRoom = minimapRooms[minimapRooms.Count - 1];
            lastRoom.GetComponentInChildren<MinimapRoom>().generate = true;
        }
    }

    private void createDungeon()
    {
        for (int i = 0; i < minimapRooms.Count; i++)
        {
            var script = minimapRooms[i].GetComponent<MinimapRoom>();
            GameObject room = null;

            if (!script.topDoor && script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/B/Default Room B"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/BL/Default Room BL"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/BLR/Default Room BLR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/BR/Default Room BR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && !script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/L/Default Room L"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && !script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/LR/Default Room LR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (!script.topDoor && !script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/R/Default Room R"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && !script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/T/Default Room T"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TB/Default Room TB"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TBL/Default Room TBL"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TBLR/Default Room TBLR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TBR/Default Room TBR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && !script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TL/Default Room TL"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && !script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TLR/Default Room TLR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            else if (script.topDoor && !script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                room = (GameObject)Instantiate(Resources.Load("Rooms/TR/Default Room TR"));
                room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                realRooms.Add(room);
            }

            if (i == 0)
            {
                room.SetActive(true);
            }
        }
        //for (int i = 0; i < minimapRooms.Count; i++) {
        //    foreach (KeyValuePair<string, int> pair in minimapRooms[i].GetComponentInChildren<MinimapRoom>().childPositions)
        //    {
        //        Debug.Log(minimapRooms[i].transform.parent.transform.name);
        //        Debug.Log(pair.Key + " + " + pair.Value);
        //    }
        //}


        //var x = (GameObject)Resources.Load("Rooms/TB/Default Room TB");
        //for (int i = 0; i < x.GetComponentsInChildren<Teleporter>().Length; i++)
        //{
        //    x.GetComponentsInChildren<Teleporter>()[i].roomNumber = roomCounter;
        //}
        //realRooms.Add(x);
        //Instantiate(x);
        //roomCounter++;


        //x = (GameObject)Resources.Load("Rooms/TB/Default Room TB");
        //for (int i = 0; i < x.GetComponentsInChildren<Teleporter>().Length; i++)
        //{
        //    x.GetComponentsInChildren<Teleporter>()[i].roomNumber = roomCounter;
        //}
        //realRooms.Add(x);
        //Instantiate(x);
        //roomCounter++;


        //realRooms.Add((GameObject)Resources.Load("Rooms/BL/Default Room BL"));
        //realRooms.Add((GameObject)Resources.Load("Rooms/TLR/Default Room TLR"));
        //realRooms.Add((GameObject)Resources.Load("Rooms/TR/Default Room TR"));
    }
}
