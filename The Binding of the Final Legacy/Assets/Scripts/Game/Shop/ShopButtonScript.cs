using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject pointer;
    private Management management;
    private ShopGlobalButton globalButton;
    private GameObject mainMenu;
    private GameObject itemMenu;
    private List<GameObject> mainButtons;
    private List<GameObject> itemButtons;
    
    // Use this for initialization
    void Start ()
    {
        pointer = GameObject.FindGameObjectWithTag("ShopPointer");
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        globalButton = GameObject.FindGameObjectWithTag("Shop Global Button").GetComponent<ShopGlobalButton>();
        mainMenu = GameObject.FindGameObjectWithTag("Shop Main Buttons");
        itemMenu = GameObject.FindGameObjectWithTag("Shop Item Buttons");
        mainButtons = new List<GameObject>();
        itemButtons = new List<GameObject>();

        for (int i = 0; i < mainMenu.transform.childCount; i++)
        {
            mainButtons.Add(mainMenu.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < itemMenu.transform.childCount; i++)
        {
            itemButtons.Add(itemMenu.transform.GetChild(i).gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        Color tmp;

        switch (transform.name)
        {
            case "Buy":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-826f, -386f, 0f);

                break;

            case "Sell":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-226f, -386f, 0f);

                break;

            case "Leave":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(370f, -386f, 0f);

                break;

            case "Item 1":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-920f, 325f, 0f);
                break;

            case "Item 2":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-920f, -18f, 0f);

                break;

            case "Item 3":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-513f, 325f, 0f);

                break;

            case "Item 4":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-513f, -18f, 0f);
                break;

            case "Item 5":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(201f, 325f, 0f);


                break;

            case "Item 6":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(201f, -18f, 0f);
                break;

            case "Item 7":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(614f, 325f, 0f);
                break;

            case "Item 8":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(614f, -18f, 0f);
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

    }

    public void OnDeselect(BaseEventData baseEvent)
    {
        Color tmp;

        switch (transform.name)
        {
            case "Buy":
                if (!globalButton.itemSelectorActive)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }


                break;

            case "Sell":
                if (!globalButton.itemSelectorActive)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Leave":
                if (!globalButton.itemSelectorActive)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        tmp = transform.GetChild(i).GetComponent<Text>().color;
                        tmp.a = 0.58f;
                        transform.GetChild(i).GetComponent<Text>().color = tmp;
                    }
                }

                break;

            case "Item 1":
                break;

            case "Item 2":
                break;

            case "Item 3":

                break;

            case "Item 4":
                break;

            case "Item 5":
                break;

            case "Item 6":
                break;

            case "Item 7":
                break;

            case "Item 8":
                break;
        }
    }

    public void clickButton()
    {
        switch (transform.name)
        {
            case "Buy":

                for (int i = 0; i < itemButtons.Count; i++)
                {
                    if (i == 0)
                    {
                        itemButtons[i].GetComponent<Button>().Select();
                    }

                    itemButtons[i].GetComponent<Button>().interactable = true;
                }

                for (int i = 0; i < mainButtons.Count; i++)
                {
                    mainButtons[i].GetComponent<Button>().interactable = false;
                }

                globalButton.itemSelectorActive = true;

                break;

            case "Sell":
                break;

            case "Leave":

                //mainButtons[0].GetComponent<Button>().Select();

                management.EndShop();

                break;

            case "Item 1":
                break;

            case "Item 2":
                break;

            case "Item 3":

                break;

            case "Item 4":
                break;

            case "Item 5":
                break;

            case "Item 6":
                break;

            case "Item 7":
                break;

            case "Item 8":
                break;

        }
    }
}
