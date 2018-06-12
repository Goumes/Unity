using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : MonoBehaviour
{
    public ItemList itemDatabase;
    public EnemyList enemyDatabase;
    public AbilityList abilityDatabase;
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
        enemyDatabase = JsonUtility.FromJson<EnemyList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/enemies.json"));
        abilityDatabase = JsonUtility.FromJson<AbilityList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/abilities.json"));


        if (!gameDataManager.hasSavedGame)
        {
            itemDatabase = JsonUtility.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));//JsonHelper.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
            shopPool = new List<GenericItem>();

            for (int i = 0; i < itemDatabase.itemList.Count && shopCounter < 8; i++)
            {
                if (management.randomBoolean(0.8f))
                {
                    shopPool.Add(itemDatabase.itemList[i]);
                    itemDatabase.itemList.RemoveAt(i);
                    shopCounter++;
                    i--;
                }

                if (i == itemDatabase.itemList.Count - 1)
                {
                    i = 0;
                }
            }
        }
        else
        {
            var save = gameDataManager.LoadGame();
            itemDatabase = save.items.database;
            shopPool = save.items.shopPool;
        }
        //item = JsonUtility.FromJson<GenericItem>(File.ReadAllText(Application.dataPath + "/StreamingAssets/item.json"));
        //Debug.Log(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Invoke("prueba", 1f);
	}
}
