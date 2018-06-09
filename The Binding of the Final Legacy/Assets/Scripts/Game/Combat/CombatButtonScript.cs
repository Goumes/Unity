using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject pointer;
    private GameObject lvl1;
    private GameObject lvl2;
    private GameObject lvl3;
    private GlobalButton globalButton;
    private List<GameObject> lvl1Background;
    private List <GameObject> lvl2Background;
    private List <GameObject>  lvl3Background;
    private GameObject myEventSystem;
    private GameObject [] selectedEnemies;
    private Management management;

    private void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        lvl1 = GameObject.FindGameObjectWithTag("Level 1");
        lvl2 = GameObject.FindGameObjectWithTag("Level 2");
        lvl3 = GameObject.FindGameObjectWithTag("Level 3");
        lvl1Background = new List<GameObject>();
        lvl2Background = new List<GameObject>();
        lvl3Background = new List<GameObject> ();
        selectedEnemies = GameObject.FindGameObjectsWithTag("Enemy Selected");
        globalButton = GameObject.FindGameObjectWithTag("Global Button").GetComponent<GlobalButton>();
        myEventSystem = GameObject.Find("EventSystem");
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();

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
    }

    private void Update()
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        Color tmp;

        if (globalButton.blinkCoroutine != null)
        {
            for (int i = 0; i < selectedEnemies.Length; i++)
            {
                selectedEnemies[i].GetComponent<SelectEnemy>().stopBlinking();
            }
        }

        switch (transform.name)
        {
            case "Fight":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-900f, -349f, 0f);

                break;

            case "Defend":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-900f, -473f, 0f);

                break;

            case "Inventory":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-558f, -349f, 0f);

                break;

            case "Run Away":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-558f, -473f, 0f);

                break;

            case "Selected Item Sub Menu 1 - 1":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-816f, -171f, 0f);
                break;

            case "Selected Item Sub Menu 1 - 2":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-816f, -247f, 0f);

                break;

            case "Selected Item Sub Menu 1 - 3":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-816f, -334f, 0f);

                break;

            case "Selected Item Sub Menu 2 - 1":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-564f, -48f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    if (selectedEnemies[i].transform.name.Equals("Blob Combat In-Game Selected 1"))
                    {
                        selectedEnemies[i].GetComponent<SelectEnemy>().startBlinking();
                    }
                }
                break;

            case "Selected Item Sub Menu 2 - 2":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-564f, -137f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    if (selectedEnemies[i].transform.name.Equals("Blob Combat In-Game Selected 2"))
                    {
                        selectedEnemies[i].GetComponent<SelectEnemy>().startBlinking();
                    }
                }


                break;

            case "Selected Item Sub Menu 2 - 3":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-564f, -226f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    if (selectedEnemies[i].transform.name.Equals("Blob Combat In-Game Selected 3"))
                    {
                        selectedEnemies[i].GetComponent<SelectEnemy>().startBlinking();
                    }
                }


                break;
        }

        pointer.SetActive(true);
        globalButton.currentButton = gameObject;

        for (int i = 0; i < transform.childCount; i++)
        {
            tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
            tmp.a = 1f;
            transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
        }


        //myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
        //pointer.SetActive(true);
    }

    public void OnDeselect(BaseEventData baseEvent)
    {
        Color tmp;

        switch (transform.name)
        {
            case "Fight":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }
                

                break;

            case "Defend":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }

                break;

            case "Inventory":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }

                break;

            case "Run Away":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 1 - 1":
                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }
                break;

            case "Selected Item Sub Menu 1 - 2":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 1 - 3":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 2 - 1":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }


                break;

            case "Selected Item Sub Menu 2 - 2":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;

            case "Selected Item Sub Menu 2 - 3":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
        }
    }
    public void clickButton()
    {
        bool selected = false;
        EnemyModel enemy = null;
        Player player = globalButton.player.GetComponent<Player>();

        switch (transform.name)
        {
            case "Fight":

                    for (int i = 0; i < lvl2Background.Count; i++)
                    {
                        if (lvl2Background[i].transform.name.Equals("Sub Menu 1"))
                        {
                            //Debug.Log("Background" + gameObject.GetComponent<RectTransform>().anchoredPosition);
                            lvl2Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(137.9999f, -148, 0f);
                            lvl2Background[i].SetActive(true);
                        }

                        else if (lvl2Background[i].transform.name.Equals("Buttons"))
                        {
                            //Debug.Log("Buttons" + gameObject.GetComponent<RectTransform>().anchoredPosition);
                            lvl2Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-57f, 18f, 0f);
                            lvl2Background[i].SetActive(true);

                            for (int j = 0; j < lvl2Background[i].transform.childCount; j++)
                            {
                                if (lvl2Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 1"))
                                {
                                    globalButton.subMenu1Active = true;
                                    lvl2Background[i].transform.GetChild(j).GetChild(0).GetComponent<Button>().Select();
                                }
                            }
                            
                        }
                    }

                    for (int i = 0; i < transform.parent.childCount; i++)
                    {
                        transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                    }

                    

                break;

            case "Defend":

                break;

            case "Inventory":

                break;

            case "Run Away":

                //for (int j = 0; j < lvl1Background[0].transform.childCount; j++)
                //{
                //    if (lvl1Background[0].transform.GetChild(j).transform.name.Equals("Main Menu"))
                //    {
                //        for (int k = 0; k < lvl1Background[0].transform.GetChild(j).childCount; k++)
                //        {
                //            lvl1Background[0].transform.GetChild(j).GetChild(k).gameObject.GetComponent<Button>().interactable = true;

                //            if (k == 0)
                //            {
                //                lvl1Background[0].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                //            }
                //        }
                //    }
                //}

                management.EndCombat();
                break;

            case "Selected Item Sub Menu 1 - 1":

                for (int i = 0; i < lvl3Background.Count; i++)
                {
                    if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                    {
                        //Debug.Log("Background" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(416.5f, -26.30003f, 0f);
                        lvl3Background[i].SetActive(true);
                    }

                    else if (lvl3Background[i].transform.name.Equals("Buttons"))
                    {
                        //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-90.99998f, -5f, 0f);
                        lvl3Background[i].SetActive(true);

                        for (int j = 0; j < lvl3Background[i].transform.childCount; j++)
                        {
                            if (lvl3Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 2"))
                            {
                                globalButton.subMenu2Active = true;

                                for (int k = 0; k < lvl3Background[i].transform.GetChild(j).transform.childCount && !selected; k++)
                                {
                                    if (lvl3Background[i].transform.GetChild(j).GetChild(k).gameObject.activeSelf)
                                    {
                                        lvl3Background[i].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                                        selected = true;

                                    }
                                }
                            }
                        }

                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                globalButton.abilitySelected = 0;

                

                break;

            case "Selected Item Sub Menu 1 - 2":

                for (int i = 0; i < lvl3Background.Count; i++)
                {
                    if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                    {
                        //Debug.Log("Background" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(416.5f, -26.30003f, 0f);
                        lvl3Background[i].SetActive(true);
                    }

                    else if (lvl3Background[i].transform.name.Equals("Buttons"))
                    {
                        //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-90.99998f, -5f, 0f);
                        lvl3Background[i].SetActive(true);

                        for (int j = 0; j < lvl3Background[i].transform.childCount; j++)
                        {
                            if (lvl3Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 2"))
                            {
                                globalButton.subMenu2Active = true;

                                for (int k = 0; k < lvl3Background[i].transform.GetChild(j).transform.childCount && !selected; k++)
                                {
                                    if (lvl3Background[i].transform.GetChild(j).GetChild(k).gameObject.activeSelf)
                                    {
                                        lvl3Background[i].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                                        selected = true;

                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                globalButton.abilitySelected = 1;

                break;

            case "Selected Item Sub Menu 1 - 3":

                for (int i = 0; i < lvl3Background.Count; i++)
                {
                    if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                    {
                        //Debug.Log("Background" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(416.5f, -26.30003f, 0f);
                        lvl3Background[i].SetActive(true);
                    }

                    else if (lvl3Background[i].transform.name.Equals("Buttons"))
                    {
                        //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                        lvl3Background[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-90.99998f, -5f, 0f);
                        lvl3Background[i].SetActive(true);

                        for (int j = 0; j < lvl3Background[i].transform.childCount; j++)
                        {
                            if (lvl3Background[i].transform.GetChild(j).transform.name.Equals("Sub Menu 2"))
                            {
                                globalButton.subMenu2Active = true;

                                for (int k = 0; k < lvl3Background[i].transform.GetChild(j).transform.childCount && !selected; k++)
                                {
                                    if (lvl3Background[i].transform.GetChild(j).GetChild(k).gameObject.activeSelf)
                                    {
                                        lvl3Background[i].transform.GetChild(j).GetChild(k).GetComponent<Button>().Select();
                                        selected = true;

                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                globalButton.abilitySelected = 2;

                break;

            case "Selected Item Sub Menu 2 - 1":

                enemy = globalButton.getEnemyByNumber(1);

                if (player.playerStats.currentMana >= player.playerStats.abilities[globalButton.abilitySelected].manaCost)
                {
                    player.playerStats.currentMana = player.playerStats.currentMana - player.playerStats.abilities[globalButton.abilitySelected].manaCost;

                    if (enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2) > 0)
                    {
                        enemy.enemyStats.currentHealth = enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2);
                    }

                    else
                    {
                        enemy.enemyStats.currentHealth = 0;
                        globalButton.goldReward = globalButton.goldReward + enemy.enemyStats.goldDrop;
                        globalButton.itemReward.Add(enemy.itemDrop);
                        enemy.gameObject.transform.parent.gameObject.SetActive(false);
                        globalButton.disableEnemyUI(1);

                        globalButton.closeSubMenu2();
                        globalButton.closeSubMenu1();
                        //Animaciones y toda la pesca
                    }

                    globalButton.startEnemyTurn();

                }

                //Cerrar todos los dialogos

                break;

            case "Selected Item Sub Menu 2 - 2":

                enemy = globalButton.getEnemyByNumber(2);

                if (player.playerStats.currentMana >= player.playerStats.abilities[globalButton.abilitySelected].manaCost)
                {
                    player.playerStats.currentMana = player.playerStats.currentMana - player.playerStats.abilities[globalButton.abilitySelected].manaCost;

                    if (enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2) > 0)
                    {
                        enemy.enemyStats.currentHealth = enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2);
                    }

                    else
                    {
                        enemy.enemyStats.currentHealth = 0;
                        globalButton.goldReward = globalButton.goldReward + enemy.enemyStats.goldDrop;
                        globalButton.itemReward.Add(enemy.itemDrop);
                        enemy.gameObject.transform.parent.gameObject.SetActive(false);
                        globalButton.disableEnemyUI(2);

                        globalButton.closeSubMenu2();
                        globalButton.closeSubMenu1();
                    }

                    globalButton.startEnemyTurn();

                }

                break;

            case "Selected Item Sub Menu 2 - 3":

                enemy = globalButton.getEnemyByNumber(3);

                if (player.playerStats.currentMana >= player.playerStats.abilities[globalButton.abilitySelected].manaCost)
                {
                    player.playerStats.currentMana = player.playerStats.currentMana - player.playerStats.abilities[globalButton.abilitySelected].manaCost;

                    if (enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2) > 0)
                    {
                        enemy.enemyStats.currentHealth = enemy.enemyStats.currentHealth - ((player.playerStats.abilities[globalButton.abilitySelected].dmgMultiplier * player.playerStats.attack) - enemy.enemyStats.defense * 2);
                    }

                    else
                    {
                        enemy.enemyStats.currentHealth = 0;
                        globalButton.goldReward = globalButton.goldReward + enemy.enemyStats.goldDrop;
                        globalButton.itemReward.Add(enemy.itemDrop);
                        enemy.gameObject.transform.parent.gameObject.SetActive(false);
                        globalButton.disableEnemyUI(3);

                        globalButton.closeSubMenu2();
                        globalButton.closeSubMenu1();

                    }

                    globalButton.startEnemyTurn();

                }

                break;

        }
    }
}
