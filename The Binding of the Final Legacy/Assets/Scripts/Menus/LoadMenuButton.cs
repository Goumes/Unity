using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject empty;
    private GameObject notEmpty;
    private GameObject selected;
    private TextMeshProUGUI playerName;
    private GameObject attributes;
    private LoadMenu loadMenu;
    private int saveNumber;
    private GameDataManager gameDataManager;
	// Use this for initialization
	void Start ()
    {
        loadMenu = transform.GetComponentInParent<LoadMenu>();
        saveNumber = Convert.ToInt32(transform.parent.transform.name.Substring(5));
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();

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
	
	// Update is called once per frame
	void Update ()
    {
		
	}
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
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(save.player.playerDetails.attack.ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Defense Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(save.player.playerDetails.defense.ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Health Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(save.player.playerDetails.health.ToString());
                }
                else if (attributes.transform.GetChild(i).name.Equals("Wealth Text"))
                {
                    attributes.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(save.player.playerDetails.gold.ToString());
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
        selected.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selected.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(selected.transform.name);
        selected.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected.SetActive(false);
    }

    public void OnClick()
    {
        gameDataManager.selectedSave = loadMenu.fileNames[saveNumber - 1];
        gameDataManager.hasSavedGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
