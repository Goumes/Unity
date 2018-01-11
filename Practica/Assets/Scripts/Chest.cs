using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    private SpriteRenderer sprite;
    private SpriteRenderer spriteJugador;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        spriteJugador = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteJugador.sortingOrder = 1;
        sprite.sortingOrder = 2;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteJugador.sortingOrder = 1;
        sprite.sortingOrder = 0;
    }
}
