using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class bossPatrol : MonoBehaviour
{
    [Header("Гравець і Навігація")]
    [SerializeField] private Transform player;
    private NavMeshAgent agent;

    [Header("Атака")]
    [SerializeField] private float attackRange = 6f;
    [SerializeField] private float attackCooldown = 3f;
    private float lastAttackTime;

    [Header("Атака камінням")]
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private Transform rockSpawnPoint;

    [Header("Анімації")]
    public Animator animator;

    public CharacterHealth1 charaact;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        if (charaact.currentHealth<=0)
            animator.SetTrigger("Win");
        else
        {
            agent.isStopped = true;
            transform.LookAt(player);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                int randomAttack = Random.Range(0, 2);

                if (randomAttack == 0)
                    animator.SetTrigger("Attack1");
                else
                    animator.SetTrigger("Attack2");

                lastAttackTime = Time.time;

        }
        }
    }

    public void SpawnRockStorm()
    {
        StartCoroutine(ThrowRockStorm());
    }

    IEnumerator ThrowRockStorm()
    {
        int rocksCount = 5;
        float spreadRadius = 4f;

        for (int i = 0; i < rocksCount; i++)
        {
            Vector3 offset = new Vector3(
                Random.Range(-spreadRadius, spreadRadius),
                0,
                Random.Range(-spreadRadius, spreadRadius)
            );

            Vector3 spawnPos = rockSpawnPoint.position;
            Vector3 targetPos = player.position + offset;
            Vector3 dir = (targetPos - spawnPos).normalized;

            GameObject rock = Instantiate(rockPrefab, spawnPos, Quaternion.identity);
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            RockProjectile proj = rock.GetComponent<RockProjectile>();

            rb.AddForce((dir + Vector3.up * 0.5f) * 15f, ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
