using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject pointer;
    private GameObject lvl2;
    private GameObject lvl3;
    private GlobalButton globalButton;
    private List <GameObject> lvl2Background;
    private List <GameObject>  lvl3Background;
    private GameObject myEventSystem;
    private GameObject [] selectedEnemies;
    private Management management;

    private void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        lvl2 = GameObject.FindGameObjectWithTag("Level 2");
        lvl3 = GameObject.FindGameObjectWithTag("Level 3");
        lvl2Background = new List<GameObject>();
        lvl3Background = new List<GameObject> ();
        selectedEnemies = GameObject.FindGameObjectsWithTag("Enemy Selected");
        globalButton = GameObject.FindGameObjectWithTag("Global Button").GetComponent<GlobalButton>();
        myEventSystem = GameObject.Find("EventSystem");
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();

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
        Invoke("Scape", 0.1f);
    }

    private void Scape()
    {
        
    }
    public void OnSelect(BaseEventData eventData)
    {
        bool blinking = false;
        Color tmp;

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
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, -48f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    selectedEnemies[i].GetComponent<SelectEnemy>().stopBlinking();
                }

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    if (selectedEnemies[i].transform.name.Equals("Blob Combat In-Game Selected 1"))
                    {
                        selectedEnemies[i].GetComponent<SelectEnemy>().startBlinking();
                    }
                }
                break;

            case "Selected Item Sub Menu 2 - 2":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, -137f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    selectedEnemies[i].GetComponent<SelectEnemy>().stopBlinking();
                }

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    if (selectedEnemies[i].transform.name.Equals("Blob Combat In-Game Selected 2"))
                    {
                        selectedEnemies[i].GetComponent<SelectEnemy>().startBlinking();
                    }
                }


                break;

            case "Selected Item Sub Menu 2 - 3":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, -226f, 0f);

                for (int i = 0; i < selectedEnemies.Length; i++)
                {
                    selectedEnemies[i].GetComponent<SelectEnemy>().stopBlinking();
                }

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
            tmp = transform.GetChild(i).GetComponent<Text>().color;
            tmp.a = 1f;
            transform.GetChild(i).GetComponent<Text>().color = tmp;
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
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }
                

                break;

            case "Defend":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Inventory":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Run Away":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 1 - 1":
                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }
                break;

            case "Selected Item Sub Menu 1 - 2":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 1 - 3":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Selected Item Sub Menu 2 - 1":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;

            case "Selected Item Sub Menu 2 - 2":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;

            case "Selected Item Sub Menu 2 - 3":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
        }
    }
    public void clickButton()
    {
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
                                lvl3Background[i].transform.GetChild(j).GetChild(0).GetComponent<Button>().Select();
                            }
                        }

                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                

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
                                lvl3Background[i].transform.GetChild(j).GetChild(0).GetComponent<Button>().Select();
                            }
                        }
                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                

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
                                lvl3Background[i].transform.GetChild(j).GetChild(0).GetComponent<Button>().Select();
                            }
                        }
                    }
                }

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }

                

                break;
    
        }
    }
}
