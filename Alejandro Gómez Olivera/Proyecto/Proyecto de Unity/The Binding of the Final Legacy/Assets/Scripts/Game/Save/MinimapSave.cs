using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MinimapSave
{
    //No tiene getters ni setters por un problema con el binnaryformatter the unity, que no los puede tratar
    public List<MinimapRoomSave> rooms;
}
