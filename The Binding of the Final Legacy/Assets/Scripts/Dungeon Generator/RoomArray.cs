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
    public bool created;
    private GameObject fader;
    private Color tmp;
    private GameObject loadingScreen;
    private GameObject player;
    private GameObject minimap;
    private GameObject dungeon;
    private Management management;
    private GameObject grid;
    private int shopNumber;
    private GameDataManager gameDataManager;
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
        dungeon = GameObject.FindGameObjectWithTag("Dungeon");
        minimap.SetActive(false);
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        grid = GameObject.FindGameObjectWithTag("Grid");
        shopNumber = -1;
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
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

        Invoke("checkAndGenerateEverything", 0.1f);
       
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

    private void checkAndGenerateEverything()
    {
        GameSave save = null;
        if (!created && spawnedBoss)
        {
            created = true;

            if (!gameDataManager.hasSavedGame)
            {
                createShop();
            }
            else
            {
                save = gameDataManager.LoadGame("Prueba1");//Cambiar esto por variables en la clase de game data

                for (int i = 0; i < save.dungeon.rooms.Count; i++)
                {
                    if (save.dungeon.rooms[i].hasShop)
                    {
                        shopNumber = save.dungeon.rooms[i].serial - 1;
                    }
                }
            }
            
            createDungeon();
           
            //adjustCamera(); //TO DO

            loadingScreen.SetActive(false);

            if (gameDataManager.hasSavedGame)
            {
                player.transform.position = new Vector3(save.player.x, save.player.y, 0f);
            }
            else
            {
                player.transform.position = new Vector3(1.87f, -0.32f, 0f);
            }
            
            minimap.SetActive(true);
        }
    }

    private void adjustCamera()
    {
        float smallestX = 9999f;
        float smallestY = 9999f;
        float biggestX = 0f;
        float biggestY = 0f;

        for (int i = 0; i < grid.transform.childCount; i++)
        {
            var x = grid.transform.GetChild(i).transform.localPosition.x;
            var y = grid.transform.GetChild(i).transform.localPosition.y;

            Debug.Log(grid.transform.GetChild(i).transform.name + ": X = " + x + ", Y = " + y);

            if (x > biggestX)
            {
                biggestX = x;
            }

            else if (x < smallestX)
            {
                smallestX = x;
            }

            if (y > biggestY)
            {
                biggestY = y;
            }

            else if (y < smallestX)
            {
                smallestY = y;
            }
        }

        Debug.Log("Biggest X: " + biggestX + ", Smallest X: " + smallestX + ", Biggest Y: " + biggestY + ", Smallest Y: " + smallestY);
    }

    private void createShop()
    {
        bool created = false;

        for (int i = 1; i < minimapRooms.Count - 1 && !created; i++) //En la habitación del boss no puede haber tienda, ni en la inicial
        {
            if (management.randomBoolean(0.9f))
            {
                shopNumber = i;
                created = true;
            }
        }
    }

    private void createDungeon()
    {
        Debug.Log("Tienda: "+ shopNumber);
        for (int i = 0; i < minimapRooms.Count; i++)
        {
            var script = minimapRooms[i].GetComponent<MinimapRoom>();
            GameObject room = null;

            
            if (!script.topDoor && script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/B/Shop Room B"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/B/Default Room B"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BL/Shop Room BL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                { 
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BL/Default Room BL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BLR/Shop Room BLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }

                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BLR/Default Room BLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BR/Shop Room BR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/BR/Default Room BR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && !script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/L/Shop Room L"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/L/Default Room L"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && !script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/LR/Shop Room LR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/LR/Default Room LR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (!script.topDoor && !script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/R/Shop Room R"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/R/Default Room R"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && !script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/T/Shop Room T"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/T/Default Room T"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && script.bottomDoor && !script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TB/Shop Room TB"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TB/Default Room TB"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBL/Shop Room TBL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBL/Default Room TBL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBLR/Shop Room TBLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBLR/Default Room TBLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBR/Shop Room TBR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TBR/Default Room TBR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && !script.bottomDoor && script.leftDoor && !script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TL/Shop Room TL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TL/Default Room TL"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && !script.bottomDoor && script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TLR/Shop Room TLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TLR/Default Room TLR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            else if (script.topDoor && !script.bottomDoor && !script.leftDoor && script.rightDoor)
            {
                if (shopNumber == i)
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TR/Shop Room TR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    room.GetComponent<RoomScript>().hasShop = true;
                    realRooms.Add(room);
                }
                else
                {
                    room = (GameObject)Instantiate(Resources.Load("Rooms/TR/Default Room TR"));
                    room.GetComponent<RoomScript>().serialNumber = minimapRooms[i].GetComponent<MinimapRoom>().serialNumber;
                    realRooms.Add(room);
                }
            }

            StartCoroutine(SetEnabledRooms(room, i));


            if (i == minimapRooms.Count - 1)
            {
                realRooms[i].GetComponent<RoomScript>().hasBoss = true;
            }

            room.transform.parent = dungeon.transform;
        }
    }

    IEnumerator SetEnabledRooms(GameObject room, int i)
    {

        yield return new WaitForSeconds(0.01f);
        room.SetActive(false);

        if (minimapRooms[i].GetComponent<MinimapRoom>().currentRoom)
        {
            room.SetActive(true);
        }
    }
}
