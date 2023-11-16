using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ITakeDamage
{
    public Rigidbody2D rb;
    public int speed = 5;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
