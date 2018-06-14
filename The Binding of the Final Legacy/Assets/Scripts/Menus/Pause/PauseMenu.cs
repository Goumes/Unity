using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject currentButton;
    private EventSystem myEventSystem;
    private List<GameObject> buttons;
    private GameObject alert;

	// Use this for initialization
	void Start ()
    {
        myEventSystem = EventSystem.current;
        alert = GameObject.FindGameObjectWithTag("PauseAlert");

        buttons = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).transform.name.Equals("Buttons"))
            {
                for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
                {
                    if (transform.GetChild(i).transform.GetChild(j).transform.CompareTag("PauseMenuButton"))
                    {
                        buttons.Add(transform.GetChild(i).transform.GetChild(j).gameObject);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }
    }

    private void OnEnable()
    {
        Invoke("enableMethod", 0.001f);
    }

    /// <summary>
    /// Method that selects the first button and disables the alert
    /// </summary>
    private void enableMethod()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].transform.name.Equals("Save Game Button"))
            {
                buttons[i].GetComponent<Button>().Select();
            }
        }

        alert.SetActive(false);
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].transform.name.Equals("Options Button"))
            {
                buttons[i].GetComponent<Button>().Select();
            }
        }
    }

    /// <summary>
    /// Method that blocks the player input
    /// </summary>
    public void blockButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    /// <summary>
    /// Method that unlocks the player input and selects the first button
    /// </summary>
    public void unblockButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].transform.name.Equals("Save Game Button"))
            {
                buttons[i].GetComponent<Button>().Select();
            }
        }
    }
}
