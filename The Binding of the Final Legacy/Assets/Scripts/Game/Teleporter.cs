﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject room;
    private GameObject player;
    private GameObject fader;
    Color tmp;
    // Use this for initialization
    void Awake ()
    {
        room = transform.root.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<SpriteRenderer>().color;
        //StartCoroutine(fadeOut());
        StartCoroutine(fadeIn());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Esto es simplemente de prueba para comprobar que todo funciona bien
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(fadeOut(collision));
        }
       
    }

    /// <summary>
    /// Method that destroys the current room and instantiates the new one, depending on the teleport the player goes in.
    /// </summary>
    /// <param name="collision"></param>
    void changeRoom(Collider2D collision)
    {
        Destroy(room.gameObject);
        switch (transform.name)
        {
            //Cambiar esto por las habitaciones de verdad. Esto es una prueba simplemente.
            case "Teleporter Top":
                player.transform.position = new Vector3(1.87f, -2.91f, 0);
                Instantiate(Resources.Load("Rooms/TB/Default Room TB"));
                break;

            case "Teleporter Right":
                Instantiate(Resources.Load("Rooms/BL/Default Room BL"));
                player.transform.position = new Vector3(-2.5f, 0.88f, 0);
                break;

            case "Teleporter Left":
                Instantiate(Resources.Load("Rooms/TLR/Default Room TLR"));
                player.transform.position = new Vector3(6.0f, 0.88f, 0);
                break;

            case "Teleporter Bottom":
                Instantiate(Resources.Load("Rooms/TR/Default Room TR"));
                player.transform.position = new Vector3(1.87f, 2.07f, 0);
                break;
        }
    }
    /// <summary>
    /// The screen fades out and calls the change room method
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    IEnumerator fadeOut(Collider2D collision)
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<SpriteRenderer>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        changeRoom(collision); //Si no lo hago de esta manera, el objeto se destruye a mitad de rutina y nunca se ejecuta.
    }

    /// <summary>
    /// The screen fades in with the new room
    /// </summary>
    /// <returns></returns>
    IEnumerator fadeIn()
    {
        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }
    }
}