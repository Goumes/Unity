using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemDatabase itemDatabase;
	// Use this for initialization
	void Start () {
        itemDatabase = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<ItemDatabase>();
        Invoke("loadItem", 0.001f);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void loadItem()
    {
        transform.GetComponent<SpriteRenderer>().sprite = Resources.Load(itemDatabase.database.itemList[0].imageResourcePath, typeof(Sprite)) as Sprite;
    }
}
