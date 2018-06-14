using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    private SpriteRenderer sprite;
    private SpriteRenderer spriteJugador;
    private GameObject jugador;
    private Database database;
    private Management management;
    private GenericItem itemDrop;
    private int goldDrop;
    private Player player;
    public Sprite itemSprite;

    // Use this for initialization
    void Start () {
        jugador = GameObject.Find("Character");
        sprite = GetComponent<SpriteRenderer>();
        spriteJugador = jugador.GetComponent<SpriteRenderer>();
        database = GameObject.FindGameObjectWithTag("Item Pool").GetComponent<Database>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        if (itemDrop == null || itemDrop.Equals(new GenericItem()))
        {
            Invoke("loadItem", 0.02f);
        }
    }
    /// <summary>
    /// Method that loads a random item
    /// </summary>
    private void loadItem()
    {
        bool assigned = false;

        for (int i = 0; i < database.itemDatabase.itemList.Count && !assigned; i++)
        {
            if (management.randomBoolean(0.8f))
            {
                itemDrop = database.itemDatabase.itemList[i];
                assigned = true;
            }

            if (i == database.itemDatabase.itemList.Count - 1)
            {
                i = 0;
            }
        }

        goldDrop = Random.Range(1, 50);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(animateGiveItem());
        }
    }

    /// <summary>
    /// Method that gives the item to the player, changes the sprite of the chest and dissapears
    /// </summary>
    /// <returns></returns>
    private IEnumerator animateGiveItem()
    {
        management.inTransition = true;
        yield return new WaitForSeconds(1f);
        transform.GetComponent<SpriteRenderer>().sprite = itemSprite;
        player.playerStats.inventory.Add(new GenericItem (itemDrop));
        player.playerStats.gold = player.playerStats.gold + goldDrop;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        management.inTransition = false;
    }
}
