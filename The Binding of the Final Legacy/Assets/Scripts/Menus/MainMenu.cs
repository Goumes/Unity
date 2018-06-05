using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Loads the Game Scene
    /// </summary>
    public void NewGame()
    {
        GameSave newSave = new GameSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quits de application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
