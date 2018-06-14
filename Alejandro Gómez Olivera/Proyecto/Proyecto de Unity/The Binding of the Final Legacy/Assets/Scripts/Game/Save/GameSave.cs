using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSave
{
    //No tiene getters ni setters por un problema con el binnaryformatter the unity, que no los puede tratar
    public string saveGameName;
    public PlayerSave player;
    public ItemsSave items;
    public DungeonSave dungeon;
    public MinimapSave minimapGrid;

    public GameSave()
    {
        player = null;
        items = null;
        dungeon = null;
        minimapGrid = null;
    }

    public GameSave(PlayerSave player, ItemsSave items, DungeonSave dungeon, MinimapSave minimapGrid)
    {
        this.player = player;
        this.items = items;
        this.dungeon = dungeon;
        this.minimapGrid = minimapGrid;
    }

}
