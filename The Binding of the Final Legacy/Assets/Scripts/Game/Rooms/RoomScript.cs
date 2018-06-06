using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public int serialNumber;
    private List<GameObject> enemies;
    private Management management;
    private List<GameObject> misc;
    private List<GameObject> chests;
    public bool hasChest;
    public bool hasShop;
    public bool hasBoss;
    GameDataManager gameDataManager;
	// Use this for initialization
	void Start ()
    {
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        enemies = new List<GameObject>();
        misc = new List<GameObject>();
        chests = new List<GameObject>();

        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("In-Game Enemy"))
            {
                enemies.Add(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Vase"))
            {
                misc.Add(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Chest"))
            {
                chests.Add(transform.GetChild(i).gameObject);
            }
        }

        if (!gameDataManager.hasSavedGame)
        {
            generateEnemies(true);
            generateChests(true);
            generateMisc(true);
        }
        else
        {
            generateEnemies(false);
            generateChests(false);
            generateMisc(false);
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void generateEnemies (bool created)
    {
       
        for (int i = 0; i < enemies.Count; i++)
        {
            if (created)
            {
                if (management.randomBoolean(0.5f) || hasBoss)
                {
                    Destroy(enemies[i].gameObject);
                }
            }
            
            else
            {
                bool found = false;
                var save = gameDataManager.LoadGame();

                for (int j = 0; j < save.dungeon.rooms[serialNumber - 1].enemies.Count; j++)
                {
                    if (enemies[i].transform.name.Equals(save.dungeon.rooms[serialNumber - 1].enemies[j]))
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    Destroy(enemies[i].gameObject);
                }
            }
            
        }
        
    }

    private void generateChests(bool created)
    {
        for (int i = 0; i < chests.Count; i++)
        {
            if (created)
            {
                if (management.randomBoolean(0.7f) || hasBoss)
                {
                    Destroy(chests[i].gameObject);
                }
            }

            else
            {
                bool found = false;
                var save = gameDataManager.LoadGame();

                for (int j = 0; j < save.dungeon.rooms[serialNumber - 1].chests.Count; j++)
                {
                    if (chests[i].transform.name.Equals(save.dungeon.rooms[serialNumber - 1].chests[j]))
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    Destroy(chests[i].gameObject);
                }
            }
        }
    }

    private void generateMisc(bool created)
    {
        for (int i = 0; i < misc.Count; i++)
        {
            if (created)
            {
                if (management.randomBoolean(0.5f) || hasBoss)
                {
                    Destroy(misc[i].gameObject);
                }
            }

            else
            {
                bool found = false;
                var save = gameDataManager.LoadGame();

                for (int j = 0; j < save.dungeon.rooms[serialNumber - 1].misc.Count; j++)
                {
                    if (misc[i].transform.name.Equals(save.dungeon.rooms[serialNumber - 1].misc[j]))
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    Destroy(misc[i].gameObject);
                }
            }
        }
    }
}
