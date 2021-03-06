﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapUI : MonoBehaviour
{
    private Color tmp;
    private float i;
	// Use this for initialization
	void Start () {
        tmp = transform.GetComponent<RawImage>().color;
        i = tmp.a;
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkInput();
	}

    /// <summary>
    /// Checks the user input to see if it press tab
    /// </summary>
    void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StopAllCoroutines();
            StartCoroutine(increaseAlpha());
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            StopAllCoroutines();
            StartCoroutine(decreaseAlpha());
        }
    }

    /// <summary>
    /// Makes the minimap more visible
    /// </summary>
    /// <returns></returns>
    IEnumerator increaseAlpha()
    {
        for (float j = i; j <= 1f; j = j + 0.02f)
        {
            tmp.a = i;
            transform.GetComponent<RawImage>().color = tmp;
            i = j;
            yield return new WaitForSeconds (0.00001f);
        }
    }

    /// <summary>
    /// Makes the minimap less visible
    /// </summary>
    /// <returns></returns>
    IEnumerator decreaseAlpha()
    {
        for (float j = i; j >= 0.14f; j = j - 0.02f)
        {
            tmp.a = i;
            transform.GetComponent<RawImage>().color = tmp;
            i = j;
            yield return new WaitForSeconds(0.00001f);
        }
    }
}
