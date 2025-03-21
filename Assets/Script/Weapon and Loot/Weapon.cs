using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSettings weapon;
    public int needLvl;
    protected int damage;
    protected float maxDrawTime;

    private void Awake()
    {
        damage = weapon.Damage;
        needLvl = weapon.NeedLvl;
        maxDrawTime = weapon.Attaktime;

    }
    public int Damage
    {
        get { return damage; }
        set
        {
            if (value < 0) { damage = 0; }
            else { damage = value; }
        }
    }

}
