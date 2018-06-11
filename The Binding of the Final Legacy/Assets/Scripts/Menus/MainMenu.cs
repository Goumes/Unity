using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        Invoke("SelectFirstButton", 0.01f);
        Invoke("UnSelectButtons", 0.01f);
    }


    private void SelectFirstButton()
    {
        var found = false;
        for (int i = 0; i < transform.childCount && !found; i++)
        {
            if (transform.GetChild(i).CompareTag("MainMenuButton"))
            {
                transform.GetChild(i).transform.GetComponent<Button>().Select();
                found = true;
            }
        }
    }

    private void UnSelectButtons()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("MainMenuButton") && !transform.GetChild(i).name.Equals("New Game Button"))
            {
                var tmp = transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().color;
                tmp.a = 0.58f;
                transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().color = tmp;
            }
        }
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void Update()
    {

    }

}
