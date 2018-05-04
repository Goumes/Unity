using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomArray : MonoBehaviour
{
    public List<GameObject> rooms;
    public int minNumber = 5;
    public int maxNumber = 10;
    private GameObject lastRoom;
    public float waitTime;
    private bool spawnedBoss;
    private Tilemap tilemap;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Invoke("checkArrayLength", 1f);

        if (waitTime <= 0)
        {
            for (int i = 0; i < rooms.Count && !spawnedBoss; i++)
            {
                if (i == rooms.Count - 1)
                {
                    tilemap = rooms[i].GetComponent<Tilemap>();
                    //Cambiar esto por una habitación de boss real
                    tilemap.SetTile(new Vector3Int(0, -3, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(1, -3, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(0, -2, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(1, -2, 0), Resources.Load("Cuadrado") as Tile);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void checkArrayLength()
    {
        if (rooms.Count < minNumber)
        {
            //Debug.Log("minimo");
            lastRoom = rooms[rooms.Count - 1];
            lastRoom.GetComponentInChildren<Room>().generate = true;
        }
    }
}
