using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSave
{
    public float x;
    public float y;
    public PlayerClass playerDetails;

    public PlayerSave()
    {
        x = 0f;
        y = 0f;
        playerDetails = null;
    }

    public PlayerSave (float x, float y, PlayerClass playerDetails)
    {
        this.x = x;
        this.y = y;
        this.playerDetails = playerDetails;
    }
}
