using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KratosMovement : MonoBehaviour
{

    public KratosController controller;
    private float horizontalInput = 0f;
    public float runSpeed = 20f;
    private bool wantJump = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            wantJump = true;
        }


    }

    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, wantJump);
        wantJump = false;
    }
}
