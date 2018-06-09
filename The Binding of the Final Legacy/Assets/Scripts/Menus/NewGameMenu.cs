using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameMenu : MonoBehaviour
{
    public int totalPoints = 6;
    private int pointsLeft;
    private int attackValue;
    private int defenseValue;
    private int healthValue;
    private int wealthValue;
    private GameObject attackSlices;
    private GameObject defenseSlices;
    private GameObject healthSlices;
    private GameObject wealthSlices;
    private GameObject alert;
    private TextMeshProUGUI inputName;
    private TextMeshProUGUI pointsLeftUI;
    private Color backUp;
    private GameDataManager gameDataManager;
    private GameObject[] attributeButtons;
    private MenuGlobalButton globalButton;
    private GameObject[] alertButtons;
    private bool horizontalAxisPressed;
    private EventSystem myEventSystem;

	// Use this for initialization
	void Start ()
    {
        pointsLeft = totalPoints;
        attackSlices = GameObject.FindGameObjectWithTag("AttackSlices");
        defenseSlices = GameObject.FindGameObjectWithTag("DefenseSlices");
        healthSlices = GameObject.FindGameObjectWithTag("HealthSlices");
        wealthSlices = GameObject.FindGameObjectWithTag("WealthSlices");
        alert = GameObject.FindGameObjectWithTag("NewGameAlert");
        inputName = GameObject.FindGameObjectWithTag("InputName").GetComponent<TextMeshProUGUI>();
        pointsLeftUI = GameObject.FindGameObjectWithTag("PointsLeft").GetComponent<TextMeshProUGUI>();
        gameDataManager = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataManager>();
        globalButton = GameObject.FindGameObjectWithTag("MenuGlobalButton").GetComponent<MenuGlobalButton>();
        pointsLeftUI.SetText(pointsLeft.ToString());
        backUp = pointsLeftUI.color;

        attributeButtons = GameObject.FindGameObjectsWithTag("NewGameButton");
        alertButtons = GameObject.FindGameObjectsWithTag("NewGameAlertButton");
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


        alert.SetActive(false);

        attackValue = 1;
        defenseValue = 1;
        healthValue = 1;
        wealthValue = 1;

        for (int i = 0; i < attackSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                attackSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < defenseSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                defenseSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < healthSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                healthSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < wealthSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                wealthSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        Invoke("firstSelected", 0.01f);
    }

    private void firstSelected()
    {
        pointsLeft = totalPoints;
        pointsLeftUI.SetText(pointsLeft.ToString());

        attackValue = 1;
        defenseValue = 1;
        healthValue = 1;
        wealthValue = 1;

        for (int i = 0; i < attackSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                attackSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < defenseSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                defenseSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < healthSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                healthSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < wealthSlices.transform.childCount; i++)
        {
            if (i > 0)
            {
                wealthSlices.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < attributeButtons.Length; i++)
        {
            if (attributeButtons[i].transform.name.Equals("AttackButton"))
            {
                attributeButtons[i].GetComponent<Button>().Select();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //if (String.IsNullOrEmpty(inputName.text.Substring(1))) //Cambiar esto a si contiene algun numero, letra, la primera no es espacio, etc... Ahora no tengo tiempo
        if (inputName.text.Length < 2) //La longitud es 1 cuando no hay nada por alguna extraña razón...
        {
            for (int i = 0; i < alertButtons.Length; i++)
            {
                if (alertButtons[i].transform.name.Equals("Start Button"))
                {
                    alertButtons[i].SetActive(false);
                }
                
            }
            for (int i = 0; i < alert.transform.childCount; i++)
            {
                if (alert.transform.GetChild(i).name.Equals("Start Background"))
                {
                    alert.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < alertButtons.Length; i++)
            {
                if (alertButtons[i].transform.name.Equals("Start Button"))
                {
                    alertButtons[i].SetActive(true);
                }

            }

            for (int i = 0; i < alert.transform.childCount; i++)
            {
                if (alert.transform.GetChild(i).name.Equals("Start Background"))
                {
                    alert.transform.GetChild(i).gameObject.SetActive(true);
                }
            }

        }

        checkSelected(); //Se queda un poco atascado a veces, no se como arreglarlo porque no hay nada más rápido que el update
	}

    private void checkSelected()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (!horizontalAxisPressed)
            {
                for (int i = 0; i < attributeButtons.Length; i++)
                {
                    if (attributeButtons[i].Equals(globalButton.currentButton))
                    {
                        switch (attributeButtons[i].transform.name)
                        {
                            case "AttackButton":
                                attackArrowButton("left");
                                break;
                            case "DefenseButton":
                                defenseArrowButton("left");
                                break;
                            case "HealthButton":
                                healthArrowButton("left");
                                break;
                            case "WealthButton":
                                wealthArrowButton("left");
                                break;
                        }
                    }
                }

                horizontalAxisPressed = true;
            }

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {

            if (!horizontalAxisPressed)
            {
                for (int i = 0; i < attributeButtons.Length; i++)
                {
                    if (attributeButtons[i].Equals(globalButton.currentButton))
                    {
                        switch (attributeButtons[i].transform.name)
                        {
                            case "AttackButton":
                                attackArrowButton("right");
                                break;
                            case "DefenseButton":
                                defenseArrowButton("right");
                                break;
                            case "HealthButton":
                                healthArrowButton("right");
                                break;
                            case "WealthButton":
                                wealthArrowButton("right");
                                break;
                        }
                    }
                }

                horizontalAxisPressed = true;
            }
        }
        else if (Input.GetButtonDown("Submit"))
        {
            for (int i = 0; i < alertButtons.Length; i++)
            {
                if (alertButtons[i].transform.name.Equals("InputName"))
                {
                    if (myEventSystem.currentSelectedGameObject.Equals(alertButtons[i]))
                    {
                        for (int j = 0; j < alertButtons.Length; j++)
                        {
                            if (alertButtons[j].transform.name.Equals("Back Button 2"))
                            {
                                alertButtons[j].GetComponent<Button>().Select();
                            }

                        }
                    }
                }
            }
        }
        else
        {
            horizontalAxisPressed = false;
        }
    }

    public void attackArrowButton(string direction)
    {
        switch (direction)
        {
            case "left":

                if (attackValue - 1 > 0 && pointsLeft <= totalPoints)
                {
                    attackValue--;
                    pointsLeft++;

                    for (int i = 0; i < attackSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(attackSlices.transform.GetChild(i).name.Substring(6)) > attackValue)
                        {
                            attackSlices.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }

            break;

            case "right":

                if (attackValue + 1 <= 10 && pointsLeft > 0)
                {
                    attackValue++;
                    pointsLeft--;

                    for (int i = 0; i < attackSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(attackSlices.transform.GetChild(i).name.Substring(6)) <= attackValue)
                        {
                            attackSlices.transform.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                }

                else
                {
                    StopCoroutine(notEnoughPoints());
                    StartCoroutine(notEnoughPoints());
                }

                break;
        }

        pointsLeftUI.SetText(pointsLeft.ToString());

        Debug.Log("Attack: " + attackValue + " + PointsLeft: " + pointsLeft);
    }

    public void defenseArrowButton(string direction)
    {
        switch (direction)
        {
            case "left":

                if (defenseValue - 1 > 0 && pointsLeft <= totalPoints)
                {
                    defenseValue--;
                    pointsLeft++;

                    for (int i = 0; i < defenseSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(defenseSlices.transform.GetChild(i).name.Substring(6)) > defenseValue)
                        {
                            defenseSlices.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }

                break;

            case "right":

                if (defenseValue + 1 <= 10 && pointsLeft > 0)
                {
                    defenseValue++;
                    pointsLeft--;

                    for (int i = 0; i < defenseSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(defenseSlices.transform.GetChild(i).name.Substring(6)) <= defenseValue)
                        {
                            defenseSlices.transform.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                }
                else
                {
                    StopCoroutine(notEnoughPoints());
                    StartCoroutine(notEnoughPoints());
                }

                break;
        }

        pointsLeftUI.SetText(pointsLeft.ToString());

        Debug.Log("Defense: " + defenseValue + " + PointsLeft: " + pointsLeft);
    }

    public void healthArrowButton(string direction)
    {
        switch (direction)
        {
            case "left":

                if (healthValue - 1 > 0 && pointsLeft <= totalPoints)
                {
                    healthValue--;
                    pointsLeft++;

                    for (int i = 0; i < healthSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(healthSlices.transform.GetChild(i).name.Substring(6)) > healthValue)
                        {
                            healthSlices.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }

                break;

            case "right":

                if (healthValue + 1 <= 10 && pointsLeft > 0)
                {
                    healthValue++;
                    pointsLeft--;

                    for (int i = 0; i < healthSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(healthSlices.transform.GetChild(i).name.Substring(6)) <= healthValue)
                        {
                            healthSlices.transform.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                }

                else
                {
                    StopCoroutine(notEnoughPoints());
                    StartCoroutine(notEnoughPoints());
                }

                break;
        }

        pointsLeftUI.SetText(pointsLeft.ToString());

        Debug.Log("Health: " + healthValue + " + PointsLeft: " + pointsLeft);
    }

    public void wealthArrowButton(string direction)
    {
        switch (direction)
        {
            case "left":

                if (wealthValue - 1 > 0 && pointsLeft <= totalPoints)
                {
                    wealthValue--;
                    pointsLeft++;

                    for (int i = 0; i < wealthSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(wealthSlices.transform.GetChild(i).name.Substring(6)) > wealthValue)
                        {
                            wealthSlices.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }

                break;

            case "right":

                if (wealthValue + 1 <= 10 && pointsLeft > 0)
                {
                    wealthValue++;
                    pointsLeft--;

                    for (int i = 0; i < wealthSlices.transform.childCount; i++)
                    {
                        if (Convert.ToInt32(wealthSlices.transform.GetChild(i).name.Substring(6)) <= wealthValue)
                        {
                            wealthSlices.transform.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                }
                else
                {
                    StopCoroutine(notEnoughPoints());
                    StartCoroutine(notEnoughPoints());
                }

                break;
        }

        pointsLeftUI.SetText(pointsLeft.ToString());

        Debug.Log("Wealth: " + wealthValue + " + PointsLeft: " + pointsLeft);
    }

    public void nextButton()
    {
        if (pointsLeft == 0)
        {
            alert.SetActive(true);
            inputName.SetText(""); //No consigo arreglar esto, he probado a entrar al selection caret pero no viene nada y la documentación de esto es prácticamente inexistente
            Debug.Log("Text: " + inputName.text);

            for (int i = 0; i < attributeButtons.Length; i++)
            {
                attributeButtons[i].GetComponent<Button>().interactable = false;
            }

            for (int i = 0; i < alertButtons.Length; i++)
            {
                if (alertButtons[i].transform.name.Equals("InputName"))
                {
                    alertButtons[i].GetComponent<TMP_InputField>().Select();
                    globalButton.currentButton = alertButtons[i];
                }
                
            }

        }
        else
        {
            StopCoroutine(notEnoughPoints());
            StartCoroutine(notEnoughPoints());
        }
    }

    public void backButton()
    {
        for (int i = 0; i < attributeButtons.Length; i++)
        {
            attributeButtons[i].GetComponent<Button>().interactable = true;

            if (attributeButtons[i].transform.name.Equals("AttackButton"))
            {
                attributeButtons[i].GetComponent<Button>().Select();
            }
        }
    }

    public void startButton()
    {
        var randomName = "Save " + UnityEngine.Random.Range(0, 99999999).ToString(); //Esto sin nombre es el mana
        gameDataManager.createdPlayer = new PlayerClass(inputName.text, healthValue * 50.0f, 100.0f, defenseValue * 1.2f, attackValue + 1.2f, wealthValue * 100.0f /*99999.0f*/, new List<Ability>(), new List<GenericItem>());//Aqui hay que multiplicar el valor del atributo por lo que sea
        gameDataManager.selectedSave = randomName;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator notEnoughPoints()
    {
        Color tmp = new Color();

        for (int i = 0; i < 4; i++)
        {
            tmp = new Color(255, 0, 0);
            pointsLeftUI.color = tmp;
            yield return new WaitForSeconds(0.1f);
            tmp = new Color(166, 14, 14);
            pointsLeftUI.color = tmp;
            yield return new WaitForSeconds(0.1f);
        }
        
        pointsLeftUI.color = backUp;
    }
}
