using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject pointer;
    private PauseMenu globalButton;
    private GameDataManager gameDataManager;
    private GameObject alert;
    private Management management;
    // Use this for initialization
    void Start ()
    {
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        alert = GameObject.FindGameObjectWithTag("PauseAlert");
        pointer = GameObject.FindGameObjectWithTag("PausePointer");
        globalButton = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        management = GameObject.FindGameObjectWithTag("Management").GetComponent<Management>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        Color tmp;
        switch (transform.name)
        {
            case "Save Game Button":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-305f, 26f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
            case "Options Button":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-305f, -108f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
            case "Return to menu Button":

                pointer.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-305f, -236f, 0f);

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 1f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
        }

        globalButton.currentButton = gameObject;

    }

    public void OnDeselect(BaseEventData eventData)
    {
        Color tmp;
        switch (transform.name)
        {
            case "Save Game Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
            case "Options Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;

            case "Return to menu Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
        }
    }

    private void OnDisable()
    {
        Color tmp;
        switch (transform.name)
        {
            case "Save Game Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
            case "Options Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;

            case "Return to menu Button":

                for (int i = 0; i < transform.childCount; i++)
                {
                    tmp = transform.GetChild(i).GetComponent<Text>().color;
                    tmp.a = 0.58f;
                    transform.GetChild(i).GetComponent<Text>().color = tmp;
                }

                break;
        }
    }

    public void OnClick()
    {
        switch (transform.name)
        {
            case "Save Game Button":

                bool success = gameDataManager.SaveGame();

                if (success)
                {
                    for (int i = 0; i < alert.transform.childCount; i++)
                    {
                        if (alert.transform.GetChild(i).transform.name.Equals("Text Canvas"))
                        {
                            for (int j = 0; j < alert.transform.GetChild(i).transform.childCount; j++)
                            {
                                if (alert.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Alert Text"))
                                {
                                    alert.transform.GetChild(i).transform.GetChild(j).transform.GetComponent<TextMeshProUGUI>().SetText("GAME SAVED !");
                                }
                            }
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < alert.transform.childCount; i++)
                    {
                        if (alert.transform.GetChild(i).transform.name.Equals("Text Canvas"))
                        {
                            for (int j = 0; j < alert.transform.GetChild(i).transform.childCount; j++)
                            {
                                if (alert.transform.GetChild(i).transform.GetChild(j).transform.name.Equals("Alert Text"))
                                {
                                    alert.transform.GetChild(i).transform.GetChild(j).transform.GetComponent<TextMeshProUGUI>().SetText("SAVING FAILED! Check if your antivirus is blocking the game.");
                                }
                            }
                        }
                    }
                }

                alert.SetActive(true);
                StartCoroutine(disableAlert());

                break;
            case "Options Button":
                //TODO
                break;

            case "Return to menu Button":
                management.BackToMainMenu();
                break;
        }
    }

    private IEnumerator disableAlert()
    {
        globalButton.blockButtons();

        yield return new WaitForSeconds(1f);

        alert.SetActive(false);

        globalButton.unblockButtons();
    }
}
