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
        Invoke("DisableCombat", 0.2f);
        Invoke("DisableShop", 0.2f);
        Invoke("DisablePause", 0.2f);
    }

    private void DisableCombat()
    {
        combat.SetActive(false);
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

    public void EndShop()
    {
        StartCoroutine(fadeEndShop());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(fadeBackToMenu());
    }

    /// <summary>
    /// The screen fades in
    /// </summary>
    /// <returns></returns>
    public IEnumerator fadeIn()
    {
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
        audioManager.stopMusic();
        backgroundMusic = Resources.Load<AudioClip>("Music/Normal Dungeon Music");

        yield return new WaitForSeconds(0.3f);

        audioManager.startMusic();

        inCombat = false;

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
        if (dungeon.transform.childCount > 0 && !gameStarted)
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
