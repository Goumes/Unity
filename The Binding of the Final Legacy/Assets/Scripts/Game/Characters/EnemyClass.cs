using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass
{
    public string name { get; set; }
    public float health { get; set; }
    public float defense { get; set; }
    public float attack { get; set; }
    public float goldDrop { get; set; }
    public GenericItem itemDrop { get; set; }

    public EnemyClass()
    {
        name = "Default Name";
        health = 30.0f;
        defense = 0.0f;
        attack = 10.0f;
        goldDrop = 100.0f;
        itemDrop = new GenericItem ();
    }

    public EnemyClass(string name, float health, float defense, float attack, float goldDrop, GenericItem itemDrop)
    {
        this.name = name;
        this.health = health;
        this.defense = defense;
        this.attack = attack;
        this.goldDrop = goldDrop;
        this.itemDrop = itemDrop;
    }
}
