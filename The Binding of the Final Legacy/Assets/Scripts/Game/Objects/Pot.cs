using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    private SpriteRenderer sprite;
    private SpriteRenderer spriteJugador;
    private GameObject jugador;

    // Use this for initialization
    void Start () {
        jugador = GameObject.Find("Character");
        sprite = GetComponent<SpriteRenderer>();
        spriteJugador = jugador.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteJugador.sortingOrder = 2;
        sprite.sortingOrder = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteJugador.sortingOrder = 1;
        sprite.sortingOrder = 2;
    }   
}
