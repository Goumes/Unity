﻿using System.Collections;
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
    private Color tmp;
    public GlobalButton globalButton;
    public GameObject[] enemyModels;
    public bool isBoss;

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
        if (collision.CompareTag("Player") && !management.GetComponent<Management>().inCombat)
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

    /// <summary>
    /// Method that fades out and starts the combat
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Method that fades out and starts the boss combat
    /// </summary>
    /// <returns></returns>
    IEnumerator fadeOutBoss()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }


        management.GetComponent<Management>().combat.SetActive(true);
        enemyModels = GameObject.FindGameObjectsWithTag("EnemyCombat");
        globalButton = GameObject.FindGameObjectWithTag("Global Button").GetComponent<GlobalButton>();
        enemyModels[0].transform.GetChild(0).GetComponent<EnemyModel>().isBoss = true;
        globalButton.hasBoss = true;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !management.GetComponent<Management>().inCombat)
        {
            

            management.GetComponent<Management>().inCombat = true;

            if (isBoss)
            {
                StartCoroutine(fadeOutBoss());
            }
            else
            {
                StartCoroutine(fadeOut());
            }

            
        }
    }
}
