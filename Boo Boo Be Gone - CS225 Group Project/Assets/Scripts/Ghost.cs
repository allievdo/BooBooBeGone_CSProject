using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP = 100;

    public int attackPower;
    public float ghostSpeed = 2;

    public bool hasCollided = false;

    public Rigidbody2D rb;

    public PlayerMovement playerMovement;

    //SpriteRenderer spriteRenderer;

    public void Update()
    {
        GhostMovement();

        if (curHP == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Wall"))
        {
            hasCollided = true;
            Debug.Log("Collided");
        }

        if (collision.gameObject.tag == ("Wall2"))
        {
            hasCollided = false;
        }

        if (collision.gameObject.tag == ("Player"))
        {
            curHP -= 10;
            playerMovement.playerCurHP -= 5;
            Debug.Log("Hit");
        }

        //else
        //{
        //    hasCollided = false;
        //}
    }
    private void GhostMovement()
    {
        rb.velocity = new Vector2(ghostSpeed, 0f);

        if (hasCollided == true)
        {
            rb.velocity = new Vector2(-ghostSpeed, 0f);
        }
    }
}
