using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 2;
    public PlayerClass playerStats;

    [SerializeField]
    private Vector2 deltaForce;

    private Animator animator;
    private Rigidbody2D myRigidbody;
    private Vector2 lastDirection;
    private BoxCollider2D boxCollider;
    private bool isMoving;
    private Management management;
    private GameDataManager gameDataManager;
    private Database database;

    void Awake()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start ()
    {
        myRigidbody.gravityScale = 0;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        database = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();

        if (gameDataManager.hasSavedGame)
        {
            playerStats = gameDataManager.LoadGame().player.playerDetails;
        }
        else
        {
            playerStats = gameDataManager.createdPlayer;
            playerStats.level = gameDataManager.lvl;
            //playerStats.attack = 100f;
            //playerStats.currentHealth = 100.0f;
            //playerStats.defense = 15.0f;

            //Cosas de testeo
            //playerStats.inventory.Add(new GenericItem(9, "ItemPrueba1", "weapon", "DescripcionPrueba1", 50.0f, 30.0f, 0, 5.0f, 4.5f, 100.0f, 0.0f, "Items/stunWhip"));
            //playerStats.inventory.Add(new GenericItem(1, "ItemPrueba2", "armor", "DescripcionPrueba2", 40.0f, 20.0f, 0, 6.0f, 7.5f, 200.0f, 0.0f, "Items/heavyKevlarArmor"));
            //playerStats.inventory.Add(new GenericItem(2, "ItemPrueba3", "potion", "DescripcionPrueba3", 30.0f, 15.0f, 0, 3.0f, 6.5f, 300.0f, 0.0f, "Items/potion"));
            //playerStats.inventory.Add(new GenericItem(2, "ItemPrueba3", "potion", "DescripcionPrueba3", 30.0f, 15.0f, 0, 3.0f, 6.5f, 300.0f, 50.0f, "Items/mana potion"));
            //playerStats.inventory.Add(new GenericItem(3, "ItemPrueba4", "weapon", "DescripcionPrueba4", 20.0f, 10.0f, 0, 2.0f, 4.5f, 50.0f, 0.0f, "Items/longSword"));
            //playerStats.inventory.Add(new GenericItem(4, "ItemPrueba5", "potion", "DescripcionPrueba5", 10.0f, 5.0f, 12, 1.0f, 3.5f, 2000.0f, 0.0f, "Items/potion"));
            //playerStats.inventory.Add(new GenericItem(5, "ItemPrueba6", "potion", "DescripcionPrueba6", 0.0f, 0.0f, 0, 0.0f, 0.0f, 300.0f, 0.0f, "Items/ration"));
            //playerStats.weapon = new GenericItem(6, "armaEquipadaPrueba1", "weapon", "DescripcionPrueba7", 0.0f, 0.0f, 0, 100.0f, 0.0f, 700.0f, 0.0f, "Items/assaultRifle");
            //playerStats.armor = new GenericItem(7, "armaduraEquipadaPrueba1", "armor", "DescripcionPrueba8", 0.0f, 0.0f, 0, 0.0f, 123.0f, 1200.0f, 0.0f, "Items/greatShield");

            //playerStats.currentHealth = 50.0f;
            //playerStats.currentMana = 70.0f;
        }
    }

    private void OnEnable()
    {
        Invoke("enableMethod", 0.01f);
    }

    /// <summary>
    /// Method that adds the basic abilities to the player if there is not saved game
    /// </summary>
    private void enableMethod()
    {
        if (!gameDataManager.hasSavedGame)
        {
            for (int i = 0; i < database.abilityDatabase.abilities.Count; i++)
            {
                if (i < 3)
                {
                    playerStats.abilities.Add(database.abilityDatabase.abilities[i]);
                }
            }
            
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (!management.inCombat && !management.inShop && !management.inTransition)
        {
            if (!management.inPause && !management.inInventory)
            {
                CheckInput();

                SendAnimInfo();
            }
           
            CheckForMenu();
            CheckForInventory();
        }

        else
        {
            CalculateMovement(Vector2.zero);
            isMoving = false;
            SendAnimInfo();
        }  
    }
    /// <summary>
    /// Method that checks if the cancel button is beign pressed to handle the pause menu
    /// </summary>
    private void CheckForMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!management.inPause && !management.inInventory)
            {
                CalculateMovement(Vector2.zero);
                isMoving = false;
                SendAnimInfo();

                management.openPause();

                //Debug.Log("Gold: " + playerStats.gold);
                //for (int i = 0; i < playerStats.inventory.Count; i++)
                //{
                //    Debug.Log("Item: " + playerStats.inventory[i].name);
                //}
            }

            else if (management.inPause)
            {
                management.closePause();
            }
        }
    }

    /// <summary>
    /// Method that checks if the Inventory button is pressed to handle the inventory menu
    /// </summary>
    private void CheckForInventory()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!management.inInventory && !management.inPause)
            {
                CalculateMovement(Vector2.zero);
                isMoving = false;
                SendAnimInfo();

                management.openInventory();
            }
        }
    }

    /// <summary>
    /// This method reads the user's input
    /// </summary>
    private void CheckInput()
    {
        isMoving = false;

        var horizontal = Input.GetAxisRaw("Horizontal") * 1.5f; //Raw es para que no sea un movimiento suave, sino absolutos de unos y ceros. Así no se desliza si tiene mucha velocidad.
        var vertical = Input.GetAxisRaw("Vertical") * 1.5f;

        if (horizontal < 0 || horizontal > 0 || vertical < 0 || vertical > 0)
        {
            isMoving = true;

            lastDirection = new Vector2(horizontal, vertical);
            if (horizontal != 0 && vertical != 0)
            {
                if (horizontal > 0 && vertical > 0)
                {
                    horizontal = 1.06f;
                    vertical = 1.06f;
                }

                else if (horizontal > 0 && vertical < 0)
                {
                    horizontal = 1.06f;
                    vertical = -1.06f;
                }

                else if (horizontal < 0 && vertical < 0)
                {
                    horizontal = -1.06f;
                    vertical = -1.06f;
                }

                else
                {
                    horizontal = -1.06f;
                    vertical = 1.06f;
                }

            }
        }

        deltaForce = new Vector2(horizontal, vertical);

        CalculateMovement(deltaForce * speed);

    }

    /// <summary>
    /// This method adds force to the player so he can move
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
}
