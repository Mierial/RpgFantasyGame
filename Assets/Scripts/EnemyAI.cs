using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform _target;
    private NavMeshAgent _agent;
    [SerializeField] private float _lookRadius = 10f;
    [SerializeField] private float _chaseSpeed = 2.6f;
    [SerializeField] private float _patrolSpeed = 1.5f;
    private Patroling _patrolingScript;
    private Animator _animator;
    private float timeSinceLastSeen = 6f;
    private float _chaseMemoryDuration = 3f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _patrolingScript = GetComponent<Patroling>();

        if (PlayerManager.instance != null && PlayerManager.instance.player != null)
        {
            _target = PlayerManager.instance.player.transform;
        }

        _agent.speed = _patrolSpeed; 
    }

    void Update()
    {
        if (_target == null) return;

        float distanceToPlayer = Vector3.Distance(_target.position, transform.position);

        if (distanceToPlayer <= _lookRadius)
        {
            timeSinceLastSeen = 0f;
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            timeSinceLastSeen += Time.deltaTime;

            if (timeSinceLastSeen <= _chaseMemoryDuration)
            {
                ChasePlayer(distanceToPlayer);
            }
            else
            {
                Patrol();
            }
        }

        _animator.SetBool("isDetect", distanceToPlayer <= _lookRadius);  

    }

    void ChasePlayer(float distanceToPlayer)
    {
        _animator.SetBool("isPatrolling", false);
        _animator.SetBool("isDetect", true);

        _agent.speed = _chaseSpeed;
        _agent.SetDestination(_target.position);


        if (distanceToPlayer <= _agent.stoppingDistance + 0.5f)
        {
            _animator.SetBool("isFight", true);
            _animator.SetBool("isDetect", false);  
        }
        else
        {
            _animator.SetBool("isFight", false);  
        }
    }

    void Patrol()
    {
        if (_patrolingScript != null && !_patrolingScript.IsPatrolling())
        {
            _animator.SetBool("isPatrolling", true);
            _animator.SetBool("isDetect", false);
            _animator.SetBool("isFight", false);

            _agent.speed = _patrolSpeed;

            _patrolingScript.StartPatrol();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }

    public void Die()
    {
        _agent.speed = 0;
        Destroy(gameObject);
    }
}
