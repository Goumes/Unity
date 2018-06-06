using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    private GameObject startButtonUI;

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
        startButtonUI = GameObject.FindGameObjectWithTag("NewGameStartButton");
        pointsLeftUI.SetText(pointsLeft.ToString());
        backUp = pointsLeftUI.color;

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

        //for (int i = 0; i < alert.transform.childCount; i++)
        //{
        //    if (alert.transform.GetChild(i).transform.CompareTag("InputName"))
        //    {
        //        var parent = alert.transform.GetChild(i).transform.GetChild(0);

        //        for (int j = 0; j < parent.transform.childCount; j++)
        //        {
        //            if (parent.transform.GetChild(j).name.Equals("Text"))
        //            {
        //                inputName = parent.transform.GetChild(j).transform.GetComponent<TextMeshProUGUI>();
        //            }
        //        }
                

                
        //    }
        //}
    }

    private void OnEnable()
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
    }

    // Update is called once per frame
    void Update ()
    {
        //if (String.IsNullOrEmpty(inputName.text.Substring(1))) //Cambiar esto a si contiene algun numero, letra, la primera no es espacio, etc... Ahora no tengo tiempo
        if (inputName.text.Length < 2) //La longitud es 1 cuando no hay nada por alguna extraña razón...
        {
            startButtonUI.GetComponent<Button>().interactable = false;
            startButtonUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.529f, 0.529f, 0.529f);
        }
        else
        {
            startButtonUI.GetComponent<Button>().interactable = true;
            startButtonUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.259f, 0.302f, 0.733f);
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
        }
        else
        {
            StopCoroutine(notEnoughPoints());
            StartCoroutine(notEnoughPoints());
        }
    }

    public void startButton()
    {
        var randomName = "Save " + UnityEngine.Random.Range(0, 99999999).ToString();
        gameDataManager.createdPlayer = new PlayerClass(inputName.text.Substring(1), healthValue, defenseValue, attackValue, wealthValue, new List<GameObject>());//Aqui hay que multiplicar el valor del atributo por lo que sea
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
