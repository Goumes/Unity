using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private GameObject[] elements;
    private EventSystem myEventSystem;
	// Use this for initialization
	void Start ()
    {
        elements = GameObject.FindGameObjectsWithTag("OptionsMenuElement");
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void OnEnable()
    {
        Invoke("firstEnable", 0.001f);
    }

    private void firstEnable()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].transform.name.Equals("Global Volume Slider"))
            {
                elements[i].GetComponent<Slider>().Select();
            }
        }
    }
}
