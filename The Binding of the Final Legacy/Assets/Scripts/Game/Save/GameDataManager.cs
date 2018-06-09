using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public string selectedSave;
    public PlayerClass createdPlayer;
    private GameObject player;
    private GameObject dungeon;
    private GameObject itemPool;
    private GameObject minimapGrid;
    private GameObject roomArray;
    private Database itemDatabase;
    private ShopGlobalButton shopGlobalButton;
    public bool hasSavedGame;
    private bool instantiated;
    private bool menu;

    //Singleton
    public static GameDataManager Instance;


    // Use this for initialization
    void Start ()
    {
        //hasSavedGame = true;
        if (LoadGame() != null)
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
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            if (!instantiated)
            {
                instantiated = true;
                player = GameObject.FindGameObjectWithTag("Player");
                dungeon = GameObject.FindGameObjectWithTag("Dungeon");
                itemPool = GameObject.FindGameObjectWithTag("Item Pool");
                minimapGrid = GameObject.FindGameObjectWithTag("Grid");
                roomArray = GameObject.FindGameObjectWithTag("Rooms");
                shopGlobalButton = GameObject.FindGameObjectWithTag("Shop Global Button").GetComponent<ShopGlobalButton>();
                itemDatabase = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();
            }
            else if (menu)
            {
                menu = false;
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("Main Menu"))
        {
            if (!menu)
            {
                selectedSave = null;
                hasSavedGame = false;
                menu = true;
            }
            else if (instantiated)
            {
                instantiated = false;
            }
        }
	}

    public bool SaveGame()
    {
        bool saved = false;

        GameSave save = new GameSave ();
        save.saveGameName = selectedSave;

        saveItems(save);

        saveMinimap(save);

        saveDungeon(save);

        savePlayer(save);

        BinaryFormatter bf = new BinaryFormatter();

        if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/");
        }

        FileStream file = File.Create(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/" + save.saveGameName + ".sav");
        bf.Serialize(file, save);
        file.Close();
        saved = true;
        Debug.Log("Saved Game: " + save.saveGameName);

        return saved;
    }

    public void DeleteSave()
    {
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/" + selectedSave + ".sav"))
        {
            File.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/" + selectedSave + ".sav");
            Debug.Log("Deleted Game: " + selectedSave);
        }
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
        var stats = player.GetComponent<Player>().playerStats;
        playerSave.playerDetails = player.GetComponent<Player>().playerStats;

        save.player = playerSave;
    }

    private void saveItems(GameSave save)
    {
        ItemsSave itemsSave = new ItemsSave();
        itemsSave.database = itemDatabase.itemDatabase;
        itemsSave.shopPool = itemDatabase.shopPool;
        itemsSave.soldItems = shopGlobalButton.soldItems;

        save.items = itemsSave;

    }

    public GameSave LoadGame()
    {
        GameSave loadedGame = null;
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/" + selectedSave + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/" + selectedSave + ".sav", FileMode.Open);
            loadedGame = (GameSave)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loaded Game: " + loadedGame.saveGameName);
        }

        return loadedGame;
    }
}
