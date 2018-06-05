using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSave
{
    public string saveGameName;
    public PlayerSave player;
    //public GameObject itemPool;
    public DungeonSave dungeon;
    public MinimapSave minimapGrid;

    public GameSave()
    {
        player = null;
        //itemPool = null;
        dungeon = null;
        minimapGrid = null;
    }

    public GameSave(PlayerSave player, GameObject itemPool, DungeonSave dungeon, MinimapSave minimapGrid)
    {
        this.player = player;
        //this.itemPool = itemPool;
        this.dungeon = dungeon;
        this.minimapGrid = minimapGrid;
    }

}
