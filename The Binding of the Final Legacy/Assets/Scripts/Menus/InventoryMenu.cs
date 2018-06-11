using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public Player player;
    public GameObject currentButton;
    public GameObject itemsBackgrounds;
    public GameObject inventoryItems;
    public GameObject inventoryTexts;
    public GameObject inventoryButtons;
    public GenericItem selectedItem;
    public GameObject optionButtons;
    private EventSystem myEventSystem;
    private bool inOptions;
    private Management management;
    private string buttonName;
    private string parentName;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        itemsBackgrounds = GameObject.FindGameObjectWithTag("InventoryItemsBackground");
        inventoryItems = GameObject.FindGameObjectWithTag("InventoryItems");
        inventoryTexts = GameObject.FindGameObjectWithTag("InventoryTexts");
        inventoryButtons = GameObject.FindGameObjectWithTag("InventoryButtons");
        optionButtons = GameObject.FindGameObjectWithTag("InventoryOptions");
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar la info con el objeto seleccionado

        if (selectedItem != null && !selectedItem.Equals(new GenericItem ()))
        {
            updateItemInfo();
        }

        if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            if (inOptions)
            {
                cancelOptions();
            }
            else
            {
                management.closeInventory();
            }
        }

    }

    private void OnEnable()
    {
        Invoke("enableMethod", 0.001f);
    }

    private void enableMethod ()
    {
        firstSelect();
    }

    private void disableOptions()
    {
        bool selected = false;
        inOptions = false;

        optionButtons.SetActive(false);

        for (int i = 0; i < inventoryButtons.transform.childCount; i++)
        {
            inventoryButtons.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 0; i < inventoryButtons.transform.childCount && !selected; i++)
        {
            for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount && !selected; j++)
            {
                if (inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
                {
                    inventoryButtons.transform.GetChild(i).transform.GetChild(j).GetComponent<Button>().Select();
                    selected = true;
                }
            }
        }
    }

    private void cancelOptions()
    {
        bool selected = false;
        inOptions = false;


        optionButtons.SetActive(false);

        for (int i = 0; i < inventoryButtons.transform.childCount; i++)
        {
            inventoryButtons.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 0; i < inventoryButtons.transform.childCount && !selected; i++)
        {
            if (inventoryButtons.transform.GetChild(i).transform.name.Equals(parentName))
            {
                for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount && !selected; j++)
                {
                    if (inventoryButtons.transform.GetChild(i).transform.GetChild(j).transform.name.Equals(buttonName))
                    {
                        inventoryButtons.transform.GetChild(i).transform.GetChild(j).GetComponent<Button>().Select();
                        selected = true;
                    }
                }
            }
            
        }
    }

    public void firstSelect()
    {
        bool selected = false;

        //Vaciar textos y rellenar el nombre del jugador
        for (int i = 0; i < inventoryTexts.transform.childCount; i++)
        {
            switch (inventoryTexts.transform.GetChild(i).transform.name)
            {
                case "Player Name Text":

                    inventoryTexts.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(player.playerStats.name);

                    break;

                case "Item Description":

                    for (int j = 0; j < inventoryTexts.transform.GetChild(i).transform.childCount; j++)
                    {
                        switch (inventoryTexts.transform.GetChild(i).transform.GetChild(j).transform.name)
                        {
                            case "Item Name Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;

                            case "Item Description Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;

                            case "Attack Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;

                            case "Health Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;

                            case "Defense Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;

                            case "Gold Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText("");

                                break;
                        }
                    }

                    break;
            }
        }

        cleanInventory();

        //Desactivar options
        optionButtons.SetActive(false);

        updateInventory ();


        //Seleccionar boton
        for (int i = 0; i < inventoryButtons.transform.childCount && !selected; i++)
        {
            for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount && !selected; j++)
            {
                if (inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
                {
                    inventoryButtons.transform.GetChild(i).transform.GetChild(j).GetComponent<Button>().Select();
                    selected = true;
                }
            }
        }

    }

    private void updateInventory()
    {
        for (int i = 0; i < player.playerStats.inventory.Count; i++)
        {
            var item = player.playerStats.inventory[i];
            assignSlot(item, "item");
        }

        if (player.playerStats.weapon != null && !player.playerStats.weapon.Equals(new GenericItem()))
        {
            assignSlot(player.playerStats.weapon, "weapon");
        }

        if (player.playerStats.armor != null && !player.playerStats.armor.Equals(new GenericItem()))
        {
            assignSlot(player.playerStats.armor, "armor");
        }
    }

    private void cleanInventory()
    {
        //Desactivar sprites
        for (int i = 0; i < inventoryItems.transform.childCount; i++)
        {
            for (int j = 0; j < inventoryItems.transform.GetChild(i).transform.childCount; j++)
            {
                inventoryItems.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(false);
            }
        }

        //Desactivar botones
        for (int i = 0; i < inventoryButtons.transform.childCount; i++)
        {
            for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount; j++)
            {
                inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    private void assignSlot(GenericItem item, string type)
    {
        bool assigned = false;
        Sprite itemSprite = Resources.Load<Sprite>(item.imageResourcePath);

        switch (type)
        {
            case "item":

                for (int i = 0; i < inventoryButtons.transform.childCount && !assigned; i++)
                {
                    for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount && !assigned; j++)
                    {
                        if (!inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
                        {
                            inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                            assigned = true;
                        }
                    }
                }

                assigned = false;

                for (int i = 0; i < inventoryItems.transform.childCount && !assigned; i++)
                {
                    for (int j = 0; j < inventoryItems.transform.GetChild(i).transform.childCount && !assigned; j++)
                    {
                        if (!inventoryItems.transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
                        {
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().overrideSprite = itemSprite;
                            assigned = true;
                        }
                    }
                }

                break;

            case "weapon":

                for (int i = 0; i < inventoryButtons.transform.childCount; i++)
                {
                    for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount; j++)
                    {
                        if (inventoryButtons.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Weapon"))
                        {
                            inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                        }
                    }
                }

                for (int i = 0; i < inventoryItems.transform.childCount; i++)
                {
                    for (int j = 0; j < inventoryItems.transform.GetChild(i).transform.childCount; j++)
                    {
                        if (inventoryItems.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Weapon"))
                        {
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().overrideSprite = itemSprite;
                        }
                    }
                }

                break;

            case "armor":

                for (int i = 0; i < inventoryButtons.transform.childCount; i++)
                {
                    for (int j = 0; j < inventoryButtons.transform.GetChild(i).transform.childCount; j++)
                    {
                        if (inventoryButtons.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Armor"))
                        {
                            inventoryButtons.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                        }
                    }
                }

                for (int i = 0; i < inventoryItems.transform.childCount; i++)
                {
                    for (int j = 0; j < inventoryItems.transform.GetChild(i).transform.childCount; j++)
                    {
                        if (inventoryItems.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Armor"))
                        {
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                            inventoryItems.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().overrideSprite = itemSprite;
                        }
                    }
                }

                break;
        }
    }

    private void updateItemInfo()
    {
        for (int i = 0; i < inventoryTexts.transform.childCount; i++)
        {
            switch (inventoryTexts.transform.GetChild(i).transform.name)
            {
                case "Item Description":

                    for (int j = 0; j < inventoryTexts.transform.GetChild(i).transform.childCount; j++)
                    {
                        switch (inventoryTexts.transform.GetChild(i).transform.GetChild(j).transform.name)
                        {
                            case "Item Name Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(selectedItem.name);

                                break;

                            case "Item Description Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(selectedItem.description);

                                break;

                            case "Attack Text":
                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(selectedItem.attackModifier).ToString());

                                break;

                            case "Health Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(selectedItem.healthModifier).ToString());

                                break;

                            case "Defense Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(selectedItem.defenseModifier).ToString());

                                break;

                            case "Gold Text":

                                inventoryTexts.transform.GetChild(i).transform.GetChild(j).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(selectedItem.sellingPrice).ToString());

                                break;
                        }
                    }

                    break;
            }
        }
    }

    public void OnClick()
    {
        bool selected = false;
        inOptions = true;
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        parentName = EventSystem.current.currentSelectedGameObject.transform.parent.name;

        optionButtons.SetActive(true);

        positionOptions(buttonName, parentName);

        if (!buttonName.Equals("Weapon") && !buttonName.Equals("Armor"))
        {
            for (int i = 0; i < optionButtons.transform.childCount; i++)
            {
                if (optionButtons.transform.GetChild(i).transform.name.Equals("Use") && selectedItem.type.Equals("potion") && selectedItem.duration == 0)
                {
                    optionButtons.transform.GetChild(i).gameObject.transform.GetComponent<Button>().interactable = true;
                }
                else if (optionButtons.transform.GetChild(i).transform.name.Equals("Equip") && (selectedItem.type.Equals("armor") || selectedItem.type.Equals("weapon")))
                {
                    optionButtons.transform.GetChild(i).gameObject.transform.GetComponent<Button>().interactable = true;
                }

                else if (optionButtons.transform.GetChild(i).transform.name.Equals("Drop"))
                {
                    optionButtons.transform.GetChild(i).gameObject.transform.GetComponent<Button>().interactable = true;
                }
            }
        }

        else
        {
            for (int i = 0; i < optionButtons.transform.childCount; i++)
            {
                if (optionButtons.transform.GetChild(i).transform.name.Equals("Equip"))
                {
                    optionButtons.transform.GetChild(i).gameObject.transform.name = "Unequip";
                    optionButtons.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("UNEQUIP");
                    optionButtons.transform.GetChild(i).gameObject.transform.GetComponent<Button>().interactable = true;
                }
            }
        }

        for (int i = 0; i < optionButtons.transform.childCount && !selected; i++)
        {
            if (!optionButtons.transform.GetChild(i).transform.name.Equals("Background") && optionButtons.transform.GetChild(i).gameObject.GetComponent<Button>().IsInteractable())
            {
                optionButtons.transform.GetChild(i).gameObject.transform.GetComponent<Button>().Select();
                selected = true;
            }
        }

        for (int i = 0; i < inventoryButtons.transform.childCount; i++)
        {
            inventoryButtons.transform.GetChild(i).gameObject.SetActive(false);
        }

        
    }

    private void positionOptions(string buttonName, string parentName)
    {
        switch (parentName)
        {
            case "Row 1":

                switch (buttonName)
                {
                    case "Item 1":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-692f, 310f, 0f);

                        break;

                    case "Item 2":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, 310f, 0f);

                        break;

                    case "Item 3":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-340f, 310f, 0f);

                        break;

                    case "Item 4":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-172f, 310f, 0f);

                        break;

                    case "Item 5":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6f, 310f, 0f);

                        break;

                    case "Item 6":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(178f, 310f, 0f);

                        break;

                    case "Item 7":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(356f, 310f, 0f);

                        break;

                    case "Item 8":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(530f, 310f, 0f);

                        break;
                }

                break;

            case "Row 2":

                switch (buttonName)
                {
                    case "Item 1":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-692f, 100f, 0f);

                        break;

                    case "Item 2":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, 100f, 0f);

                        break;

                    case "Item 3":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-340f, 100f, 0f);

                        break;

                    case "Item 4":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-172f, 100f, 0f);

                        break;

                    case "Item 5":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6f, 100f, 0f);

                        break;

                    case "Item 6":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(178f, 100f, 0f);

                        break;

                    case "Item 7":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(356f, 100f, 0f);

                        break;

                    case "Item 8":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(530f, 100f, 0f);

                        break;
                }

                break;

            case "Row 3":

                switch (buttonName)
                {
                    case "Item 1":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-692f, -92f, 0f);

                        break;

                    case "Item 2":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, -92f, 0f);

                        break;

                    case "Item 3":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-340f, -92f, 0f);

                        break;

                    case "Item 4":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-172f, -92f, 0f);

                        break;

                    case "Item 5":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6f, -92f, 0f);

                        break;

                    case "Item 6":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(178f, -92f, 0f);

                        break;

                    case "Item 7":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(356f, -92f, 0f);

                        break;

                    case "Item 8":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(530f, -92f, 0f);

                        break;
                }

                break;

            case "Row 4":

                switch (buttonName)
                {
                    case "Item 1":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-692f, -274f, 0f);

                        break;

                    case "Item 2":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-531f, -274f, 0f);

                        break;

                    case "Item 3":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-340f, -274f, 0f);

                        break;

                    case "Item 4":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-172f, -274f, 0f);

                        break;

                    case "Item 5":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6f, -274f, 0f);

                        break;

                    case "Item 6":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(178f, -274f, 0f);

                        break;

                    case "Item 7":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(356f, -274f, 0f);

                        break;

                    case "Item 8":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(530f, -274f, 0f);

                        break;
                }

                break;

            case "Equiped Items":

                switch (buttonName)
                {
                    case "Weapon":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(552f, 302f, 0f);

                        break;

                    case "Armor":

                        optionButtons.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(726f, 302f, 0f);

                        break;
                }

                break;
        }
    }

    public void OnClickOptions()
    {
        string button = EventSystem.current.currentSelectedGameObject.name;

        switch (button)
        {
            case "Use":

                for (int i = 0; i < player.playerStats.inventory.Count; i++)
                {
                    if (player.playerStats.inventory[i].Equals(selectedItem))
                    {
                        if (player.playerStats.currentHealth + selectedItem.healthModifier <= player.playerStats.totalHealth)
                        {
                            player.playerStats.currentHealth = player.playerStats.currentHealth + selectedItem.healthModifier;
                        }

                        else
                        {
                            player.playerStats.currentHealth = player.playerStats.totalHealth;
                        }


                        if (player.playerStats.currentMana + selectedItem.manaModifier <= player.playerStats.totalMana)
                        {
                            player.playerStats.currentMana = player.playerStats.currentMana + selectedItem.manaModifier;
                        }

                        else
                        {
                            player.playerStats.currentMana = player.playerStats.totalMana;
                        }

                        player.playerStats.defense = player.playerStats.defense + selectedItem.defenseModifier;
                        player.playerStats.attack = player.playerStats.attack + selectedItem.attackModifier;

                        player.playerStats.inventory.RemoveAt(i);
                    }
                }

                break;

            case "Equip":

                for (int i = 0; i < player.playerStats.inventory.Count; i++)
                {
                    if (player.playerStats.inventory[i].Equals(selectedItem))
                    {
                        if (player.playerStats.inventory[i].type.Equals("weapon"))
                        {
                            if (player.playerStats.weapon != null && !player.playerStats.weapon.Equals(new GenericItem()))
                            {
                                player.playerStats.inventory.Add(player.playerStats.weapon);
                                player.playerStats.attack = player.playerStats.attack - player.playerStats.weapon.attackModifier;
                                player.playerStats.defense = player.playerStats.defense - player.playerStats.weapon.defenseModifier;
                                player.playerStats.totalHealth = player.playerStats.totalHealth - player.playerStats.weapon.healthModifier;
                                player.playerStats.totalMana = player.playerStats.totalMana - player.playerStats.weapon.manaModifier;
                            }

                            player.playerStats.weapon = player.playerStats.inventory[i];
                            player.playerStats.attack = player.playerStats.attack + player.playerStats.weapon.attackModifier;
                            player.playerStats.defense = player.playerStats.defense + player.playerStats.weapon.defenseModifier;
                            player.playerStats.totalHealth = player.playerStats.totalHealth + player.playerStats.weapon.healthModifier;
                            player.playerStats.totalMana = player.playerStats.totalMana + player.playerStats.weapon.manaModifier;
                            player.playerStats.inventory.RemoveAt(i);
                        }
                        else
                        {
                            if (player.playerStats.armor != null && !player.playerStats.armor.Equals(new GenericItem()))
                            {
                                player.playerStats.inventory.Add(player.playerStats.armor);
                                player.playerStats.attack = player.playerStats.attack - player.playerStats.armor.attackModifier;
                                player.playerStats.defense = player.playerStats.defense - player.playerStats.armor.defenseModifier;
                                player.playerStats.totalHealth = player.playerStats.totalHealth - player.playerStats.armor.healthModifier;
                                player.playerStats.totalMana = player.playerStats.totalMana - player.playerStats.armor.manaModifier;
                            }

                            player.playerStats.armor = player.playerStats.inventory[i];
                            player.playerStats.attack = player.playerStats.attack + player.playerStats.armor.attackModifier;
                            player.playerStats.defense = player.playerStats.defense + player.playerStats.armor.defenseModifier;
                            player.playerStats.totalHealth = player.playerStats.totalHealth + player.playerStats.armor.healthModifier;
                            player.playerStats.totalMana = player.playerStats.totalMana + player.playerStats.armor.manaModifier;
                            player.playerStats.inventory.RemoveAt(i);
                        }

                        if (player.playerStats.currentHealth > player.playerStats.totalHealth)
                        {
                            player.playerStats.currentHealth = player.playerStats.totalHealth;
                        }

                        if (player.playerStats.currentMana > player.playerStats.totalMana)
                        {
                            player.playerStats.currentMana = player.playerStats.totalMana;
                        }
                    }
                }

                break;

            case "Drop":

                for (int i = 0; i < player.playerStats.inventory.Count; i++)
                {
                    if (player.playerStats.inventory[i].Equals(selectedItem))
                    {
                        player.playerStats.inventory.RemoveAt(i);
                    }
                }

                break;

            case "Unequip":

                if (selectedItem.type.Equals("armor"))
                {
                    player.playerStats.inventory.Add(player.playerStats.armor);
                    player.playerStats.defense = player.playerStats.defense - player.playerStats.armor.defenseModifier;
                    player.playerStats.armor = null;
                }

                else
                {
                    player.playerStats.inventory.Add(player.playerStats.weapon);
                    player.playerStats.attack = player.playerStats.attack - player.playerStats.weapon.attackModifier;
                    player.playerStats.weapon = null;
                }

                break;
        }

        cleanInventory();
        updateInventory();
        disableOptions();
    }
}
