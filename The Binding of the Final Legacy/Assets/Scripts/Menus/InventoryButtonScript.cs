using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private InventoryMenu inventoryMenu;
    private GameObject pointer;

    // Use this for initialization
    void Start ()
    {
        inventoryMenu = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryMenu>();
        pointer = GameObject.FindGameObjectWithTag("InventoryPointer");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        var number = 0;
        Vector3 position = new Vector3();
        Color tmp;

        switch (transform.parent.transform.name)
        {
            case "Row 1":

                switch (transform.name)
                {
                    case "Item 1":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-917f, 187f, 0f);
                        number = 0;

                        break;

                    case "Item 2":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-739f, 187f, 0f);
                        number = 1;

                        break;

                    case "Item 3":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-556f, 187f, 0f);
                        number = 2;

                        break;

                    case "Item 4":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-386f, 187f, 0f);
                        number = 3;

                        break;

                    case "Item 5":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-215f, 187f, 0f);
                        number = 4;

                        break;

                    case "Item 6":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-31f, 187f, 0f);
                        number = 5;

                        break;

                    case "Item 7":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(146f, 187f, 0f);
                        number = 6;

                        break;

                    case "Item 8":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(321f, 187f, 0f);
                        number = 7;

                        break;
                }

                break;

            case "Row 2":

                switch (transform.name)
                {
                    case "Item 1":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-917f, -18f, 0f);
                        number = 8;

                        break;

                    case "Item 2":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-739f, -18f, 0f);
                        number = 9;

                        break;

                    case "Item 3":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-556f, -18f, 0f);
                        number = 10;

                        break;

                    case "Item 4":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-386f, -18f, 0f);
                        number = 11;

                        break;

                    case "Item 5":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-215f, -18f, 0f);
                        number = 12;

                        break;

                    case "Item 6":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-31f, -18f, 0f);
                        number = 13;

                        break;

                    case "Item 7":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(146f, -18f, 0f);
                        number = 14;

                        break;

                    case "Item 8":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(321f, -18f, 0f);
                        number = 15;

                        break;
                }

                break;

            case "Row 3":

                switch (transform.name)
                {
                    case "Item 1":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-917f, -217f, 0f);
                        number = 16;

                        break;

                    case "Item 2":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-739f, -217f, 0f);
                        number = 17;

                        break;

                    case "Item 3":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-556f, -217f, 0f);
                        number = 18;

                        break;

                    case "Item 4":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-386f, -217f, 0f);
                        number = 19;

                        break;

                    case "Item 5":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-215f, -217f, 0f);
                        number = 20;

                        break;

                    case "Item 6":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-31f, -217f, 0f);
                        number = 21;

                        break;

                    case "Item 7":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(146f, -217f, 0f);
                        number = 22;

                        break;

                    case "Item 8":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(321f, -217f, 0f);
                        number = 23;

                        break;
                }

                break;

            case "Row 4":

                switch (transform.name)
                {
                    case "Item 1":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-917f, -396f, 0f);
                        number = 24;

                        break;

                    case "Item 2":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-739f, -396f, 0f);
                        number = 25;

                        break;

                    case "Item 3":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-556f, -396f, 0f);
                        number = 26;

                        break;

                    case "Item 4":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-386f, -396f, 0f);
                        number = 27;

                        break;

                    case "Item 5":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-215f, -396f, 0f);
                        number = 28;

                        break;

                    case "Item 6":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-31f, -396f, 0f);
                        number = 29;

                        break;

                    case "Item 7":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(146f, -396f, 0f);
                        number = 30;

                        break;

                    case "Item 8":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(321f, -396f, 0f);
                        number = 31;

                        break;
                }

                break;

            case "Equiped Items":

                switch (transform.name)
                {
                    case "Weapon":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(549f, 180f, 0f);
                        number = -1;

                        break;

                    case "Armor":

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(728f, 180f, 0f);
                        number = -2;

                        break;
                }

                break;

            case "Options Container":

                switch (transform.name)
                {
                    case "Use":

                        position = transform.parent.transform.GetComponent<RectTransform>().anchoredPosition;

                        position.x = position.x - 152f;
                        position.y = position.y + 71f;

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = position;

                        number = -3;

                        break;

                    case "Equip":
                    case "Unequip":

                        position = transform.parent.transform.GetComponent<RectTransform>().anchoredPosition;

                        position.x = position.x - 152f;
                        position.y = position.y -3.419949f;

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = position;

                        number = -3;

                        break;

                    case "Drop":

                        position = transform.parent.transform.GetComponent<RectTransform>().anchoredPosition;

                        position.x = position.x - 152f;
                        position.y = position.y -77.84297f;

                        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = position;

                        number = -3;

                        break;
                }

                break;
        }

        if (number >= 0)
        {
            if (inventoryMenu.player.playerStats.inventory.Count > number)
            {
                inventoryMenu.selectedItem = inventoryMenu.player.playerStats.inventory[number];
            }
        }
        else if (number == -1)
        {
            if (inventoryMenu.player.playerStats.weapon != null && !inventoryMenu.player.playerStats.weapon.Equals(new GenericItem()))
            {
                inventoryMenu.selectedItem = inventoryMenu.player.playerStats.weapon;
            }
        }
        else if (number == -2)
        {
            if (inventoryMenu.player.playerStats.armor != null && !inventoryMenu.player.playerStats.armor.Equals(new GenericItem()))
            {
                inventoryMenu.selectedItem = inventoryMenu.player.playerStats.armor;
            }
        }
        else if (number == -3)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                tmp.a = 1f;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
            }
        }

        inventoryMenu.currentButton = gameObject;
    }


    public void OnDeselect(BaseEventData eventData)
    {
        Color tmp;

        switch (transform.name)
        {
            case "Use":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;

            case "Equip":
            case "Unequip":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;

            case "Drop":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
        }
    }

    private void OnDisable()
    {
        Color tmp;

        switch (transform.name)
        {
            case "Use":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                transform.GetComponent<Button>().interactable = false;

                break;

            case "Equip":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                transform.GetComponent<Button>().interactable = false;

                break;

            case "Unequip":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                transform.GetComponent<Button>().interactable = false;
                transform.name = "Equip";
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("EQUIP");

                break;

            case "Drop":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                transform.GetComponent<Button>().interactable = false;

                break;
        }
    }
}