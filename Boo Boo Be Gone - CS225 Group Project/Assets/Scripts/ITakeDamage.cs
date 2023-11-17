using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITakeDamage : MonoBehaviour
{
    public ITakeDamage(int maxHPCon = 100, int curHPCon = 100) //constructor
    {
        maxHP = maxHPCon;
        curHP = curHPCon;
    }
    public int maxHP;
    public int currentHP;
    public int curHP { get { return currentHP; }
        set { currentHP = value; if (currentHP <= 0) { Die(); } } }

    public virtual void Die()
    {
        //Do nothing
    }
}
