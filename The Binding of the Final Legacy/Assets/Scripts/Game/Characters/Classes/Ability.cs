using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    //No tiene getters y setters porque el binaryformatter the unity no lo puede manejar y lo tuve que quitar.

    public int id;
    public string name;
    public string type;
    public int dmgMultiplier;
    public float manaCost;

    public Ability()
    {
        id = 0;
        name = "Default name";
        type = "Default type";
        dmgMultiplier = 2;
        manaCost = 30.0f;
    }

    public Ability(int id, string name, string type, int dmgMultiplier, float manaCost)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.dmgMultiplier = dmgMultiplier;
        this.manaCost = manaCost;
    }
}
