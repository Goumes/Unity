using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyList
{
    //No lleva getters y setters porque el binnaryformatter de unity no los puede manejar
    public List<EnemyClass> enemies;
}
