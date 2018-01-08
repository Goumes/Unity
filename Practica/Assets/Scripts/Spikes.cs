using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    private PolygonCollider2D collider;
    private SpriteRenderer sprite;
    private SpriteRenderer spriteJugador;
    private bool changed;

	// Use this for initialization
	void Start () {
        collider = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        spriteJugador = GetComponent<SpriteRenderer>();
        changed = false;
        collider.enabled = !collider.enabled;
	}
	
	// Update is called once per frame
	void Update () {

        if (sprite.sprite.name == "spikes 2" && !changed)
        {
            collider.enabled = !collider.enabled;
            changed = true;
        }

        else if (sprite.sprite.name == "spikes 1" && changed)
        {
            collider.enabled = !collider.enabled;
            changed = !changed;
        }

		
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

        //Cambiar el collider de las paredes, que las esquinas no estan en su respectivo objeto
    }
}
