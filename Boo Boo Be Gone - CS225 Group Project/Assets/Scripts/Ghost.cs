using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : ITakeDamage
{ 
    public int attackPower;
    public float ghostSpeed = 2;

    public bool hasCollided = false;

    public Rigidbody2D rb;

    public PlayerMovement playerMovement;

    //TEST CONSTRUCTOR STUFF

    //SpriteRenderer spriteRenderer;

    public void Update()
    {
        GhostMovement();
    }

    void OnCollisionEnter2D(Collision2D collision) //If the character hits a certain wall, change diredction
    {
        if(collision.gameObject.tag == ("Wall")) //If Statements
        {
            hasCollided = true;
            Debug.Log("Collided");
        }

        if (collision.gameObject.tag == ("Wall2"))
        {
            hasCollided = false;
        }

        if (collision.gameObject.tag == ("Player")) //Damage player and ghost if hit
        {
            Damage(collision.gameObject);
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
    public override void Die() 
    {
        Destroy(gameObject);
    }

    public virtual void Damage(GameObject p)
    {
        curHP -= 10;
        p.GetComponent<PlayerMovement>().curHP -= 7;
        Debug.Log("Hit");
    }

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}

    //constructor
    //public Ghost(int constructorMaxHP, int constructorCurHP)
    //{
    //    maxHP = constructorMaxHP;
    //    curHP = constructorCurHP;
    //}
}
