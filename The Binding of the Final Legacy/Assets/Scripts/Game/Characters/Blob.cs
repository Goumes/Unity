using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Blob : MonoBehaviour {

    private SpriteRenderer spriteJugador;
    private SpriteRenderer spriteBlob;
    private GameObject jugador;
    private GameObject fader;
    private GameObject management;
    Color tmp;

    // Use this for initialization
    void Start () {
        jugador = GameObject.Find("Character");
        spriteJugador = jugador.GetComponent<SpriteRenderer>();
        spriteBlob = GetComponent<SpriteRenderer>();
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<RawImage>().color;
        management = GameObject.FindGameObjectWithTag("Management");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteJugador.sortingOrder = 2;
            spriteBlob.sortingOrder = 1;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteJugador.sortingOrder = 1;
            spriteBlob.sortingOrder = 2;
        }

        //Cambiar el collider de las paredes, que las esquinas no estan en su respectivo objeto
    }

    IEnumerator fadeOut()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        management.GetComponent<Management>().combat.SetActive(true);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            management.GetComponent<Management>().inCombat = true;
            StartCoroutine(fadeOut());
        }
    }
}
