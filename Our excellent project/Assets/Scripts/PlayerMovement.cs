using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;    
    bool moving = false;
    Vector3 destination;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                moving = true;
                destination = hit.point;
            }
        }
        if (moving) {
            if (transform.position == destination) {
                moving = false;
            } else {
                rb.AddForce((destination - transform.position) * 0.5f);
            }
        }
    }
}
