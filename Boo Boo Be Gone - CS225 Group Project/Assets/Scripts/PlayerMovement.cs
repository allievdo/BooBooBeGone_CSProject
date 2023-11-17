using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ITakeDamage
{
    public Rigidbody2D rb;
    public int speed = 5;
    public int jumpPower = 2;
    public bool isGrounded = true;

    private void Start()
    {
        
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) 
        //{
        //    transform.Translate(0, speed * Time.deltaTime, 0);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0, -speed * Time.deltaTime, 0);
        //}

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpPower);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
