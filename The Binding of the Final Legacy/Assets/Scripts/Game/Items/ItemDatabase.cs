using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public ItemList database;
    //private GenericItem item;

	// Use this for initialization
	void Start ()
    {
        database = JsonUtility.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));//JsonHelper.FromJson<ItemList>(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
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
