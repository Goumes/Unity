using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public int serialNumber;
    private List<GameObject> enemies;
    private Management management;
    private List<GameObject> misc;
    private List<GameObject> chests;
    public bool hasChest;
    public bool hasShop;
    public bool hasBoss;
	// Use this for initialization
	void Start ()
    {
        enemies = new List<GameObject>();
        misc = new List<GameObject>();
        chests = new List<GameObject>();

        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("In-Game Enemy"))
            {
                enemies.Add(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Vase"))
            {
                misc.Add(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Chest"))
            {
                chests.Add(transform.GetChild(i).gameObject);
            }
        }

        generateEnemies();
        generateChests();
        generateMisc();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void generateEnemies ()
    {
       
        for (int i = 0; i < enemies.Count; i++)
        {
            if (management.randomBoolean(0.5f) && !hasBoss)
            {
                enemies[i].SetActive(false);
            }
            else if (hasBoss)
            {
                enemies[i].SetActive(false);
            }
        }
        
    }

    private void generateChests()
    {
        for (int i = 0; i < chests.Count; i++)
        {
            if (management.randomBoolean(0.5f) && !hasBoss)
            {
                chests[i].SetActive(false);
            }
            else if (hasBoss)
            {
                chests[i].SetActive(false);
            }
        }
    }

    private void generateMisc()
    {
        for (int i = 0; i < misc.Count; i++)
        {
            if (management.randomBoolean(0.5f) && !hasBoss)
            {
                misc[i].SetActive(false);
            }
            else if (hasBoss)
            {
                misc[i].SetActive(false);
            }
        }
    }
}
