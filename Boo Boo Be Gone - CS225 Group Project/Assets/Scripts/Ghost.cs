using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP = 100;

    public int attackPower;

    public PlayerMovement playerMovement;

    //SpriteRenderer spriteRenderer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            curHP -= 10;
            playerMovement.playerCurHP -= 5;
            Debug.Log("Hit");
        }
    }
    public void Update()
    {
        if (curHP == 0)
        {
            Destroy(gameObject);
        }
    }
}
