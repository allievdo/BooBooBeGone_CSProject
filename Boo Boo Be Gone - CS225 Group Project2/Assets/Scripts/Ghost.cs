using UnityEngine;

public class Ghost : ITakeDamage
{
    public float ghostSpeed = 2;
    public bool isDead = false;

    public bool hasCollided = false;

    public Rigidbody2D rb;

    public PlayerMovement playerMovement;


    public void Update()
    {
        GhostMovement();
    }

    void OnCollisionEnter2D(Collision2D collision) //If the character hits a certain wall, change direction
    {
        if (collision.gameObject.tag == ("Wall")) //If Statements
        {
            hasCollided = true;
            transform.Rotate(0, 180, 0);
        }

        if (collision.gameObject.tag == ("Wall2"))
        {
            hasCollided = false;
            transform.Rotate(0, 180, 0);
        }

        if (collision.gameObject.tag == ("Player")) //Damage player and ghost if hit
        {
            Damage(collision.gameObject);
        }
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
        isDead = true;
        Destroy(gameObject);
    }

    public virtual void Damage(GameObject p)
    {
        curHP -= 10;
        p.GetComponent<PlayerMovement>().curHP -= 7;
    }
}
