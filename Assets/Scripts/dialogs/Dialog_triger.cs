using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogtriger : MonoBehaviour
{
    [SerializeField] public UnityEvent TrigerEnters;
    [SerializeField] public GameObject texting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            texting.gameObject.SetActive(true);
        
            if (Input.GetKeyDown(KeyCode.E))
            {
                TrigerEnters.Invoke();
                texting.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        texting.SetActive(false);
    }
}
