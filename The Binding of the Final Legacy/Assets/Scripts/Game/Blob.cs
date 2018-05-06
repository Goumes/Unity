using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Blob : MonoBehaviour {

    private SpriteRenderer spriteJugador;
    private SpriteRenderer spriteBlob;
    private GameObject jugador;
	// Use this for initialization
	void Start () {
        jugador = GameObject.Find("Character");
        spriteJugador = jugador.GetComponent<SpriteRenderer>();
        spriteBlob = GetComponent<SpriteRenderer>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (EditorUtility.DisplayDialog("Combat", "This is a combat", "Kill", "Show Mercy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
