using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avanzar : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    Animation animation;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        animation = GetComponent<Animation>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            GetComponent<Animator>().SetTrigger("Andar");
            animation.Play("Walk_Front");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        }
    }
}
