using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass
{
    public string name;
    public float totalHealth;
    public float currentHealth;
    public float totalMana;
    public float currentMana;
    public float defense;
    public float attack;
    public float gold;
    public List<Ability> abilities;
    public List<GenericItem> inventory;

    public PlayerClass()
    {
        name = "Default Name";
        totalHealth = 250.0f;
        currentHealth = totalHealth;
        totalMana = 100.0f;
        currentMana = totalMana;
        defense = 3.0f;
        attack = 5.0f;
        gold = 99999.0f;
        abilities = new List<Ability>();
        inventory = new List<GenericItem>();
    }

    public PlayerClass(string name, float totalHealth, float totalMana, float defense, float attack, float gold, List<Ability> abilities, List<GenericItem> inventory)
    {
        this.name = name;
        this.totalHealth = totalHealth;
        currentHealth = totalHealth;
        this.totalMana = totalMana;
        currentMana = totalMana;
        this.defense = defense;
        this.attack = attack;
        this.gold = gold;
        this.abilities = abilities;
        this.inventory = inventory;
    }
}
