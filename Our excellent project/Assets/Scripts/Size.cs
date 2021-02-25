using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    
    private void Update()
    {
        Debug.Log(transform.localScale.y); 
       
    }


    void OnCollisionEnter(Collision col)  //Unity function called when a collision is detected, and the object collided is put into the variable 'col' to be used later
    {
        if (col.gameObject.tag == "Big")   //if the object you collided with is the enemy
        {
            transform.localScale += new Vector3(1, 1, 1); //increase the size of the ball
            Destroy(col.gameObject);  //Destroy the enemy
        }
        if (col.gameObject.tag == "Small")   //if the object you collided with is the enemy
        {
            transform.localScale += new Vector3(-1, -1, -1); //increase the size of the ball
            Destroy(col.gameObject);  //Destroy the enemy
        }
        if (col.gameObject.tag == "Wall" && transform.localScale.y == 2)   
        {
           
            Destroy(col.gameObject);  //Destroy the enemy
        }
    }
   
}
