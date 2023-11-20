using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MinorGhost : Ghost
{
    //INHERITANCE

    //public MinorGhost(int consMaxHP, int consCurHP) : base(consMaxHP, consCurHP)
    //{
    //    //IDK
    //}

    void Start()
    {
        curHP = 50;
        maxHP = 50;
    }
    public override void Damage(GameObject p) //override
    {
        curHP -= 20;
        p.GetComponent<PlayerMovement>().curHP -= 5;
        //Debug.Log("Hit minus 20");
    }
}