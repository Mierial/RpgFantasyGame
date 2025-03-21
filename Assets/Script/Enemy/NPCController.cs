using UnityEngine;
using System.Collections;

// ”правление NPC
public class NPCController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (waypoints.Length > 0)
            {
                Transform target = waypoints[currentWaypointIndex];
                while (Vector3.Distance(transform.position, target.position) > 0.1f)
                {
                    Vector3 direction = (target.position - transform.position).normalized;
                    transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    transform.forward = direction; 
                    animator.SetBool("isWalking", true);
                    yield return null;
                }
                animator.SetBool("isWalking", false);
                yield return new WaitForSeconds(2f);
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            yield return null;
        }
    }
}