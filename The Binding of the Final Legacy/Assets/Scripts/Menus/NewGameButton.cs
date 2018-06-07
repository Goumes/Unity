using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject selected;
    private GameObject pointer;
    private MenuGlobalButton globalButton;

    // Use this for initialization
    void Start ()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        globalButton = GameObject.FindGameObjectWithTag("MenuGlobalButton").GetComponent<MenuGlobalButton>();

        if (transform.CompareTag("NewGameButton"))
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).CompareTag("NewGameSelected"))
                {
                    selected = transform.parent.GetChild(i).gameObject;
                }
            }

            selected.SetActive(false);
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
            case "AttackButton":
            case "DefenseButton":
            case "HealthButton":
            case "WealthButton":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1208f, -349f, 0f);
                selected.SetActive(true);
                break;

            case "Back Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-343f, -443f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
            case "Next Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(104f, -443f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
            case "Back Button 2":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-352f, -31f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;

            case "Start Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(80f, -31f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
        }

        globalButton.currentButton = gameObject;

    }
    public void OnDeselect(BaseEventData eventData)
    {
        Color tmp;
        switch (transform.name)
        {
            case "AttackButton":
            case "DefenseButton":
            case "HealthButton":
            case "WealthButton":
                selected.SetActive(false);
                break;

            case "Back Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
            case "Next Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }

                break;
            case "Back Button 2":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1208f, -349f, 0f);
                break;

            case "Start Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
                }
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1208f, -349f, 0f);
                break;
        }
    }

    private void OnDisable()
    {
        if (transform.name.Equals("Back Button"))
        {
            Color tmp;

            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
            }
        }
    }
}
