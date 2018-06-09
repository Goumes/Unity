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
    private GameObject myEventSystem;
    public GameObject combat;
    public GameObject shop;
    Color tmp;
    private GameObject fader;
    public bool playingMusic;
    public AudioClip backgroundMusic;
    private AudioManager audioManager;
    private GameObject dungeon;
    private bool gameStarted;
    private GameDataManager gameDataManager;
    private GameObject pauseMenu;
    private GameObject gameOver;
    private GameObject player;

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
        Invoke("DisableCombat", 0.2f);
        Invoke("DisableShop", 0.2f);
        Invoke("DisablePause", 0.2f);
        Invoke("DisableGameOver", 0.001f);
    }

    private void DisableCombat()
    {
        combat.SetActive(false);
    }

    private void DisableGameOver()
    {
        gameOver.SetActive(false);
    }

    private void DisableShop()
    {
        shop.SetActive(false);
    }

    private void DisablePause()
    {
        pauseMenu.SetActive(false);
    }

    public void EndCombat()
    {
        StartCoroutine(fadeEndCombat());
    }

    public void WinCombat()
    {
        StartCoroutine(fadeWinCombat());
    }

    public void EndShop()
    {
        StartCoroutine(fadeEndShop());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(fadeBackToMenu());
    }

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

    public IEnumerator fadeGameOver()
    {
        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            fader.GetComponent<RawImage>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        gameOver.SetActive(true);

        tmp = gameOver.transform.GetChild(0).GetComponent<Text>().color;

        for (float i = 0f; i < 1f; i = i + 0.02f)
        {
            tmp.a = i;
            gameOver.transform.GetChild(0).GetComponent<Text>().color = tmp; //Hay que hacerlo así porque no es una variable y no se puede cambiar directamente
            yield return new WaitForSeconds(0.0001f);
        }

        gameDataManager.DeleteSave();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

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

    private void checkForStart()
    {
        if (!gameStarted && dungeon != null && dungeon.transform.childCount > 0)
        {
            gameStarted = true;
            backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");
            audioManager.startMusic();
        }
    }

    public void openPause()
    {
        inPause = true;
        pauseMenu.SetActive(true);
    }

    public void closePause()
    {
        inPause = false;
        pauseMenu.SetActive(false);
    }
}
