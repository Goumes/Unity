using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DungeonSave
{
    //No tiene getters ni setters por un problema con el binnaryformatter the unity, que no los puede tratar
    public List<RealRoomSave> rooms;

}
