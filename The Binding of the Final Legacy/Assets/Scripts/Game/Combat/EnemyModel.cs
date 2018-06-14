using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public EnemyClass enemyStats;
    public List<Ability> abilities;
    public bool hasDrop;
    public bool isBoss;
    public GenericItem itemDrop;
    private Management management;
    private Database database;
    private GameDataManager gameDataManager;

    // Use this for initialization
    void Start ()
    {
        database = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        Invoke("firstEnable", 0.001f);
    }

    /// <summary>
    /// Loads its abilities, and gets a random item drop
    /// </summary>
    private void firstEnable()
    {
        bool assigned = false;


        for (int i = 0; i < database.enemyDatabase.enemies.Count && !assigned; i++)
        {
            if (management.randomBoolean(0.8f) && !isBoss && !database.enemyDatabase.enemies[i].type.Equals("boss"))
            {
                enemyStats = new EnemyClass(database.enemyDatabase.enemies[i]);
                assignAbilities();
                assigned = true;
            }

            else if (isBoss && database.enemyDatabase.enemies[i].type.Equals("boss"))
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

        if (!isBoss)
        {
            hasDrop = management.randomBoolean(0.95f); //Poner un 0.95
        }
        else
        {
            hasDrop = true;
        }


        if (hasDrop)
        {
            for (int i = 0; i < database.itemDatabase.itemList.Count && !assigned; i++)
            {
                if (management.randomBoolean(0.9f))
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
        else
        {
            itemDrop = null;
        }

        switch (gameDataManager.lvl)
        {
            case 2:

                enemyStats.attack = enemyStats.attack * 1.25f;
                enemyStats.defense = enemyStats.defense * 1.25f;
                enemyStats.totalHealth = enemyStats.totalHealth * 1.25f;
                enemyStats.totalMana = enemyStats.totalMana * 1.25f;
                enemyStats.currentHealth = enemyStats.totalHealth;
                enemyStats.currentMana = enemyStats.totalMana;
                enemyStats.goldDrop = enemyStats.goldDrop * 1.25f;

                break;
            case 3:

                enemyStats.attack = enemyStats.attack * 1.75f;
                enemyStats.defense = enemyStats.defense * 1.75f;
                enemyStats.totalHealth = enemyStats.totalHealth * 1.75f;
                enemyStats.totalMana = enemyStats.totalMana * 1.75f;
                enemyStats.currentHealth = enemyStats.totalHealth;
                enemyStats.currentMana = enemyStats.totalMana;
                enemyStats.goldDrop = enemyStats.goldDrop * 1.75f;

                break;
            case 4:

                enemyStats.attack = enemyStats.attack * 2.5f;
                enemyStats.defense = enemyStats.defense * 2.5f;
                enemyStats.totalHealth = enemyStats.totalHealth * 2.5f;
                enemyStats.totalMana = enemyStats.totalMana * 2.5f;
                enemyStats.currentHealth = enemyStats.totalHealth;
                enemyStats.currentMana = enemyStats.totalMana;
                enemyStats.goldDrop = enemyStats.goldDrop * 2.5f;

                break;


            case 5:

                enemyStats.attack = enemyStats.attack * 3.5f;
                enemyStats.defense = enemyStats.defense * 3.5f;
                enemyStats.totalHealth = enemyStats.totalHealth * 3.5f;
                enemyStats.totalMana = enemyStats.totalMana * 3.5f;
                enemyStats.currentHealth = enemyStats.totalHealth;
                enemyStats.currentMana = enemyStats.totalMana;
                enemyStats.goldDrop = enemyStats.goldDrop * 3.5f;

                break;
        }


        //Debug.Log("Enemy: " + enemyStats.name + " + " + transform.name);

        //if (hasDrop)
        //{
        //    Debug.Log("Item: " + itemDrop.name);
        //}

        //for (int i = 0; i < abilities.Count; i++)
        //{
        //    Debug.Log(abilities[i].name);
        //}
        
    }

    /// <summary>
    /// Loads its abilities
    /// </summary>
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
