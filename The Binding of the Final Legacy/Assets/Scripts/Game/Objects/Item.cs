using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Database itemDatabase;
    private List<GenericItem> shopPool;
    public int itemNumber;
    public GenericItem currentItem;
	// Use this for initialization
	void Start () {
        itemDatabase = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();
        itemNumber = Convert.ToInt32(transform.name.Substring(5));
        Invoke("loadItem", 0.001f);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(itemNumber + " + " + currentItem.name);
	}

    private void loadItem()
    {
        shopPool = itemDatabase.shopPool;

        for (int i = 0; i < shopPool.Count; i++)
        {
            if (i == itemNumber - 1)
            {
                currentItem = shopPool[i];
            }
        }


        transform.GetComponent<SpriteRenderer>().sprite = Resources.Load(currentItem.imageResourcePath, typeof(Sprite)) as Sprite;
            
    }
}
