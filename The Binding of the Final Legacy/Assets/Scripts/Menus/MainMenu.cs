using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {

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
