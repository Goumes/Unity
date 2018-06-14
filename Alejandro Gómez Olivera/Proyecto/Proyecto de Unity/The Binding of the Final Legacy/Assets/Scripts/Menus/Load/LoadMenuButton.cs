using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject empty;
    private GameObject notEmpty;
    private GameObject selected;
    private TextMeshProUGUI playerName;
    private GameObject attributes;
    private LoadMenu loadMenu;
    private int saveNumber;
    private GameDataManager gameDataManager;
    private GameObject pointer;
    private MenuGlobalButton globalButton;
	// Use this for initialization
	void Start ()
    {
        if (!transform.name.Equals("Back Button"))
        {
            loadMenu = transform.GetComponentInParent<LoadMenu>();
            saveNumber = Convert.ToInt32(transform.parent.transform.name.Substring(5));
            gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        }
        
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        globalButton = GameObject.FindGameObjectWithTag("MenuGlobalButton").GetComponent<MenuGlobalButton>();


        if (!transform.name.Equals("Back Button"))
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).transform.CompareTag("NotEmptySave"))
                {
                    notEmpty = transform.parent.GetChild(i).gameObject;
                }
                else if (transform.parent.GetChild(i).CompareTag("EmptySave"))
                {
                    empty = transform.parent.GetChild(i).gameObject;
                }
                else if (transform.parent.GetChild(i).CompareTag("LoadMenuSelected"))
                {
                    selected = transform.parent.GetChild(i).gameObject;
                }
            }

            for (int i = 0; i < notEmpty.transform.childCount; i++)
            {
                if (notEmpty.transform.GetChild(i).CompareTag("LoadMenuName"))
                {
                    playerName = notEmpty.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
                }

                else if (notEmpty.transform.GetChild(i).CompareTag("LoadMenuAttributes"))
                {
                    attributes = notEmpty.transform.GetChild(i).gameObject;
                }
            }

            selected.SetActive(false);
            Invoke("checkSavedGame", 0.001f);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        Invoke("ResetPointer", 0.01f);
    }

    /// <summary>
    /// Method that resets the pointer
    /// </summary>
    private void ResetPointer()
    {
        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1208f, -349f, 0f);
    }

    /// <summary>
    /// Method that checks if there is any savedGame for the current save slot. If so, it displays the details.
    /// </summary>
    private void checkSavedGame()
    {
        GameSave save = null;

        if ((saveNumber) <= loadMenu.files.Length)
        {
            empty.SetActive(false);

            gameDataManager.selectedSave = loadMenu.fileNames[saveNumber - 1];
            save = gameDataManager.LoadGame();
            playerName.SetText(save.player.playerDetails.name);

            for (int i = 0; i < attributes.transform.childCount; i++)
            {
                if (attributes.transform.GetChild(i).name.Equals("Attack Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(save.player.playerDetails.attack).ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Defense Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(save.player.playerDetails.defense).ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Health Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(save.player.playerDetails.currentHealth).ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Wealth Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(save.player.playerDetails.gold).ToString());
                }
            }

        }
        else
        {
            notEmpty.SetActive(false);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (!transform.name.Equals("Back Button"))
        {
            selected.SetActive(true);
        }
        else
        {
            Color tmp;
            pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-154f, -475f, 0f);
            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<Text>().color;
                tmp.a = 1f;
                transform.GetChild(i).GetComponent<Text>().color = tmp;
            }
        }

        globalButton.currentButton = gameObject;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!transform.name.Equals("Back Button"))
        {
            selected.SetActive(false);
        }
        else
        {
            pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1208f, -349f, 0f);
            Color tmp;
            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<Text>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).GetComponent<Text>().color = tmp;
            }
        }
    }

    public void OnClick()
    {
        if (!transform.name.Equals("Back Button"))
        {
            gameDataManager.selectedSave = loadMenu.fileNames[saveNumber - 1];
            gameDataManager.hasSavedGame = true;
            gameDataManager.lvl = gameDataManager.LoadGame().player.playerDetails.level;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    private void OnDisable()
    {
        if (transform.name.Equals("Back Button"))
        {
            Color tmp;

            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<Text>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).GetComponent<Text>().color = tmp;
            }
        }
    }
}