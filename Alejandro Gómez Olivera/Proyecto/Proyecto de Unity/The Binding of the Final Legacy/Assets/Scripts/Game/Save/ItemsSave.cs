using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsSave
{
    //No tiene getters ni setters por un problema con el binnaryformatter the unity, que no los puede tratar
    public ItemList database;
    public List<GenericItem> shopPool;
    public List<string> soldItems;

    public ItemsSave()
    {
        database = new ItemList();
        shopPool = new List<GenericItem>();
        soldItems = new List<string>();
    }

    public ItemsSave(ItemList database, List<GenericItem> shopPool, List<string> soldItems)
    {
        this.database = database;
        this.shopPool = shopPool;
        this.soldItems = soldItems;
    }
}
