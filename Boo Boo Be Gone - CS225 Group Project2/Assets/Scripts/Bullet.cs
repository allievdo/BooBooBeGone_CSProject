using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Ghost ghost;
    public float damage = 5;
    private float deleteAfterTime = 1f;

    private void Start()
    {
        Destroy(this.gameObject, deleteAfterTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ghost")) //Damage player and ghost if hit
        {
            Damage(collision.gameObject);
        }
    }
    public virtual void Damage(GameObject g)
    {
        g.GetComponent<Ghost>().curHP -= 5;
    }
}