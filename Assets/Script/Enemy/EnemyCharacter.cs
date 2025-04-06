using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private EnemyInfo EnemiInfo;
    private int health;
    private int damage;
    private int defense;
    private int maxHealth;
    EnemyDropLoot dropLoot;
    public ParticleSystem deathparticle;
   

    public Animator animator; 

    private void Awake()
    {
        health = EnemiInfo.health;
        damage = EnemiInfo.damage;
        defense = EnemiInfo.Defence;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        dropLoot = GetComponent<EnemyDropLoot>();
    }

    public void ClaimDamage(int damage)
    {
        deathparticle.Play();
        int actualDamage = Mathf.Max(damage - defense, 0);
        health -= actualDamage;
        if (health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
            dropLoot.DropLoot();
        }
    }
}
