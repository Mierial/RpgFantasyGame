using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int damage;
    protected int defense;
    protected int health;
    protected int maxHealth = 10000;

    public int Damage
    {
        get { return damage; }
        set
        {
            if (value < 0) { damage = 0; }
            else { damage = value; }
        }
    }
           

    public int Health
    {
        get { return health; }
        set
        {
            Debug.Log($"Health setter called! Old value: {health}, New value: {value}");
            if (value < 0) { health = 0; }
            else if (value > maxHealth) { health = maxHealth; }
            else { health = value; }
        }
    }
    public void ClaimDamage(int damage1)
    {
        Debug.Log(damage1);
        Debug.Log($"{Health}");
        Debug.Log($"{Health -= damage1}");
        Health -= damage1;
        Debug.Log($"{Health}");
        if (Health == 0)
        {
            Death();
        }


    }

    public void GetHealth(int regen)
    {
        Health += regen;
    }
    private void Death()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }
}
