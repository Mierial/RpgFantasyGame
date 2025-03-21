using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public EnemyInfo golemData;
    public Collider attackCollider;

    private void Start()
    {
        if (attackCollider == null)
        {
            return;
        }

        attackCollider.enabled = true;
        attackCollider.isTrigger = true; 
    }


    public void EnableAttackCollider()
    {
        ActivateTrigger();
    }

    private void ActivateTrigger()
    {
        attackCollider.enabled = true;
    }


    public void DisableAttackCollider() 
    {
        attackCollider.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CharacterHealth playerHealth = other.GetComponent<CharacterHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(golemData.damage);

            }
        }
    }
}
