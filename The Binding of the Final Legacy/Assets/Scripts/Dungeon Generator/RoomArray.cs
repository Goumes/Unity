using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomArray : MonoBehaviour
{
    public List<GameObject> minimapRooms;
    public int minNumber = 5;
    public int maxNumber = 10;
    private GameObject lastRoom;
    public float waitTime;
    private bool spawnedBoss;
    private Tilemap tilemap;
    public List<GameObject> realRooms;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Invoke("checkArrayLength", 1f);

        if (waitTime <= 0)
        {
            for (int i = 0; i < minimapRooms.Count && !spawnedBoss; i++)
            {
                if (i == minimapRooms.Count - 1)
                {
                    tilemap = minimapRooms[i].GetComponent<Tilemap>();
                    //Cambiar esto por una habitación de boss real
                    tilemap.SetTile(new Vector3Int(0, -3, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(1, -3, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(0, -2, 0), Resources.Load("Cuadrado") as Tile);
                    tilemap.SetTile(new Vector3Int(1, -2, 0), Resources.Load("Cuadrado") as Tile);
                    spawnedBoss = true;

                    //Aqui se empieza a crear el array con las mazmorras de verdad
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Method that checks if the number of rooms is greater than the minimum. If it's smaller, it forces the last room to generate more.
    /// </summary>
    private void checkArrayLength()
    {
        if (minimapRooms.Count < minNumber)
        {
            //Debug.Log("minimo");
            lastRoom = minimapRooms[minimapRooms.Count - 1];
            lastRoom.GetComponentInChildren<Room>().generate = true;
        }
    }
}
