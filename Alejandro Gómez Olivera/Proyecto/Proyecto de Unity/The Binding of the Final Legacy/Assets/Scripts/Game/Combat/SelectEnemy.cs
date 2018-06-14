using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemy : MonoBehaviour
{
    Color tmp;
    GlobalButton globalButton;
    // Use this for initialization
    void Start ()
    {
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
        globalButton = GameObject.FindGameObjectWithTag("Global Button").GetComponent<GlobalButton>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Starts blinking when selected
    /// </summary>
    public void startBlinking()
    {
        InvokeRepeating("selectEnemy", 0f, 1.5f);
    }

    /// <summary>
    /// Starts blinking when called
    /// </summary>
    public void startBlinkingWhite()
    {
        StartCoroutine(blinkWhite());
    }

    /// <summary>
    /// Stops blinking
    /// </summary>
    public void stopBlinking()
    {
        CancelInvoke("selectEnemy");
        StopCoroutine(globalButton.blinkCoroutine);
        tmp.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }

    /// <summary>
    /// Starts blinking
    /// </summary>
    private void selectEnemy()
    {
        globalButton.blinkCoroutine = StartCoroutine("blink");
    }

    /// <summary>
    /// Blinks red
    /// </summary>
    /// <returns></returns>
    private IEnumerator blink()
    {
        DateTime before = DateTime.Now;

        for (float i = 0f; i < 0.44f; i = i + 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        for (float i = 0.44f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        //Debug.Log("Duration in milliseconds for the blinking: " + duration.Milliseconds);
    }

    private IEnumerator blinkWhite()
    {
        DateTime before = DateTime.Now;

        tmp = Color.white;

        for (float i = 0f; i < 0.44f; i = i + 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        for (float i = 0.44f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        tmp = Color.red;

        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        //Debug.Log("Duration in milliseconds for the blinking: " + duration.Milliseconds);
    }
}
