using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject pointer;
    private Color tmp;
    private MenuGlobalButton globalButton;

    // Use this for initialization
    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        globalButton = GameObject.FindGameObjectWithTag("MenuGlobalButton").GetComponent<MenuGlobalButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        switch (transform.name)
        {
            case "New Game Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-309f, 120f, 0f);
                break;

            case "Load Game Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-309f, -18f, 0f);
                break;

            case "Options Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-309f, -127f, 0f);
                break;

            case "Quit Button":
                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-309f, -243f, 0f);
                break;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            tmp = transform.GetChild(i).GetComponent<Text>().color;
            tmp.a = 1f;
            transform.GetChild(i).GetComponent<Text>().color = tmp;
        }

        globalButton.currentButton = gameObject;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            tmp = transform.GetChild(i).GetComponent<Text>().color;
            tmp.a = 0.58f;
            transform.GetChild(i).GetComponent<Text>().color = tmp;
        }
    }
}
