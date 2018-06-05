using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MinimapRoomSave
{
    public int serialNumber;
    public bool topDoor;
    public bool leftDoor;
    public bool bottomDoor;
    public bool rightDoor;
    public bool currentRoom;
    public int topRoomSerial;
    public int bottomRoomSerial;
    public int leftRoomSerial;
    public int rightRoomSerial;
    public float x;
    public float y;

    public MinimapRoomSave()
    {
        serialNumber = 0;
        topDoor = false;
        leftDoor = false;
        bottomDoor = false;
        rightDoor = false;
        currentRoom = false;
        topRoomSerial = 0;
        bottomRoomSerial = 0;
        leftRoomSerial = 0;
        rightRoomSerial = 0;
        x = 0f;
        y = 0f;
    }

    public MinimapRoomSave(int serialNumber, bool topDoor, bool leftDoor, bool bottomDoor, bool rightDoor, bool currentRoom, int topRoomSerial, int bottomRoomSerial, int leftRoomSerial, int rightRoomSerial, float x, float y)
    {
        this.serialNumber = serialNumber;
        this.topDoor = topDoor;
        this.leftDoor = leftDoor;
        this.bottomDoor = bottomDoor;
        this.rightDoor = rightDoor;
        this.currentRoom = currentRoom;
        this.topRoomSerial = topRoomSerial;
        this.bottomRoomSerial = bottomRoomSerial;
        this.leftRoomSerial = leftRoomSerial;
        this.rightRoomSerial = rightRoomSerial;
        this.x = x;
        this.y = y;
    }
}
