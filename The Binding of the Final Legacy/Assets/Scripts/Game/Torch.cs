using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    private Light torchLight;
    private Transform torchTransform;
    private float lightInt = 0f;

    public float minInt = 3f, maxInt = 7f;
    public float minZ = 5.41f, maxZ = 6.21f;
    public float lightSpeed = 1f;

	// Use this for initialization
	void Start () {
        torchLight = GetComponent<Light>();
        torchTransform = GetComponent<Transform>();
	}

    private void OnEnable()
    {
        InvokeRepeating("changeLightning", 0f, lightSpeed);
    }

    private void OnDisable()
    {
        CancelInvoke("changeLightning");
    }
    /// <summary>
    /// Method that calls the changeLightRoutine coroutine.
    /// </summary>
    void changeLightning()
    {
        StartCoroutine("changeLightRoutine");
    }

    /// <summary>
    /// Coroutine that makes the light increase and decrease while blinking to create a torch effect
    /// </summary>
    /// <returns></returns>
    IEnumerator changeLightRoutine ()
    {
        int counter = 0;
        DateTime before = DateTime.Now;

        for (float i = minZ; i > maxZ; i = i - 0.02f)
        {
            if (counter % 3 == 0)
            {
                lightInt = UnityEngine.Random.Range(minInt, maxInt);
                torchLight.intensity = lightInt;
            }
            torchTransform.SetPositionAndRotation(new Vector3(torchTransform.position.x, torchTransform.position.y, i), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            counter++;
        }

        counter = 0;

        for (float i = maxZ; i < minZ; i = i + 0.02f)
        {
            if (counter % 3 == 0)
            {
                lightInt = UnityEngine.Random.Range(minInt, maxInt);
                torchLight.intensity = lightInt;
            }

            torchTransform.SetPositionAndRotation(new Vector3(torchTransform.position.x, torchTransform.position.y, i), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }

        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        Debug.Log("Duration in milliseconds: " + duration.Milliseconds);
    }
}
