using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericItem
{
    public int id;//{ get; set; }
    public string name;// { get; set; }
    public string type;
    public string description;
    public float price; //{ get; set; }
    public float sellingPrice;
    public int duration; //In turns //{ get; set; } 
    public float attackModifier; //{ get; set; }
    public float defenseModifier; //{ get; set; }
    public float healthModifier; //{ get; set; }
    public float manaModifier;
    public string imageResourcePath; //{ get; set; }

    public GenericItem()
    {
        id = 0;
        name = "Default";
        type = "Default";
        description = "Nice description";
        price = 999.9f;
        sellingPrice = 500.0f;
        duration = 1;
        attackModifier = 10.0f;
        defenseModifier = 10.0f;
        healthModifier = 10.0f;
        manaModifier = 10.0f;
        imageResourcePath = "Items/torch";
    }

    public GenericItem(int id, string name, string type, string description, float price, float sellingPrice, int duration, float attackModifier, float defenseModifier, float healthModifier, float manaModifier, string imageResourcePath)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.description = description;
        this.price = price;
        this.sellingPrice = sellingPrice;
        this.duration = duration;
        this.attackModifier = attackModifier;
        this.defenseModifier = defenseModifier;
        this.healthModifier = healthModifier;
        this.manaModifier = manaModifier;
        this.imageResourcePath = imageResourcePath;
    }

    public override bool Equals(object obj)
    {
        var item = obj as GenericItem;

        if (item == null)
        {
            return false;
        }

        return id.Equals(item.id);
    }
}