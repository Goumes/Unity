using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyClass
{
    //No tiene getters y setters porque el binaryformatter the unity no lo puede manejar y lo tuve que quitar.
    public int id;
    public string name;
    public string type;
    public float totalHealth;
    public float currentHealth;
    public float totalMana;
    public float currentMana;
    public float defense;
    public float attack;
    public float goldDrop;
    public List<int> abilities;
    public string spritePath;

    public EnemyClass()
    {
        id = 0;
        name = "Default Name";
        type = "minion";
        totalHealth = 100.0f;
        currentHealth = totalHealth;
        totalMana = 100.0f;
        currentMana = totalMana;
        defense = 0.0f;
        attack = 10.0f;
        goldDrop = 100.0f;
        abilities = new List<int>();
        spritePath = "HereGoesThePath";
    }

    public EnemyClass(int id, string name, string type, float totalHealth, float totalMana, float defense, float attack, float goldDrop, List<int> abilities, string spritePath)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.totalHealth = totalHealth;
        currentHealth = totalHealth;
        this.totalMana = totalMana;
        currentMana = totalMana;
        this.defense = defense;
        this.attack = attack;
        this.goldDrop = goldDrop;
        this.abilities = abilities;
        this.spritePath = spritePath;
    }

    public EnemyClass(EnemyClass enemy)
    {
        id = enemy.id;
        name = enemy.name;
        type = enemy.type;
        totalHealth = enemy.totalHealth;
        currentHealth = enemy.totalHealth;
        totalMana = enemy.totalMana;
        currentMana = enemy.totalMana;
        defense = enemy.defense;
        attack = enemy.attack;
        goldDrop = enemy.goldDrop;
        abilities = enemy.abilities;
        spritePath = enemy.spritePath;
    }
}
