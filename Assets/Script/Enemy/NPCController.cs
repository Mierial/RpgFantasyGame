using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.speed = moveSpeed;
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (waypoints.Length > 0)
        {
            Transform target = waypoints[currentWaypointIndex];
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("isWalking", true);

            while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > 0.1f)
            {
                yield return null;
            }

            animator.SetBool("isWalking", false);

            yield return new WaitForSeconds(10);

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
