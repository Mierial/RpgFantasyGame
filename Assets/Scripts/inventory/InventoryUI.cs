using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventoryManager inventoryManager;
    public GameObject InventoryUi;

    InventorySlot[] slots;

    void Start()
    {
        inventoryManager = InventoryManager.Instance;
        inventoryManager.onItemChangedCallback += UpdateUi;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isInventoryOpen = !InventoryUi.activeSelf;
            InventoryUi.SetActive(isInventoryOpen);
        }
    }



void UpdateUi()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryManager.items.Count)
            {
                slots[i].AddItem(inventoryManager.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
