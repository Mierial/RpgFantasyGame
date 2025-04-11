using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private UnityEvent onButton;
    [SerializeField] private Text dialogshow;
    public bool isPlayer;
    private void Update()
    {
        if(isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            onButton?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
            dialogshow.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
            dialogshow.gameObject.SetActive(true);
        }
    }
}
