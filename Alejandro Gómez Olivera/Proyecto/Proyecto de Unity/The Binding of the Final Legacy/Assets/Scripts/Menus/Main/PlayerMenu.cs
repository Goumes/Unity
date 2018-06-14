using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{

    public float speed = 2;

    [SerializeField]
    private Vector2 deltaForce;

    private Animator animator;
    private Rigidbody2D myRigidbody;
    private Vector2 lastDirection;
    private BoxCollider2D boxCollider;
    private bool isMoving;
    public Sprite chestSprite;
    void Awake()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody.gravityScale = 0;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        StartCutScene();
    }

    // Update is called once per frame
    void Update()
    {
        SendAnimInfo();
    }

    /// <summary>
    /// First part of the background cutscene
    /// </summary>
    private void StartCutScene()
    {
        var horizontal = 0f;
        var vertical = -60f;

        isMoving = true;
        lastDirection = new Vector2(horizontal, vertical);
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);

    }

    /// <summary>
    /// Second part of the background cutscene
    /// </summary>
    private void SecondPartCutScene()
    {
        var horizontal = -60f;
        var vertical = 0f;

        isMoving = true;
        lastDirection = new Vector2(horizontal, vertical);
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);
    }

    /// <summary>
    /// Method that moves the player in the cutscene
    /// </summary>
    /// <param name="playerForce"></param>
    private void CalculateMovement(Vector2 playerForce)
    {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.AddForce(playerForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// This method sends the info to the animator component
    /// </summary>
    private void SendAnimInfo()
    {
        animator.SetFloat("XSpeed", myRigidbody.velocity.x);
        animator.SetFloat("YSpeed", myRigidbody.velocity.y);

        animator.SetFloat("LastX", lastDirection.x);
        animator.SetFloat("LastY", lastDirection.y);

        animator.SetBool("IsMoving", isMoving);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Trigger Cutscene 1"))
        {
            collision.transform.gameObject.SetActive(false);
            SecondPartCutScene();
        }
        else if (collision.name.Equals("Trigger Cutscene 2"))
        {
            collision.transform.gameObject.SetActive(false);
            FourthPartCutScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("MenuBlob"))
        {
            StartCoroutine(ThirdPartCutScene(collision));

        }
        else if (collision.transform.CompareTag("Chest"))
        {
            StartCoroutine(FifthPartCutScene (collision));
        }
    }

    /// <summary>
    /// Coroutine that animates the third part of the cutscene
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    private IEnumerator ThirdPartCutScene(Collision2D collision)
    {
        var horizontal = 0f;
        var vertical = 0f;
        Color backup = collision.transform.GetComponent<SpriteRenderer>().color;
        Color tmp = backup;

        isMoving = false;

        deltaForce = new Vector2(horizontal, vertical);
        CalculateMovement(deltaForce * speed);

        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < 3; i++)
        {
            tmp = new Color(1f, 0.392f, 0.392f);//255, 100, 100
            collision.transform.GetComponent<SpriteRenderer>().color = tmp;

            yield return new WaitForSeconds(0.1f);

            collision.transform.GetComponent<SpriteRenderer>().color = backup;

            yield return new WaitForSeconds(0.1f);
        }

        collision.transform.GetComponent<SpriteRenderer>().color = backup;
        tmp = backup;

        yield return new WaitForSeconds(0.3f);


        for (float i = 1f; i >= 0f; i = i - 0.025f)
        {
            tmp.a = i;
            collision.transform.GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(0.001f);
        }

        collision.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.3f);

        horizontal = 60f;
        vertical = 0f;
        isMoving = true;
        lastDirection = new Vector2(horizontal, vertical);
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);
    }

    /// <summary>
    /// Fourth part of the cutscene
    /// </summary>
    private void FourthPartCutScene()
    {
        var horizontal = 0f;
        var vertical = 60f;

        isMoving = true;
        lastDirection = new Vector2(horizontal, vertical);
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);
    }

    /// <summary>
    /// Coroutine that animates the fifth part of the cutscene
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    private IEnumerator FifthPartCutScene(Collision2D collision)
    {
        var horizontal = 0f;
        var vertical = 0f;

        isMoving = false;

        deltaForce = new Vector2(horizontal, vertical);
        CalculateMovement(deltaForce * speed);

        yield return new WaitForSeconds(0.3f);

        collision.transform.GetComponent<SpriteRenderer>().sprite = chestSprite;
        //collision.transform.position = new Vector2(collision.transform.position.x, 373.54f);

        yield return new WaitForSeconds(0.3f);

        horizontal = 60f;
        vertical = 0f;

        isMoving = true;
        lastDirection = new Vector2(horizontal, vertical);
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);

        yield return new WaitForSeconds(2f);

        horizontal = 0f;
        vertical = 0f;

        isMoving = false;
        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);
    }
}
