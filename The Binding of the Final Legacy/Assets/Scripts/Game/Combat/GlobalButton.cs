using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalButton : MonoBehaviour
{
    public bool subMenu1Active;
    public bool subMenu2Active;
    private Management management;
    private GameObject player;
    // Use this for initialization
    void Start () {
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void OnEnable()
    {
        management.inCombat = true;
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
