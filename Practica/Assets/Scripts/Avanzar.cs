using System.Collections;
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
    }

    /// <summary>
    /// Esta es la funcion donde leemos los input del jugador.
    /// </summary>
    private void CheckInput()
    {
        isMoving = false;

        var horizontal = Input.GetAxisRaw("Horizontal"); //Para que no sea un movimiento suave, sino absolutos de unos y ceros
        var vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0 || horizontal > 0 || vertical < 0 || vertical > 0)
        {
            isMoving = true;

            if (!boxCollider.IsTouchingLayers(Physics2D.AllLayers)) //Si no esta tocando alguna capa
            {
                lastDirection = rigidbody.velocity;
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
