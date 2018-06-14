using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Management : MonoBehaviour {

    public bool inCombat;
    public bool inShop;
    public bool inTransition;
    public bool inPause;
    public bool inInventory;
    public bool playingMusic;
    public AudioClip backgroundMusic;
    public GameObject combat;
    public GameObject shop;

    private bool gameStarted;
    private AudioManager audioManager;
    private GameObject dungeon;
    private GameDataManager gameDataManager;
    private GameObject pauseMenu;
    private GameObject gameOver;
    private GameObject player;
    private GameObject inventoryMenu;
    private GameObject myEventSystem;
    private Color tmp;
    private GameObject fader;
    private GameObject nextLevel;

    // Use this for initialization
    void Start () {
        myEventSystem = GameObject.Find("EventSystem");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        combat = GameObject.FindGameObjectWithTag("Combat");
        shop = GameObject.FindGameObjectWithTag("Shop");
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<RawImage>().color;
        audioManager = transform.GetComponent<AudioManager>();
        dungeon = GameObject.FindGameObjectWithTag("Dungeon");
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        player = GameObject.FindGameObjectWithTag("Player");
        inventoryMenu = GameObject.FindGameObjectWithTag("Inventory");
        Invoke("DisableCombat", 0.2f);
        nextLevel = GameObject.FindGameObjectWithTag("NextLevel");
        Invoke("DisableShop", 0.2f);
        Invoke("DisablePause", 0.2f);
        Invoke("DisableInventory", 0.2f);
        Invoke("DisableGameOver", 0.001f);
        Invoke("DisableNextLevel", 0.001f);
    }

    /// <summary>
    /// Disables the combat UI
    /// </summary>
    private void DisableCombat()
    {
        combat.SetActive(false);
    }

    /// <summary>
    /// Disables the Game Over UI
    /// </summary>
    private void DisableGameOver()
    {
        gameOver.SetActive(false);
    }

    private void DisableNextLevel()
    {
        nextLevel.SetActive(false);
    }

    /// <summary>
    /// Disables the shop UI
    /// </summary>
    private void DisableShop()
    {
        shop.SetActive(false);
    }

    /// <summary>
    /// Disables the inventory UI
    /// </summary>
    private void DisableInventory()
    {
        inventoryMenu.SetActive(false);
    }

    /// <summary>
    /// Disables the pause UI
    /// </summary>
    private void DisablePause()
    {
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Ends the combat
    /// </summary>
    public void EndCombat()
    {
        StartCoroutine(fadeEndCombat());
    }

    /// <summary>
    /// Wins the combat
    /// </summary>
    public void WinCombat()
    {
        StartCoroutine(fadeWinCombat());
    }

    /// <summary>
    /// Wins the combat and goes to the next level
    /// </summary>
    public void WinCombatAndAdvanceLevel()
    {
        StartCoroutine(fadeWinCombatAndAdvanceNextLvl());
    }

    /// <summary>
    /// Ends the shop
    /// </summary>
    public void EndShop()
    {
        StartCoroutine(fadeEndShop());
    }

    /// <summary>
    /// Returns to the main menu
    /// </summary>
    public void BackToMainMenu()
    {
        StartCoroutine(fadeBackToMenu());
    }

    /// <summary>
    /// Ends the game
    /// </summary>
    public void GameOver()
    {
        StartCoroutine(fadeGameOver());
    }

    /// <summary>
    /// The screen fades in
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeIn()
    {
        inCombat = false;

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }
    }

    /// <summary>
    /// The screen fades out
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeOut()
    {

        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }
    }

    /// <summary>
    /// The screen fades out, disables the shop ui and transitions back to the game
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeEndShop()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        shop.SetActive(false);
        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();

        inShop = false;

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }

    }

    /// <summary>
    /// The screen fades in and enables the shop ui
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeStartShop()
    {

        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Fight Music");

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();
        inShop = true;

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }
    }

    /// <summary>
    /// The screen fades in and enables the combat ui
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeStartCombat()
    {

        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Fight Music");

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();
        inCombat = true;

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }
    }

    /// <summary>
    /// The screen fades out, disables the combat ui and transitions back to the game
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeEndCombat()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        combat.SetActive(false);
        inCombat = false;
        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }

    }

    /// <summary>
    /// The screen fades out, disables the combat ui and transitions back to the game. It also adds to the player every item, gold he has acquired in that combat and refills half its hp and mp
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeWinCombat()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        combat.SetActive(false);
        inCombat = false;
        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        if (player.GetComponent<Player>().playerStats.currentHealth + (player.GetComponent<Player>().playerStats.totalHealth / 2) <= player.GetComponent<Player>().playerStats.totalHealth)
        {
            player.GetComponent<Player>().playerStats.currentHealth = player.GetComponent<Player>().playerStats.currentHealth + (player.GetComponent<Player>().playerStats.totalHealth / 2);
        }
        else
        {
            player.GetComponent<Player>().playerStats.currentHealth = player.GetComponent<Player>().playerStats.totalHealth;
        }

        if (player.GetComponent<Player>().playerStats.currentMana + (player.GetComponent<Player>().playerStats.totalMana / 2) <= player.GetComponent<Player>().playerStats.totalMana)
        {
            player.GetComponent<Player>().playerStats.currentMana = player.GetComponent<Player>().playerStats.currentMana + (player.GetComponent<Player>().playerStats.totalMana / 2);
        }
        else
        {
            player.GetComponent<Player>().playerStats.currentMana = player.GetComponent<Player>().playerStats.totalMana;
        }

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp;
            yield return new WaitForSeconds(0.0001f);
        }

    }

    /// <summary>
    /// The screen fades out, disables the combat ui and transitions back to the game. It also adds to the player every item, gold he has acquired in that combat and refills half its hp and mp. Advances the lvl.
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeWinCombatAndAdvanceNextLvl()
    {
        Color tmp2 = new Color();

        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        combat.SetActive(false);
        inCombat = false;
        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        if (player.GetComponent<Player>().playerStats.currentHealth + (player.GetComponent<Player>().playerStats.totalHealth / 2) <= player.GetComponent<Player>().playerStats.totalHealth)
        {
            player.GetComponent<Player>().playerStats.currentHealth = player.GetComponent<Player>().playerStats.currentHealth + (player.GetComponent<Player>().playerStats.totalHealth / 2);
        }
        else
        {
            player.GetComponent<Player>().playerStats.currentHealth = player.GetComponent<Player>().playerStats.totalHealth;
        }

        if (player.GetComponent<Player>().playerStats.currentMana + (player.GetComponent<Player>().playerStats.totalMana / 2) <= player.GetComponent<Player>().playerStats.totalMana)
        {
            player.GetComponent<Player>().playerStats.currentMana = player.GetComponent<Player>().playerStats.currentMana + (player.GetComponent<Player>().playerStats.totalMana / 2);
        }
        else
        {
            player.GetComponent<Player>().playerStats.currentMana = player.GetComponent<Player>().playerStats.totalMana;
        }


        nextLevel.SetActive(true);

        tmp2 = nextLevel.transform.GetChild(0).GetComponent<Text>().color;


        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp2.a = i;
            nextLevel.transform.GetChild(0).GetComponent<Text>().color = tmp2; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }


        yield return new WaitForSeconds(2f);

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp2.a = i;
            nextLevel.transform.GetChild(0).GetComponent<Text>().color = tmp2; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        yield return new WaitForSeconds(0.5f);


        gameDataManager.hasSavedGame = false;
        gameDataManager.instantiated = false;
        gameDataManager.lvl++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    /// <summary>
    /// The screen fades out, goes back to the main menu
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeBackToMenu()
    {

        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// The screen fades out, deletes the savegame and goes back to the main menu
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeGameOver()
    {
        Color tmp2 = new Color();
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp = fader.GetComponent<RawImage>().color;
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        gameOver.SetActive(true);

        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        tmp2 = gameOver.transform.GetChild(0).GetComponent<Text>().color;

        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp2.a = i;
            gameOver.transform.GetChild(0).GetComponent<Text>().color = tmp2; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        gameDataManager.DeleteSave();

        yield return new WaitForSeconds(2f);

        for (float i = 1f; i >= 0f; i = i - 0.02f)
        {
            tmp2.a = i;
            gameOver.transform.GetChild(0).GetComponent<Text>().color = tmp2; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Method that generates a random boolean given a float
    /// </summary>
    /// <param name="chance"></param>
    /// <returns></returns>
    public bool randomBoolean(float? chance)
    {
        bool resultado = false;

        if (chance == 0f || chance == null)
        {
            chance = 0.5f;
        }

        if (Random.value >= chance)
        {
            resultado =  true;
        }
        return resultado;
    }

// Update is called once per frame
    void Update ()
    {
        Invoke("checkForStart", 0.1f);
    }

    /// <summary>
    /// Method that checks if the dungeon is done generating
    /// </summary>
    private void checkForStart()
    {
        if (!gameStarted && dungeon != null && dungeon.transform.childCount > 0)
        {
            gameStarted = true;
            backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");
            audioManager.startMusic();
        }
    }

    /// <summary>
    /// Method that opens the pause menu
    /// </summary>
    public void openPause()
    {
        inPause = true;
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// Method that closes the pause menu
    /// </summary>
    public void closePause()
    {
        inPause = false;
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Method that opens the inventory menu
    /// </summary>
    public void openInventory()
    {
        inInventory = true;
        inventoryMenu.SetActive(true);
    }

    /// <summary>
    /// Method that closes the inventory menu
    /// </summary>
    public void closeInventory()
    {
        inInventory = false;
        inventoryMenu.SetActive(false);
    }
}
