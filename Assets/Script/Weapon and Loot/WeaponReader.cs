using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReader : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public int needLvl;
    public float damage;

    private void Awake()
    {
        damage = weapon.Damage;
        needLvl = weapon.needLvl;
    }
}
