using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public EnemyClass enemyStats;
    private Database database;
    public GenericItem itemDrop;
    private Management management;
    public List<Ability> abilities;
    public bool hasDrop;

	// Use this for initialization
	void Start ()
    {
        database = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        Invoke("firstEnable", 0.001f);
    }

    private void firstEnable()
    {
        bool assigned = false;


        for (int i = 0; i < database.enemyDatabase.enemies.Count && !assigned; i++)
        {
            if (management.randomBoolean(0.8f) && database.enemyDatabase.enemies[i].type != "boss")
            {
                enemyStats = new EnemyClass(database.enemyDatabase.enemies[i]);
                assignAbilities();
                assigned = true;
            }

            if (i == database.enemyDatabase.enemies.Count - 1)
            {
                i = 0;
            }
        }


        assigned = false;
        hasDrop = management.randomBoolean(0.1f); //Poner un 0.95

        if (hasDrop)
        {
            for (int i = 0; i < database.itemDatabase.itemList.Count && !assigned; i++)
            {
                if (management.randomBoolean(0.8f))
                {
                    itemDrop = database.itemDatabase.itemList[i];
                    database.itemDatabase.itemList.RemoveAt(i);
                    assigned = true;
                }

                if (i == database.itemDatabase.itemList.Count - 1)
                {
                    i = 0;
                }
            }
        }


        Debug.Log("Enemy: " + enemyStats.name + " + " + transform.name);

        if (hasDrop)
        {
            Debug.Log("Item: " + itemDrop.name);
        }

        for (int i = 0; i < abilities.Count; i++)
        {
            Debug.Log(abilities[i].name);
        }
        
    }

    private void assignAbilities ()
    {
        abilities = new List<Ability>();
        for (int i = 0; i < database.abilityDatabase.abilities.Count; i++)
        {
            for (int j = 0; j < enemyStats.abilities.Count; j++)
            {
                if (enemyStats.abilities[j] == database.abilityDatabase.abilities[i].id)
                {
                    abilities.Add(database.abilityDatabase.abilities[i]);
                }
            }
        }
    }
}
