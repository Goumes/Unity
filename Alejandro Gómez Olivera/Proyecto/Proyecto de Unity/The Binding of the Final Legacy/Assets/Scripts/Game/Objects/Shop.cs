using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Color tmp;
    private GameObject fader;
    private GameObject management;

    // Use this for initialization
    void Start () {
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<RawImage>().color;
        management = GameObject.FindGameObjectWithTag("Management");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator fadeOut()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        management.GetComponent<Management>().shop.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            management.GetComponent<Management>().inShop = true;
            StartCoroutine(fadeOut());
        }
    }
}
