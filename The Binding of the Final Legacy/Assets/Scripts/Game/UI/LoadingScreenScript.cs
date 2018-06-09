using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenScript : MonoBehaviour
{
    private Text text;
	// Use this for initialization
	void Start () {
        text = transform.GetChild(0).GetComponent<Text>();
        InvokeRepeating("animationStart", 0f,  0.8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDisable()
    {
        CancelInvoke("animationStart");
        StopAllCoroutines();
    }

    private void animationStart()
    {
        StartCoroutine(loadingAnimation());
    }

    private IEnumerator loadingAnimation()
    {
        text.text = "Loading";

        yield return new WaitForSeconds(0.2f);

        text.text = "Loading.";

        yield return new WaitForSeconds(0.2f);

        text.text = "Loading..";

        yield return new WaitForSeconds(0.2f);

        text.text = "Loading...";
    }
}
