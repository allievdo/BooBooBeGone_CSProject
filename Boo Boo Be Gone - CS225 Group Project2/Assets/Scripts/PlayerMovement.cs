using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : ITakeDamage
{
    public Rigidbody2D rb;
    public int speed = 5;
    public int jump = 7;
    public bool onGround;
    public Text healthText;
    public GameObject winText;

    void Update()
    {
        healthText.text = "Health: " + currentHP;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space) && onGround)
        {
            rb.velocity = rb.velocity + Vector2.up * jump;
            onGround = false;
        }
    }

    /*bool Grounded()
    {
        bool grounded = Physics.Raycast(this.transform.position,Vector2.down,1.7f);
        Debug.Log(grounded);
        return grounded;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Platform"))
        {
            onGround = true;
        }

        if (collision.gameObject.tag == ("Edge"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == ("Door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == ("FinalDoor"))
        {
            winText.SetActive(true);
        }
    }
}
