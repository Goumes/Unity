using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomElements : MonoBehaviour
{
    private RoomArray rooms;
    private bool shopGenerated;

	// Use this for initialization
	void Start ()
    {
        shopGenerated = false;
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomArray>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rooms.created)
        {

        }
	}
}
