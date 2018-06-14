using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {
    RenderTexture renderA;
	// Use this for initialization
	void Start () {
        //renderA = new RenderTexture(512, 256, 24, RenderTextureFormat.ARGB32);
        //renderA.name = "RT_Test_1";
        //renderA.Create();
        //transform.GetComponent<Camera>().orthographicSize = transform.GetComponent<Camera>().orthographicSize * 12;
        //transform.GetComponent<Camera>().targetTexture = renderA;
        //transform.GetComponent<Camera>().aspect = 3 / 2;
        
        //transform.GetComponent<Camera>().activeTexture.width = transform.GetComponent<Camera>().activeTexture.width * 3;
        //transform.GetComponent<Camera>().activeTexture.height = transform.GetComponent<Camera>().activeTexture.height * 2;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
