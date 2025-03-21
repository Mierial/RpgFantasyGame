using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform InteractionTransform;

    Transform Player;
    private bool hasInteracted = false;

    private void Start()
    {
        if (InteractionTransform == null)
            InteractionTransform = transform;

        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(Player.position, InteractionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (InteractionTransform == null)
            InteractionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
}
