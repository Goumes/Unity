using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericItem
{
    //No lleva getters y setters porque el binnaryformatter de unity no los puede manejar
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

    public GenericItem(GenericItem item)
    {
        id = item.id;
        name = item.name;
        type = item.type;
        description = item.description;
        price = item.price;
        sellingPrice = item.sellingPrice;
        duration = item.duration;
        attackModifier = item.attackModifier;
        defenseModifier = item.defenseModifier;
        healthModifier = item.healthModifier;
        manaModifier = item.manaModifier;
        imageResourcePath = item.imageResourcePath;
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

    public override int GetHashCode()
    {
        var hashCode = -669923385;
        hashCode = hashCode * -1521134295 + id.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
        hashCode = hashCode * -1521134295 + price.GetHashCode();
        hashCode = hashCode * -1521134295 + sellingPrice.GetHashCode();
        hashCode = hashCode * -1521134295 + duration.GetHashCode();
        hashCode = hashCode * -1521134295 + attackModifier.GetHashCode();
        hashCode = hashCode * -1521134295 + defenseModifier.GetHashCode();
        hashCode = hashCode * -1521134295 + healthModifier.GetHashCode();
        hashCode = hashCode * -1521134295 + manaModifier.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imageResourcePath);
        return hashCode;
    }
}