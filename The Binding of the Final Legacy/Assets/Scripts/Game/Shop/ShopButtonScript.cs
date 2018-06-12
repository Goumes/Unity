using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool sold;

    private GameObject pointer;
    private Management management;
    private ShopGlobalButton globalButton;
    private GameObject mainMenu;
    private GameObject itemMenu;
    private List<GameObject> mainButtons;
    private List<GameObject> itemButtons;
    private GameObject [] itemDescriptions;
    private GenericItem currentItem;
    private GameObject currentSoldText;
    private GameObject currentItemModel;
    private Player player;
    
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
        itemDescriptions = GameObject.FindGameObjectsWithTag("ShopItemDescription");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        for (int i = 0; i < mainMenu.transform.childCount; i++)
        {
            if (!mainMenu.transform.GetChild(i).CompareTag("ShopItemDescription"))
            {
                mainButtons.Add(mainMenu.transform.GetChild(i).gameObject);
            }
            
        }

        for (int i = 0; i < itemMenu.transform.childCount; i++)
        {
            if (!itemMenu.transform.GetChild(i).CompareTag("ShopItemDescription"))
            {
                itemButtons.Add(itemMenu.transform.GetChild(i).gameObject);
            }
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < itemDescriptions.Length; i++)
        {
            if (itemDescriptions[i].transform.name.Equals("Item Description Info"))
            {
                for (int j = 0; j < itemDescriptions[i].transform.childCount; j++)
                {
                    if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Player's Gold"))
                    {
                        itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(player.playerStats.gold.ToString());
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        Invoke("enableMethod", 0.01f);
    }

    /// <summary>
    /// Reloads all the previously instantiated items and sets as sold the previously sold items
    /// </summary>
    private void enableMethod()
    {


        for (int i = 0; i < globalButton.soldItems.Count; i++)
        {
            if (globalButton.soldItems[i].Equals(transform.name))
            {
                sold = true;
            }
        }

        for (int i = 0; i < globalButton.allItems.Length; i++)
        {
            if (globalButton.allItems[i].transform.name.Equals(transform.name))
            {
                currentItem = globalButton.allItems[i].GetComponent<Item>().currentItem;
                //Debug.Log("Button: " +transform.name + " + "+ currentItem.name);
            }
        }

        for (int i = 0; i < globalButton.allSoldTexts.Length; i++)
        {
            //Debug.Log("array :" + globalButton.allSoldTexts[i].transform.name[5] + " + " + transform.name[5]);

            if (transform.name.Length > 5 && globalButton.allSoldTexts[i].transform.name[5].Equals(transform.name[5]))
            {
                currentSoldText = globalButton.allSoldTexts[i];
                if (!sold)
                {
                    currentSoldText.SetActive(false);
                }
                else
                {
                    currentSoldText.SetActive(true);
                }
                
            }
        }

        for (int i = 0; i < globalButton.allItemModels.Length; i++)
        {
            if (transform.name.Length > 5 && globalButton.allItemModels[i].transform.name[5].Equals(transform.name[5]))
            {
                currentItemModel = globalButton.allItemModels[i];
            }
        }


        for (int i = 0; i < itemDescriptions.Length; i++)
        {
            itemDescriptions[i].SetActive(false);
        }
    }

    /// <summary>
    /// Updates the item description with the selected item
    /// </summary>
    private void selectedItem()
    {
        Color tmp;

        for (int i = 0; i < itemDescriptions.Length; i++)
        {
            if (itemDescriptions[i].transform.name.Equals("Item Description Info"))
            {
                for (int j = 0; j < itemDescriptions[i].transform.childCount; j++)
                {
                    if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Item Name Text"))
                    {
                        itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(currentItem.name);

                        if (!sold)
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 1f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                        else
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 0.58f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                    }

                    else if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Item Description Text"))
                    {
                        itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(currentItem.description);

                        if (!sold)
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 1f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                        else
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 0.58f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                    }

                    else if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Item Price Text"))
                    {
                        itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(currentItem.price.ToString());

                        if (!sold)
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 1f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                        else
                        {
                            tmp = itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color;
                            tmp.a = 0.58f;
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().color = tmp;
                        }
                    }
                    else if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Sold Text"))
                    {
                        if (sold)
                        {
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("SOLD");
                        }
                        else
                        {
                            itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");
                        }
                    }
                }
            }

            itemDescriptions[i].SetActive(true);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        Color tmp;

        switch (transform.name)
        {
            case "Buy":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-826f, -386f, 0f);

                for (int i = 0; i < itemDescriptions.Length; i++)
                {
                    itemDescriptions[i].SetActive(false);
                }
                break;

            case "Sell":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-226f, -386f, 0f);

                break;

            case "Leave":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(370f, -386f, 0f);

                break;

            case "Item 1":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-920f, 325f, 0f);

                selectedItem();

                break;

            case "Item 2":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-920f, -18f, 0f);

                selectedItem();

                break;

            case "Item 3":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-547f, 325f, 0f);

                selectedItem();

                break;

            case "Item 4":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-547f, -18f, 0f);

                selectedItem();

                break;

            case "Item 5":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(251f, 325f, 0f);

                selectedItem();

                break;

            case "Item 6":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(251f, -18f, 0f);

                selectedItem();

                break;

            case "Item 7":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(614f, 325f, 0f);

                selectedItem();

                break;

            case "Item 8":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(614f, -18f, 0f);

                selectedItem();

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
        Color tmp;

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
            case "Item 2":
            case "Item 3":
            case "Item 4":
            case "Item 5":
            case "Item 6":
            case "Item 7":
            case "Item 8":

                if (!sold && player.playerStats.gold >= currentItem.price)
                {
                    player.playerStats.inventory.Add(currentItem);
                    player.playerStats.gold = player.playerStats.gold - currentItem.price;
                    sold = true;
                    currentSoldText.SetActive(true);
                    tmp = currentItemModel.GetComponent<RawImage>().color;
                    tmp.a = 0.58f;
                    currentItemModel.GetComponent<RawImage>().color = tmp;
                    selectedItem();
                    globalButton.soldItems.Add(transform.name);
                }

                else if (player.playerStats.gold < currentItem.price)
                {
                    for (int i = 0; i < itemDescriptions.Length; i++)
                    {
                        if (itemDescriptions[i].transform.name.Equals("Item Description Info"))
                        {
                            for (int j = 0; j < itemDescriptions[i].transform.childCount; j++)
                            {
                                if (itemDescriptions[i].transform.GetChild(j).transform.name.Equals("Player's Gold"))
                                {
                                    StopCoroutine(notEnoughGold(itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>()));
                                    StartCoroutine(notEnoughGold(itemDescriptions[i].transform.GetChild(j).GetComponent<TextMeshProUGUI>()));
                                }
                            }
                        }
                    }
                }

                
                
                break;
        }
    }

    /// <summary>
    /// Makes the player's gold blink as it doesn't have enough.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator notEnoughGold(TextMeshProUGUI text)
    {
        Color tmp = new Color();

        for (int i = 0; i < 4; i++)
        {
            tmp = new Color(255, 0, 0);
            text.color = tmp;
            yield return new WaitForSeconds(0.1f);
            tmp = new Color(166, 14, 14);
            text.color = tmp;
            yield return new WaitForSeconds(0.1f);
        }

        text.color = new Color(255, 255, 255);
    }
}
