using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GlobalButton : MonoBehaviour
{
    public bool subMenu1Active;
    public bool subMenu2Active;
    private Management management;
    public GameObject player;
    private GameObject lvl1;
    private GameObject lvl2;
    private GameObject lvl3;
    private List<GameObject> lvl1Background;
    private List<GameObject> lvl2Background;
    private List<GameObject> lvl3Background;
    private GameObject pointer;
    public GameObject currentButton;
    private EventSystem myEventSystem;
    public GameObject[] enemyModels;
    public GameObject[] enemyBars;
    public GameObject[] enemyInfo;
    public GameObject[] playerBars;
    public GameObject playerInfo;
    public float goldReward;
    public List<GenericItem> itemReward;
    public int abilitySelected;
    public Coroutine blinkCoroutine;
    private bool ended;

    // Use this for initialization
    void Start () {
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        player = GameObject.FindGameObjectWithTag("Player");
        lvl1 = GameObject.FindGameObjectWithTag("Level 1");
        lvl2 = GameObject.FindGameObjectWithTag("Level 2");
        lvl3 = GameObject.FindGameObjectWithTag("Level 3");
        lvl1Background = new List<GameObject>();
        lvl2Background = new List<GameObject>();
        lvl3Background = new List<GameObject>();
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        enemyModels = GameObject.FindGameObjectsWithTag("EnemyCombat");
        enemyBars = GameObject.FindGameObjectsWithTag("EnemyBars");
        enemyInfo = GameObject.FindGameObjectsWithTag("CombatEnemyInfo");
        playerBars = GameObject.FindGameObjectsWithTag("PlayerBars");
        playerInfo = GameObject.FindGameObjectWithTag("CombatPlayerInfo");
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


        for (int i = 0; i < lvl1.transform.childCount; i++)
        {
            for (int j = 0; j < lvl1.transform.GetChild(i).childCount; j++)
            {
                if (lvl1.transform.GetChild(i).GetChild(j).CompareTag("Main Menu"))
                {
                    lvl1Background.Add(lvl1.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
        }


        for (int i = 0; i < lvl2.transform.childCount; i++)
        {
            for (int j = 0; j < lvl2.transform.GetChild(i).childCount; j++)
            {
                if (lvl2.transform.GetChild(i).GetChild(j).CompareTag("Submenu"))
                {
                    lvl2Background.Add(lvl2.transform.GetChild(i).GetChild(j).gameObject);
                }
            }

        }

        for (int i = 0; i < lvl3.transform.childCount; i++)
        {
            for (int j = 0; j < lvl3.transform.GetChild(i).childCount; j++)
            {
                if (lvl3.transform.GetChild(i).GetChild(j).CompareTag("Submenu"))
                {
                    lvl3Background.Add(lvl3.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
        }
        //player.SetActive(false);
    }

    private void OnEnable()
    {
        Invoke("firstEnable", 0.01f);
    }

    private void firstEnable()
    {
        int counter = 0;

        goldReward = 0;
        itemReward = new List<GenericItem>();
        ended = false;

        for (int i = 0; i < enemyModels.Length && counter < 2; i++)
        {
            if (management.randomBoolean(0.6f))
            {
                enemyModels[i].SetActive(false);
                counter++;
            }
        }

        for (int j = 0; j < lvl1Background[0].transform.childCount; j++)
        {
            if (lvl1Background[0].transform.GetChild(j).transform.name.Equals("Main Menu"))
            {
                for (int k = 0; k < lvl1Background[0].transform.GetChild(j).childCount; k++)
                {
                    lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = true;

                    if (k == 0)
                    {
                        lvl1Background[0].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                    }
                }
            }
        }

        for (int i = 0; i < enemyModels.Length; i++)
        {
            switch (enemyModels[i].transform.name)
            {
                case "Enemy Combat In-Game 1":

                    if (enemyModels[i].gameObject.activeSelf)
                    {
                        enableEnemyUI(1);
                    }
                    else
                    {
                        disableEnemyUI(1);
                    }

                    break;

                case "Enemy Combat In-Game 2":

                    if (enemyModels[i].gameObject.activeSelf)
                    {
                        enableEnemyUI(2);
                    }
                    else
                    {
                        disableEnemyUI(2);
                    }

                    break;

                case "Enemy Combat In-Game 3":

                    if (enemyModels[i].gameObject.activeSelf)
                    {
                        enableEnemyUI(3);
                    }
                    else
                    {
                        disableEnemyUI(3);
                    }

                    break;
            }
        }

        for (int i = 0; i < lvl2Background.Count; i++)
        {
            if (lvl2Background[i].transform.name.Equals("Buttons"))
            {
                for (int j = 0; j < lvl2Background[i].transform.GetChild(0).childCount; j++)
                {
                    switch (lvl2Background[i].transform.GetChild(0).GetChild(j).transform.name)
                    {
                        case "Selected Item Sub Menu 1 - 1":
                            for (int k = 0; k < lvl2Background[i].transform.GetChild(0).GetChild(j).transform.childCount; k++)
                            {
                                switch (lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).transform.name)
                                {
                                    case "Ability Text":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(player.GetComponent<Player>().playerStats.abilities[0].name);
                                        break;

                                    case "Mana Cost":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(player.GetComponent<Player>().playerStats.abilities[0].manaCost).ToString());
                                        break;
                                }
                            }
                            break;

                        case "Selected Item Sub Menu 1 - 2":
                            for (int k = 0; k < lvl2Background[i].transform.GetChild(0).GetChild(j).transform.childCount; k++)
                            {
                                switch (lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).transform.name)
                                {
                                    case "Ability Text":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(player.GetComponent<Player>().playerStats.abilities[1].name);
                                        break;

                                    case "Mana Cost":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(player.GetComponent<Player>().playerStats.abilities[1].manaCost).ToString());
                                        break;
                                }
                            }
                            break;

                        case "Selected Item Sub Menu 1 - 3":
                            for (int k = 0; k < lvl2Background[i].transform.GetChild(0).GetChild(j).transform.childCount; k++)
                            {
                                switch (lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).transform.name)
                                {
                                    case "Ability Text":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(player.GetComponent<Player>().playerStats.abilities[2].name);
                                        break;

                                    case "Mana Cost":
                                        lvl2Background[i].transform.GetChild(0).GetChild(j).transform.GetChild(k).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(player.GetComponent<Player>().playerStats.abilities[2].manaCost).ToString());
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }


        StartCoroutine(management.fadeStartCombat());
    }

    private void OnDisable()
    {
        for (int i = 0; i < enemyModels.Length; i++)
        {
              enemyModels[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (subMenu2Active)
            {
                closeSubMenu2();
            }

            else if (subMenu1Active)
            {
                closeSubMenu1();
            }
        }

        else if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }

        updateUI();

        if (!ended)
        {
            checkForEnd();
        }
    }

    public void closeSubMenu2()
    {
        for (int i = 0; i < lvl3Background.Count; i++)
        {
            if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
            {
                lvl3Background[i].SetActive(false);
            }

            else if (lvl3Background[i].transform.name.Equals("Buttons"))
            {
                lvl3Background[i].SetActive(false);

                for (int j = 0; j < lvl2Background[i].transform.childCount; j++)
                {
                    if (lvl2Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 1"))
                    {
                        for (int k = 0; k < lvl2Background[i].transform.GetChild(j).childCount; k++)
                        {
                            lvl2Background[i].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = true;

                            if (k == 0)
                            {
                                lvl2Background[i].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                            }
                        }
                    }
                }
            }
        }

        subMenu2Active = false;
    }

    public void closeSubMenu1()
    {
        for (int i = 0; i < lvl2Background.Count; i++)
        {
            if (lvl2Background[i].transform.name.Equals("Sub Menu 1"))
            {
                lvl2Background[i].SetActive(false);
            }

            else if (lvl2Background[i].transform.name.Equals("Buttons"))
            {
                lvl2Background[i].SetActive(false);

                for (int j = 0; j < lvl1Background[0].transform.childCount; j++)
                {
                    if (lvl1Background[0].transform.GetChild(j).transform.name.Equals("Main Menu"))
                    {
                        for (int k = 0; k < lvl1Background[0].transform.GetChild(j).childCount; k++)
                        {
                            lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = true;

                            if (k == 0)
                            {
                                lvl1Background[0].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                            }
                        }
                    }
                }
            }
        }

        subMenu1Active = false;
    }

    public void disableEnemyUI(int number)
    {
        for (int i = 0; i < lvl3Background.Count; i++)
        {
            if (lvl3Background[i].transform.name.Equals("Buttons"))
            {
                for (int j = 0; j < lvl3Background[i].transform.childCount; j++)
                {
                    if (lvl3Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 2"))
                    {
                        for (int k = 0; k < lvl3Background[i].transform.GetChild(j).childCount; k++)
                        {
                            if (Convert.ToInt32(lvl3Background[i].transform.GetChild(j).transform.GetChild(k).transform.name.Substring(27)) == number)
                            {
                                lvl3Background[i].transform.GetChild(j).transform.GetChild(k).gameObject.SetActive(false);
                            }
                        }
                    }
                }

            }
        }

        for (int i = 0; i < enemyBars.Length; i++)
        {
            if (Convert.ToInt32(enemyBars[i].transform.name[6]) - 48 == number)
            {
                enemyBars[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < enemyInfo.Length; i++)
        {
            if (Convert.ToInt32(enemyInfo[i].transform.name[6]) - 48 == number)
            {
                enemyInfo[i].SetActive(false);
            }
        }
    }

    public void enableEnemyUI(int number)
    {
        for (int i = 0; i < lvl3Background.Count; i++)
        {
            if (lvl3Background[i].transform.name.Equals("Buttons"))
            {
                for (int j = 0; j < lvl3Background[i].transform.childCount; j++)
                {
                    if (lvl3Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 2"))
                    {
                        for (int k = 0; k < lvl3Background[i].transform.GetChild(j).childCount; k++)
                        {
                            if (Convert.ToInt32(lvl3Background[i].transform.GetChild(j).transform.GetChild(k).transform.name.Substring(27)) == number)
                            {
                                lvl3Background[i].transform.GetChild(j).transform.GetChild(k).gameObject.SetActive(true);

                                lvl3Background[i].transform.GetChild(j).transform.GetChild(k).transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(getEnemyByNumber(number).enemyStats.name);
                                    
                                
                            }
                        }
                    }
                }

            }
        }

        for (int i = 0; i < enemyBars.Length; i++)
        {
            if (Convert.ToInt32(enemyBars[i].transform.name[6]) - 48 == number)
            {
                enemyBars[i].gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < enemyInfo.Length; i++)
        {
            if (Convert.ToInt32(enemyInfo[i].transform.name[6]) - 48 == number)
            {
                enemyInfo[i].SetActive(true);
            }
        }
    }

    public EnemyModel getEnemyByNumber(int number)
    {
        EnemyModel resultado = null;

        for (int i = 0; i < enemyModels.Length; i++)
        {
            if (Convert.ToInt32(enemyModels[i].transform.name.Substring(21)) == number)
            {
                resultado = enemyModels[i].transform.GetChild(0).gameObject.GetComponent<EnemyModel>();
            }
            
        }

        return resultado;
    }

    private void updateUI()
    {
        int number = 0;
        EnemyModel enemy = null;
        Player playerDetails = player.GetComponent<Player>();

        for (int i = 0; i < enemyInfo.Length; i++)
        {
            if (enemyInfo[i].activeSelf)
            {
                number = Convert.ToInt32(enemyInfo[i].transform.name[6]) - 48;
                enemy = getEnemyByNumber(number);

                for (int j = 0; j < enemyInfo[i].transform.childCount; j++)
                {
                    switch (enemyInfo[i].transform.GetChild(j).transform.name)
                    {
                        case "Enemy Name":
                            enemyInfo[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(enemy.enemyStats.name);
                            break;

                        case "Enemy HP Current Value":
                            enemyInfo[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(enemy.enemyStats.currentHealth).ToString());
                            break;

                        case "Enemy HP Total Value":
                            enemyInfo[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(enemy.enemyStats.totalHealth).ToString());
                            break;

                        case "Enemy MP Current Value":
                            enemyInfo[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(enemy.enemyStats.currentMana).ToString());
                            break;

                        case "Enemy MP Total Value":
                            enemyInfo[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(enemy.enemyStats.totalMana).ToString());
                            break;
                    }
                }
            }
            
        }


        for (int i = 0; i < enemyBars.Length; i++)
        {
            if (enemyBars[i].activeSelf)
            {
                number = Convert.ToInt32(enemyBars[i].transform.name[6]) - 48;
                enemy = getEnemyByNumber(number);

                for (int j = 0; j < enemyBars[i].transform.childCount; j++)
                {
                    switch (enemyBars[i].transform.GetChild(j).transform.name)
                    {
                        case "Mana Bar":
                            enemyBars[i].transform.GetChild(j).GetComponent<Slider>().value = enemy.enemyStats.currentMana / enemy.enemyStats.totalMana;
                            break;

                        case "Health Bar":
                            enemyBars[i].transform.GetChild(j).GetComponent<Slider>().value = enemy.enemyStats.currentHealth / enemy.enemyStats.totalHealth;
                            break;
                    }
                }
            }

        }

        for (int i = 0; i < playerBars.Length; i++)
        {
            for (int j = 0; j < playerBars[i].transform.childCount; j++)
            {
                switch (playerBars[i].transform.GetChild(j).transform.name)
                {
                    case "Mana Bar":
                        playerBars[i].transform.GetChild(j).GetComponent<Slider>().value = player.GetComponent<Player>().playerStats.currentMana / player.GetComponent<Player>().playerStats.totalMana;
                        break;

                    case "Health Bar":
                        playerBars[i].transform.GetChild(j).GetComponent<Slider>().value = player.GetComponent<Player>().playerStats.currentHealth / player.GetComponent<Player>().playerStats.totalHealth;
                        break;
                }
            }
        }

        for (int i = 0; i < playerInfo.transform.childCount; i++)
        {
            switch (playerInfo.transform.GetChild(i).transform.name)
            {
                case "Player Name":
                    playerInfo.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(playerDetails.playerStats.name);
                    break;

                case "Player HP Current Value":
                    playerInfo.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(playerDetails.playerStats.currentHealth).ToString());
                    break;

                case "Player HP Total Value":
                    playerInfo.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(playerDetails.playerStats.totalHealth).ToString());
                    break;

                case "Player MP Current Value":
                    playerInfo.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(playerDetails.playerStats.currentMana).ToString());
                    break;

                case "Player MP Total Value":
                    playerInfo.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(playerDetails.playerStats.totalMana).ToString());
                    break;
            }
        }
    }

    public void startEnemyTurn()
    {
        StartCoroutine(enemyTurn());
    }

    public IEnumerator enemyTurn ()
    {
        bool found = false;
        Ability selectedAbility;

        closeSubMenu2();
        closeSubMenu1();
        disableMenu();

        for (int i = 0; i < enemyModels.Length; i++)
        {
            if (enemyModels[i].activeSelf)
            {
                found = false;

                for (int j = 0; j < enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().abilities.Count && !found; j++)
                {
                    if (management.randomBoolean(0.2f)) //Más probabilidades de que sea un ataque básico
                    {
                        selectedAbility = enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().abilities[j];

                        if (enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().enemyStats.currentMana >= selectedAbility.manaCost)
                        {

                            yield return new WaitForSeconds(1f);

                            enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().enemyStats.currentMana = enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().enemyStats.currentMana - selectedAbility.manaCost;

                            if (player.GetComponent<Player>().playerStats.currentHealth - ((selectedAbility.dmgMultiplier * enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().enemyStats.attack) - player.GetComponent<Player>().playerStats.defense * 2) > 0f)
                            {
                                player.GetComponent<Player>().playerStats.currentHealth = player.GetComponent<Player>().playerStats.currentHealth - ((selectedAbility.dmgMultiplier * enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().enemyStats.attack) - player.GetComponent<Player>().playerStats.defense * 2);
                            }

                            else
                            {
                                player.GetComponent<Player>().playerStats.currentHealth = 0f;
                                management.GameOver();
                                //Borrar partida y volver al menu principal
                            }

                            //Aqui va la animación

                            found = true;
                        }
                    }

                    if (j == enemyModels[i].transform.GetChild(0).GetComponent<EnemyModel>().abilities.Count - 1)
                    {
                        j = -1;
                    }
                }
            }
        }

        enableMenu();
    }

    private void disableMenu()
    {
        for (int j = 0; j < lvl1Background[0].transform.childCount; j++)
        {
            if (lvl1Background[0].transform.GetChild(j).transform.name.Equals("Main Menu"))
            {
                for (int k = 0; k < lvl1Background[0].transform.GetChild(j).childCount; k++)
                {
                    lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    private void enableMenu()
    {
        for (int j = 0; j < lvl1Background[0].transform.childCount; j++)
        {
            if (lvl1Background[0].transform.GetChild(j).transform.name.Equals("Main Menu"))
            {
                for (int k = 0; k < lvl1Background[0].transform.GetChild(j).childCount; k++)
                {
                    lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = true;

                    if (k == 0)
                    {
                        lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().Select();
                    }

                }
            }
        }
    }

    private void checkForEnd()
    {
        bool exists = false;

        for (int i = 0; i < enemyModels.Length && !exists; i++)
        {
            if (enemyModels[i].activeSelf)
            {
                exists = true;
            }
        }

        if (!exists)
        {
            ended = true;
            //Aqui ira la pantalla de wintoria
            player.GetComponent<Player>().playerStats.gold = player.GetComponent<Player>().playerStats.gold + goldReward;

            for (int i = 0; i < itemReward.Count; i++)
            {
                player.GetComponent<Player>().playerStats.inventory.Add(itemReward[i]);
            }

            management.WinCombat();
        }
    }

}
