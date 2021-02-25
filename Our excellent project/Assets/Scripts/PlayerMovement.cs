using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool moving = false;
    Vector3 destination;
    void Start()
    {
        
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
                Debug.Log(hit.point);
            }
        }
        if (moving) {
            if (transform.position == destination) {
                moving = false;
            } else {
                float step = 10f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);;
            }
        }
    }
}
