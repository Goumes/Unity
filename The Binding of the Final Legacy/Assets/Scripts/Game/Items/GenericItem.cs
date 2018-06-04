using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GenericItem
{
    public int id;//{ get; set; }
    public string name;// { get; set; }
    public string description;
    public float price; //{ get; set; }
    public float duration; //{ get; set; }
    public float attackModifier; //{ get; set; }
    public float defenseModifier; //{ get; set; }
    public float healthModifier; //{ get; set; }
    public string imageResourcePath; //{ get; set; }

    public GenericItem()
    {
        id = 0;
        name = "Default";
        description = "Nice description";
        price = 999.9f;
        duration = 1.0f;
        attackModifier = 10.0f;
        defenseModifier = 10.0f;
        healthModifier = 10.0f;
        imageResourcePath = "Items/torch";
    }

    public GenericItem(int id, string name, string description, float price, float duration, float attackModifier, float defenseModifier, float healthModifier, string imageResourcePath)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.duration = duration;
        this.attackModifier = attackModifier;
        this.defenseModifier = defenseModifier;
        this.healthModifier = healthModifier;
        this.imageResourcePath = imageResourcePath;
    }
}