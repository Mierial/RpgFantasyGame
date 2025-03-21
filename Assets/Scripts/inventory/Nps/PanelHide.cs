using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHide : MonoBehaviour
{
    [SerializeField] private GameObject [] panel;
    private bool isOpen = false;

    private void Start()
    {
        panel[0].SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isOpen = !isOpen;
            panel[0].SetActive(isOpen);
        }
    }



}
