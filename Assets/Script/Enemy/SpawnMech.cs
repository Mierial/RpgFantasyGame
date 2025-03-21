using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnMech : MonoBehaviour 
{
    [SerializeField] GameObject mob;
    private int nowmob;

    private void OnTriggerStay(Collider other)
    { 
        if (other == null)
        {
            InvokeRepeating(nameof(Spawn), 1, 1);
        }
    }
    public void Spawn()
    {
        Instantiate(mob, transform.position, transform.rotation);
    }


}
