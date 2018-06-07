using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuGlobalButton : MonoBehaviour
{

    private EventSystem myEventSystem;
    public GameObject currentButton;

    // Use this for initialization
    void Start ()
    {
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myEventSystem.SetSelectedGameObject(currentButton);
        }
    }
}
