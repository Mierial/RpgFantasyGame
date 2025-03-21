using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy Info")]
public class EnemyInfo : ScriptableObject
{
    [SerializeField]public int health;
    [SerializeField]public int damage;
    [SerializeField] public int defence;
    [SerializeField] public int maxHealth;


    public int Health => health;
    public int Damage => damage;
    public int Defence => defence;
    public int MaxHealth => maxHealth;
}

