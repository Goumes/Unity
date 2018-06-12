using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFollower : MonoBehaviour
{
    public GameObject bar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 namePos = Camera.current.WorldToScreenPoint(this.transform.position);
        bar.transform.position = namePos;

	}
}
