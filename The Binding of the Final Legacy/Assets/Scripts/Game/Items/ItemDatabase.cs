using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public ItemList database;
    public List<GenericItem> shopPool;
    private Management management;
    private GameDataManager gameDataManager;
    //private GenericItem item;

	// Use this for initialization
	void Start ()
    {
        int shopCounter = 0;
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();


        if (!gameDataManager.hasSavedGame)
        {
            database = JsonUtility.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));//JsonHelper.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
            shopPool = new List<GenericItem>();
        }
        else
        {
            var save = gameDataManager.LoadGame();
            database = save.items.database;
            shopPool = save.items.shopPool;
        }

        for (int i = 0; i < database.itemList.Count && shopCounter < 8; i++)
        {
            if (management.randomBoolean(0.8f))
            {
                shopPool.Add(database.itemList[i]);
                database.itemList.RemoveAt(i);
                shopCounter++;
                i--;
            }

            if (i == database.itemList.Count - 1)
            {
                i = 0;
            }
        }
        //item = JsonUtility.FromJson<GenericItem>(File.ReadAllText(Application.dataPath + "/StreamingAssets/item.json"));
        //Debug.Log(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Invoke("prueba", 1f);
	}

    private void prueba()
    {
        for (int i = 0; i < database.itemList.Count; i++)
        {
            Debug.Log(database.itemList[i].name);
        }
    }
}
