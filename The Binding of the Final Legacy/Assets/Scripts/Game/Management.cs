using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Management : MonoBehaviour {

    public bool inCombat;
    private GameObject myEventSystem;
    public GameObject combat;
    Color tmp;
    private GameObject fader;

    // Use this for initialization
    void Start () {
        inCombat = false;
        myEventSystem = GameObject.Find("EventSystem");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        combat = GameObject.FindGameObjectWithTag("Combat");
        fader = GameObject.FindGameObjectWithTag("Fade");
        tmp = fader.GetComponent<RawImage>().color;
        Invoke("DisableCombat", 0.2f);
    }

    private void DisableCombat()
    {
        combat.SetActive(false);
    }

    public void EndCombat()
    {
        StartCoroutine(fadeOut());
        combat.SetActive(false);
        StartCoroutine(fadeIn());
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

    // Update is called once per frame
    void Update () {
        //myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }
}
