using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    public bool onGround;
    void Update()
    {

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space) && onGround)
        {
            rb.velocity = rb.velocity + Vector2.up * 7;
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Platform"))
        {
            onGround = true;
        }
    }
}
