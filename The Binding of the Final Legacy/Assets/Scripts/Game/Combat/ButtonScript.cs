using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject pointer;
    private GameObject lvl2;
    private GameObject lvl3;
    private GlobalButton globalButton;
    private List <GameObject> lvl2Background;
    private List <GameObject>  lvl3Background;
    private GameObject myEventSystem;

    private void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        lvl2 = GameObject.FindGameObjectWithTag("Level 2");
        lvl3 = GameObject.FindGameObjectWithTag("Level 3");
        lvl2Background = new List<GameObject>();
        lvl3Background = new List<GameObject> ();
        globalButton = GameObject.FindGameObjectWithTag("Global Button").GetComponent<GlobalButton>();
        myEventSystem = GameObject.Find("EventSystem");

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
    public void OnPointerEnter(PointerEventData eventData)
    {
        

    }

    public void OnSelect(BaseEventData eventData)
    {
        switch (transform.name)
        {
            case "Fight":
                if (!globalButton.subMenu1Active)
                {
                    pointer.transform.position = new Vector3(25.0f, 78.0f, 0f);
                    pointer.SetActive(true);
                }

                break;

            case "Defend":
                if (!globalButton.subMenu1Active)
                {
                    pointer.transform.position = new Vector3(25.0f, 27.4f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Inventory":
                if (!globalButton.subMenu1Active)
                {
                    pointer.transform.position = new Vector3(163.8f, 78.0f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Run Away":

                if (!globalButton.subMenu1Active)
                {
                    pointer.transform.position = new Vector3(163.8f, 27.4f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Selected Item Sub Menu 1 - 1":
                if (!globalButton.subMenu2Active)
                {
                    //Debug.Log(transform.name + " + " + pointer.transform.position);
                    pointer.transform.position = new Vector3(61.2f, 144.1f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Selected Item Sub Menu 1 - 2":
                if (!globalButton.subMenu2Active)
                {
                    //Debug.Log(transform.name + " + " + pointer.transform.position);
                    pointer.transform.position = new Vector3(61.2f, 110.7f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Selected Item Sub Menu 1 - 3":
                //Debug.Log(transform.name + " + " + pointer.transform.position);
                if (!globalButton.subMenu2Active)
                {
                    pointer.transform.position = new Vector3(61.2f, 77.2f, 0f);
                    pointer.SetActive(true);
                }
                break;

            case "Selected Item Sub Menu 2 - 1":
                //Debug.Log(transform.name + " + " + pointer.transform.position);
                pointer.transform.position = new Vector3(176.1f, 195.3f, 0f);
                pointer.SetActive(true);
                break;

            case "Selected Item Sub Menu 2 - 2":
                //Debug.Log(transform.name + " + " + pointer.transform.position);
                pointer.transform.position = new Vector3(176.1f, 157.8f, 0f);
                pointer.SetActive(true);
                break;

            case "Selected Item Sub Menu 2 - 3":
                //Debug.Log(transform.name + " + " + pointer.transform.position);
                pointer.transform.position = new Vector3(176.1f, 121.5f, 0f);
                pointer.SetActive(true);
                break;
        }
        

        //myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
        //pointer.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        switch (transform.name)
        {
            case "Fight":
                if (!globalButton.subMenu1Active)
                {
                    for (int i = 0; i < lvl2Background.Count; i++)
                    {
                        if (lvl2Background[i].transform.name.Equals("Sub Menu 1"))
                        {
                            //Debug.Log("Background" + lvl2Background[i].transform.position);
                            lvl2Background[i].transform.position = new Vector3(452.7f, 153.4f, 0f);
                            lvl2Background[i].SetActive(true);
                        }

                        else if (lvl2Background[i].transform.name.Equals("Buttons"))
                        {
                            //Debug.Log("Buttons" + lvl2Background[i].transform.position);
                            lvl2Background[i].transform.position = new Vector3(372.7f, 221.5f, 0f);
                            lvl2Background[i].SetActive(true);
                        }
                    }

                    globalButton.subMenu1Active = true;
                }

                else
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
                        }
                    }

                    globalButton.subMenu1Active = false;
                }

                break;

            case "Defend":
                if (!globalButton.subMenu1Active)
                { }

                else
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
                        }
                    }

                    globalButton.subMenu1Active = false;
                }

                break;

            case "Inventory":
                if (!globalButton.subMenu1Active)
                { }

                else
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
                        }
                    }

                    globalButton.subMenu1Active = false;
                }

                break;

            case "Run Away":
                if (!globalButton.subMenu1Active)
                { }

                else
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
                        }
                    }

                    globalButton.subMenu1Active = false;
                }

                break;

            case "Selected Item Sub Menu 1 - 1":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < lvl3Background.Count; i++)
                    {
                        if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                        {
                            //Debug.Log("Background" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(568.2f, 202.1f, 0f);
                            lvl3Background[i].SetActive(true);
                        }

                        else if (lvl3Background[i].transform.name.Equals("Buttons"))
                        {
                            //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(359.9f, 210.8f, 0f);
                            lvl3Background[i].SetActive(true);
                        }
                    }

                    globalButton.subMenu2Active = true;
                }

                else
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
                        }
                    }

                    globalButton.subMenu2Active = false;
                }

                break;

            case "Selected Item Sub Menu 1 - 2":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < lvl3Background.Count; i++)
                    {
                        if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                        {
                            //Debug.Log("Background" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(568.2f, 202.1f, 0f);
                            lvl3Background[i].SetActive(true);
                        }

                        else if (lvl3Background[i].transform.name.Equals("Buttons"))
                        {
                            //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(359.9f, 210.8f, 0f);
                            lvl3Background[i].SetActive(true);
                        }
                    }

                    globalButton.subMenu2Active = true;

                }

                else
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
                        }
                    }

                    globalButton.subMenu2Active = false;
                }

                break;

            case "Selected Item Sub Menu 1 - 3":

                if (!globalButton.subMenu2Active)
                {
                    for (int i = 0; i < lvl3Background.Count; i++)
                    {
                        if (lvl3Background[i].transform.name.Equals("Sub Menu 2"))
                        {
                            //Debug.Log("Background" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(568.2f, 202.1f, 0f);
                            lvl3Background[i].SetActive(true);
                        }

                        else if (lvl3Background[i].transform.name.Equals("Buttons"))
                        {
                            //Debug.Log("Buttons" + lvl3Background[i].transform.position);
                            lvl3Background[i].transform.position = new Vector3(359.9f, 210.8f, 0f);
                            lvl3Background[i].SetActive(true);
                        }
                    }

                    globalButton.subMenu2Active = true;

                }

                else
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
                        }
                    }

                    globalButton.subMenu2Active = false;
                }

                break;
    
    }

        if (Input.GetButtonDown("Cancel"))
        {
            if (globalButton.subMenu2Active)
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
                    }
                }

                globalButton.subMenu2Active = false;
            }

            else if (globalButton.subMenu1Active)
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
                    }
                }

                globalButton.subMenu1Active = false;
            }
        }
    }
}
