using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private GameObject player;
    private GameObject dungeon;
    private GameObject itemPool;
    private GameObject minimapGrid;
    private GameObject roomArray;
    public bool hasSavedGame;

    //Singleton
    public static GameDataManager Instance;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dungeon = GameObject.FindGameObjectWithTag("Dungeon");
        itemPool = GameObject.FindGameObjectWithTag("Item Pool");
        minimapGrid = GameObject.FindGameObjectWithTag("Grid");
        roomArray = GameObject.FindGameObjectWithTag("Rooms");
        //hasSavedGame = true;

        if (LoadGame("Prueba1") != null)
        {
            hasSavedGame = true;
        }

        //player.GetComponent<Player>().playerStats = save.player;
        //dungeon = save.dungeon;
        //itemPool.GetComponent<ItemDatabase>().database = save.itemPool.database;
        //minimapGrid = save.minimapGrid;
        //roomArray = save.roomArray;
	}

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void SaveGame()
    {
        GameSave save = new GameSave ();
        save.saveGameName = "Prueba1";
        //save.player = player;
        //save.itemPool = itemPool;

        saveMinimap(save);

        saveDungeon(save);

        savePlayer(save);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("C:/Savegames/" + save.saveGameName + ".sav");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Saved Game: " + save.saveGameName);
    }

    private void saveMinimap(GameSave save)
    {
        List<MinimapRoomSave> minimapRooms = new List<MinimapRoomSave>();

        for (int i = 0; i < minimapGrid.transform.childCount; i++)
        {
            var roomParent = minimapGrid.transform.GetChild(i);
            var roomScript = roomParent.transform.GetChild(0).GetComponentInChildren<MinimapRoom>();
            var topRoom = -1;
            var bottomRoom = -1;
            var leftRoom = -1;
            var rightRoom = -1;

            roomScript.childPositions.TryGetValue("T", out topRoom);
            roomScript.childPositions.TryGetValue("B", out bottomRoom);
            roomScript.childPositions.TryGetValue("L", out leftRoom);
            roomScript.childPositions.TryGetValue("R", out rightRoom);

            minimapRooms.Add(new MinimapRoomSave(roomScript.serialNumber, roomScript.topDoor, roomScript.leftDoor, roomScript.bottomDoor, roomScript.rightDoor, roomScript.currentRoom, topRoom, bottomRoom, leftRoom, rightRoom, roomParent.transform.localPosition.x, roomParent.transform.localPosition.y));
        }

        save.minimapGrid = new MinimapSave
        {
            rooms = minimapRooms
        };
    }

    private void saveDungeon(GameSave save)
    {
        List<RealRoomSave> realRooms = new List<RealRoomSave>();
        List<string> enemies = null;
        List<string> misc = null;
        List<string> chests = null;

        for (int i = 0; i < dungeon.transform.childCount; i++)
        {
            enemies = new List<string>();
            misc = new List<string>();
            chests = new List<string>();

            var roomScript = dungeon.transform.GetChild(i).GetComponent<RoomScript>();

            for (int j = 0; j < dungeon.transform.GetChild(i).childCount; j++)
            {
                if (dungeon.transform.GetChild(i).GetChild(j).transform.CompareTag("In-Game Enemy"))
                {
                    enemies.Add(dungeon.transform.GetChild(i).GetChild(j).transform.name);
                }

                else if (dungeon.transform.GetChild(i).GetChild(j).transform.CompareTag("Vase"))
                {
                    misc.Add(dungeon.transform.GetChild(i).GetChild(j).transform.name);
                }

                else if (dungeon.transform.GetChild(i).GetChild(j).transform.CompareTag("Chest"))
                {
                    chests.Add(dungeon.transform.GetChild(i).GetChild(j).transform.name);
                }
            }


            realRooms.Add(new RealRoomSave(roomScript.serialNumber, roomScript.hasChest, roomScript.hasBoss, roomScript.hasShop, enemies, misc, chests));
        }


        save.dungeon = new DungeonSave
        {
            rooms = realRooms
        };
    }

    private void savePlayer(GameSave save)
    {
        PlayerSave playerSave = new PlayerSave();
        playerSave.x = player.transform.position.x;
        playerSave.y = player.transform.position.y;
        playerSave.playerDetails = player.GetComponent<Player>().playerStats;

        save.player = playerSave;
    }

    public GameSave LoadGame(string gameToLoad)
    {
        GameSave loadedGame = null;
        if (File.Exists("C:/Savegames/" + gameToLoad + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("C:/Savegames/" + gameToLoad + ".sav", FileMode.Open);
            loadedGame = (GameSave)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loaded Game: " + loadedGame.saveGameName);
        }

        return loadedGame;
    }
}
