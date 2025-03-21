using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyInfo EnemiInfo;


    private void Awake()
    {
        health = EnemiInfo.health;
        damage = EnemiInfo.damage;
        defense = EnemiInfo.Defence;
    }
    

    
}
