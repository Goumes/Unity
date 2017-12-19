﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avanzar : MonoBehaviour {

    public float speed = 2;

    [SerializeField]
    private Vector2 deltaForce;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private Vector2 lastDirection;
    private BoxCollider2D boxCollider;
    private GameObject player;
    private bool isMoving;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start ()
    {
        rigidbody.gravityScale = 0;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame

    void Update()
    {
        CheckInput();

        SendAnimInfo();

        //MIRAR ESTO, IMPORTANTE PARA QUE EL PERSONAJE CAMBIE DE LAYER DINÁMICAMENTE

        /* 
        if (player.isAbove == false)
        {
            AddSortingOrder = bridge.sortingOrder;
            player.sortingOrder = AddSortingOrder + player.sortingOrder;
            player.isAbove = false;
        }
        else
        {
            AddSortingOrder = 0;
            player.isAbove = true;
        }
        */
    }

    /// <summary>
    /// Esta es la funcion donde leemos los input del jugador.
    /// </summary>
    private void CheckInput()
    {
        isMoving = false;

        var horizontal = Input.GetAxisRaw("Horizontal"); //Raw es para que no sea un movimiento suave, sino absolutos de unos y ceros. Así no se desliza si tiene mucha velocidad.
        var vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0 || horizontal > 0 || vertical < 0 || vertical > 0)
        {
            isMoving = true;

            if (!boxCollider.IsTouchingLayers(Physics2D.AllLayers)) //Si no esta tocando alguna capa
            {
                lastDirection = rigidbody.velocity; //Esto se hace así porque el motor de físicas de Unity, pone a 0 la velocidad cuando se encuentra con un objeto, entonces no me vale para el last position.
            }

            if (horizontal != 0 && vertical != 0)
            {
                if (horizontal > 0 && vertical > 0)
                {
                    horizontal = 0.7f;
                    vertical = 0.7f;
                }

                else if (horizontal > 0 && vertical < 0)
                {
                    horizontal = 0.7f;
                    vertical = -0.7f;
                }

                else if (horizontal < 0 && vertical < 0)
                {
                    horizontal = -0.7f;
                    vertical = -0.7f;
                }

                else
                {
                    horizontal = -0.7f;
                    vertical = 0.7f;
                }

            }
            
            //Debug.Log("isMoving = "+isMoving);
        }

        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);

    }

    /// <summary>
    /// Esta es la funciona donde añadimos fuerza al jugador.
    /// </summary>
    /// <param name="playerForce"></param>
    private void CalculateMovement(Vector2 playerForce)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(playerForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Esta es la funcion donde enviaremos la informacion al animator
    /// </summary>
    private void SendAnimInfo()
    {
        animator.SetFloat("XSpeed", rigidbody.velocity.x);
        animator.SetFloat("YSpeed", rigidbody.velocity.y);

        animator.SetFloat("LastX", lastDirection.x);
        animator.SetFloat("LastY", lastDirection.y);

        animator.SetBool("IsMoving", isMoving);
    }
}
