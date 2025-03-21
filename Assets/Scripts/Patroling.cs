using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private float waitTime = 2f;
    private bool isPatrolling = true;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (waypoints.Count > 0)
        {
            MoveToNextPoint();
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting && isPatrolling)
        {
            StartCoroutine(WaitBeforeNextMove());
        }

        // Обновление анимации патрулирования
        animator.SetBool("isPatrolling", isPatrolling && agent.velocity.magnitude > 0.1f);
    }

    private IEnumerator WaitBeforeNextMove()
    {
        isWaiting = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        agent.isStopped = false;
        MoveToNextPoint();
        isWaiting = false;
    }

    public void MoveToNextPoint()
    {
        if (waypoints.Count == 0) return;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    public void StartPatrol()
    {
        if (!isPatrolling)
        {
            isPatrolling = true;
            MoveToNextPoint();  // Начать с первой точки
        }
    }

    public void StopPatrol()
    {
        isPatrolling = false;
        agent.isStopped = true;
        animator.SetBool("isPatrolling", false);
    }

    public bool IsPatrolling()
    {
        return isPatrolling;
    }
}
