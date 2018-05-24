using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemy : MonoBehaviour
{
    Color tmp;
    // Use this for initialization
    void Start ()
    {
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startBlinking()
    {
        InvokeRepeating("selectEnemy", 0f, 1.5f);
    }

    public void stopBlinking()
    {
        CancelInvoke();
        StopAllCoroutines();
        tmp.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }

    private void selectEnemy()
    {
        StartCoroutine("blink");
    }

    IEnumerator blink()
    {
        DateTime before = DateTime.Now;

        for (float i = 0f; i < 0.7f; i = i + 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        for (float i = 0.7f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        Debug.Log("Duration in milliseconds for the blinking: " + duration.Milliseconds);
    }
}
