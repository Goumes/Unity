using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Management : MonoBehaviour {

    public bool inCombat;
    private GameObject myEventSystem;

    // Use this for initialization
    void Start () {
        inCombat = false;
        myEventSystem = GameObject.Find("EventSystem");
    }
	
	// Update is called once per frame
	void Update () {
        myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }
}
