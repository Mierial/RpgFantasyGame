using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialoguetrigger : MonoBehaviour
{
    [SerializeField] private GameObject ObjectButtonn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectButtonn.SetActive(true);
        }
        else
        {
            ObjectButtonn.SetActive(true);  
        }
    }
}
