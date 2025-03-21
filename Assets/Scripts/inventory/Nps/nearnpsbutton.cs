using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class nearnpsbutton : MonoBehaviour
{
    [SerializeField] public GameObject _button;
    public InventoryManager inventory;
    private void Awake( )
    {
        _button.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _button.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _button.gameObject.SetActive(false);
    }
}
