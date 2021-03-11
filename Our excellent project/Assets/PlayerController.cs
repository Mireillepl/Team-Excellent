using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            transform.Translate(new Vector3(horizontalMove, 0, 0) * 0.25f);
        }

        float verticalMove = Input.GetAxisRaw("Vertical");
        if (verticalMove != 0)
        {
            transform.Translate(new Vector3(0, 0, verticalMove) * 0.25f);
        }

        float mouseMovementX = Input.GetAxis("Mouse X");
        float mouseMovementY = Input.GetAxis("Mouse Y");

        if (mouseMovementX != 0 || mouseMovementY != 0)
        {
            transform.Rotate(new Vector3(-mouseMovementY, mouseMovementX, 0));
        }
    }
}
