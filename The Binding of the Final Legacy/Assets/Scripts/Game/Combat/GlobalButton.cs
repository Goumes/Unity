using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GlobalButton : MonoBehaviour
{
    public bool subMenu1Active;
    public bool subMenu2Active;
    private Management management;
    private GameObject player;
    private GameObject lvl1;
    private GameObject lvl2;
    private GameObject lvl3;
    private List<GameObject> lvl1Background;
    private List<GameObject> lvl2Background;
    private List<GameObject> lvl3Background;
    private GameObject pointer;
    public GameObject currentButton;
    private EventSystem myEventSystem;
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
        management.inCombat = true;
        //player.SetActive(false);
    }

    private void OnEnable()
    {
        //management.inCombat = true;
        //player.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (subMenu2Active)
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

            else if (subMenu1Active)
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
        }

        else if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }
    }
}
