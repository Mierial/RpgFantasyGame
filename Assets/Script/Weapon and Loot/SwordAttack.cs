using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public SwordParticle swordParticle;
    [SerializeField] private GameObject sword;
    public WeaponSettings swordInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();
            if (enemy != null)
            {
                enemy.ClaimDamage(swordInfo.Damage);
            }
        }
    }
}
