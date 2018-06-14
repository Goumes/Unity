using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RealRoomSave
{
    //No tiene getters ni setters por un problema con el binnaryformatter the unity, que no los puede tratar
    public int serial;
    public bool hasChest;
    public bool hasBoss;
    public bool hasShop;
    public List<string> enemies;
    public List<string> misc;
    public List<string> chests;

    public RealRoomSave()
    {
        serial = 0;
        hasChest = false;
        hasBoss = false;
        hasShop = false;
        enemies = new List<string>();
        misc = new List<string>();
        chests = new List<string>();
    }

    public RealRoomSave(int serial, bool hasChest, bool hasBoss, bool hasShop, List<string> enemies, List<string> misc, List<string> chests)
    {
        this.serial = serial;
        this.hasChest = hasChest;
        this.hasShop = hasShop;
        this.enemies = enemies;
        this.misc = misc;
        this.chests = chests;
    }
}
