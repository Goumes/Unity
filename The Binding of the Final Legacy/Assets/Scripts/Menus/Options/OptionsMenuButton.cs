using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject selected;
    private GameObject pointer;
    private MenuGlobalButton globalButton;

    // Use this for initialization
    void Start ()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        globalButton = GameObject.FindGameObjectWithTag("MenuGlobalButton").GetComponent<MenuGlobalButton>();

        if (!transform.name.Equals("Back Button"))
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).CompareTag("OptionsSelected"))
                {
                    selected = transform.parent.GetChild(i).gameObject;
                }
            }

            selected.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        Invoke("firstEnable", 0.001f);
    }

    /// <summary>
    /// Method that resets the pointer
    /// </summary>
    private void firstEnable()
    {
        pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1500f, -31f, 0f);
    }
    public void OnSelect(BaseEventData eventData)
    {
        Color tmp;

        if (!transform.name.Equals("Back Button"))
        {
            selected.SetActive(true);
        }
        else
        {
            pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-124f, -369f, 0f);

            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                tmp.a = 1f;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
            }
        }

        globalButton.currentButton = gameObject;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Color tmp;
        if (!transform.name.Equals("Back Button"))
        {
            selected.SetActive(false);
        }
        else
        {
            pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1500f, -31f, 0f);

            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
            }
        }
    }

    private void OnDisable()
    {
        Color tmp;
        if (transform.name.Equals("Back Button"))
        {
            pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1500f, -31f, 0f);

            for (int i = 0; i < transform.childCount; i++)
            {
                tmp = transform.GetChild(i).GetComponent<TextMeshProUGUI>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = tmp;
            }
        }
    }
}
