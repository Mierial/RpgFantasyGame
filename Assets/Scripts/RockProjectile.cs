using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public float lifeTime = 5f;
    public GameObject explodeEffect;

    private CharacterHealth1 enemyAttack;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
            enemyAttack = player.GetComponent<CharacterHealth1>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            enemyAttack.TakeDamage(damage);
            Debug.Log(enemyAttack.currentHealth);
        }

        if (!collision.collider.CompareTag("Boss"))
        {
            if (explodeEffect != null)
            {
                Instantiate(explodeEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject); 
        }
    }
}
