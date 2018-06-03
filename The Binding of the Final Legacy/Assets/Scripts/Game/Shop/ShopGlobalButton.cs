using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopGlobalButton : MonoBehaviour
{
    public bool itemSelectorActive;
    public bool confirmActive;
    public GameObject currentButton;
    private GameObject mainMenu;
    private GameObject itemMenu;
    private List<GameObject> mainButtons;
    private List<GameObject> itemButtons;
    private EventSystem myEventSystem;
    private Management management;

    // Use this for initialization
    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("Shop Main Buttons");
        itemMenu = GameObject.FindGameObjectWithTag("Shop Item Buttons");
        mainButtons = new List<GameObject>();
        itemButtons = new List<GameObject>();
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();

        for (int i = 0; i < mainMenu.transform.childCount; i++)
        {
            mainButtons.Add(mainMenu.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < itemMenu.transform.childCount; i++)
        {
            itemButtons.Add(itemMenu.transform.GetChild(i).gameObject);
        }
    }

    private void OnEnable()
    {
        Invoke("firstEnable", 0.1f);
    }

    private void firstEnable()
    {
        StartCoroutine(management.fadeStartShop());

        mainButtons[0].GetComponent<Button>().Select();

        for (int i = 0; i < itemButtons.Count; i++)
        {
            itemButtons[i].GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (confirmActive)
            {

            }

            else if (itemSelectorActive)
            {
                for (int i = 0; i < itemButtons.Count; i++)
                {
                    itemButtons[i].GetComponent<Button>().interactable = false;
                }

                for (int i = 0; i < mainButtons.Count; i++)
                {
                    if (i == 0)
                    {
                        mainButtons[i].GetComponent<Button>().Select();
                    }
                    mainButtons[i].GetComponent<Button>().interactable = true;
                }

                itemSelectorActive = false;
            }
        }

        else if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }
    }
}
