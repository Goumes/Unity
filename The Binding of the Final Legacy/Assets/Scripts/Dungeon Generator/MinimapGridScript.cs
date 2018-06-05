using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGridScript : MonoBehaviour {

    public int globalCounter;
    public bool canGenerate;
    private GameDataManager gameDataManager;

	// Use this for initialization
	void Start ()
    {
        globalCounter = 1;
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        Invoke("checkSavedGame", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void checkSavedGame()
    {
        if (!gameDataManager.hasSavedGame)
        {
            canGenerate = true;
            var generatedRoom = Instantiate(Resources.Load("Default Room") as GameObject, transform.position, Quaternion.identity);
            generatedRoom.transform.parent = transform;
            generatedRoom.GetComponentInChildren<MinimapRoom>().serialNumber = 1;

        }

        else
        {
            loadMinimap(gameDataManager.LoadGame("Prueba1"));
        }
    }

    private void loadMinimap(GameSave save)
    {
        for (int i = 0; i < save.minimapGrid.rooms.Count; i++)
        {
            var saveRoom = save.minimapGrid.rooms[i];
            var generatedRoom = Instantiate(Resources.Load("Default Room") as GameObject, new Vector3(transform.position.x + saveRoom.x, transform.position.y + saveRoom.y, 0), Quaternion.identity);
            var childPositions = new Dictionary<string, int>();

            if (saveRoom.topRoomSerial > 0)
            {
                childPositions.Add("T", saveRoom.topRoomSerial);
            }

            if (saveRoom.bottomRoomSerial > 0)
            {
                childPositions.Add("B", saveRoom.bottomRoomSerial);
            }

            if (saveRoom.leftRoomSerial > 0)
            {
                childPositions.Add("L", saveRoom.leftRoomSerial);
            }

            if (saveRoom.rightRoomSerial > 0)
            {
                childPositions.Add("R", saveRoom.rightRoomSerial);
            }


            generatedRoom.transform.name = "Default Room " + saveRoom.serialNumber;
            generatedRoom.transform.parent = transform;
            generatedRoom.GetComponentInChildren<MinimapRoom>().serialNumber = saveRoom.serialNumber;
            generatedRoom.GetComponentInChildren<MinimapRoom>().topDoor = saveRoom.topDoor;
            generatedRoom.GetComponentInChildren<MinimapRoom>().bottomDoor = saveRoom.bottomDoor;
            generatedRoom.GetComponentInChildren<MinimapRoom>().leftDoor = saveRoom.leftDoor;
            generatedRoom.GetComponentInChildren<MinimapRoom>().rightDoor = saveRoom.rightDoor;
            generatedRoom.GetComponentInChildren<MinimapRoom>().currentRoom = saveRoom.currentRoom;
            generatedRoom.GetComponentInChildren<MinimapRoom>().childPositions = childPositions;

        }
    }
}
