using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    [SerializeField] private UnityEvent OnAction;

    [SerializeField] private GameObject _cube;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnAction?.Invoke();

            int county = OnAction.GetPersistentEventCount();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnAction.AddListener(NewAction);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnAction.RemoveListener(NewAction);
        }

    }
        private void NewAction() 
    {
        Debug.Log("Hello");
    }
}
