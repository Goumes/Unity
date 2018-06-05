using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass
{
    public string name;
    public float health;
    public float defense;
    public float attack;
    public float gold;

    [System.NonSerialized]
    public List<GameObject> inventory;

    public PlayerClass()
    {
        name = "Default Name";
        health = 100.0f;
        defense = 20.0f;
        attack = 40.0f;
        gold = 100.0f;
        inventory = new List<GameObject>();
    }

    public PlayerClass(string name, float health, float defense, float attack, float gold, List<GameObject> inventory)
    {
        this.name = name;
        this.health = health;
        this.defense = defense;
        this.attack = attack;
        this.gold = gold;
        this.inventory = inventory;
    }
}
