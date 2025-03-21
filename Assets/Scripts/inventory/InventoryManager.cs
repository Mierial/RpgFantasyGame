using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;
    public List<InventorySlot> inventorySlots;
    public Item heldItem;
    public Transform handTransform;

    public GameObject heldObject;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            return false;
        }

        items.Add(item);
        onItemChangedCallback?.Invoke();
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (heldItem == item)
        {
            DropItem(item);
            heldItem = null;
        }
    }

    public void SetHeldItem(Item item)
    {
        heldItem = item;
        HoldItem(item);
    }

    private void HoldItem(Item item)
    {
        if (heldObject != null)
        {
            Destroy(heldObject);
        }

        if (item.prefab != null && handTransform != null)
        {
            heldObject = Instantiate(item.prefab, handTransform.position, handTransform.rotation, handTransform);

            ItemPickUp itemPickUp = heldObject.GetComponent<ItemPickUp>();
            if (itemPickUp != null)
            {
                itemPickUp.enabled = false;
            }

            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            Collider[] colliders = heldObject.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.enabled = true;
                col.isTrigger = true;
            }
        }
    }

    public void DropItem(Item item)
    {
        if (item != null)
        {
            float dropDistance = 3f;
            float heightOffset = 2f;

            Vector3 dropPosition = handTransform.position + handTransform.forward * dropDistance + Vector3.up * heightOffset;
            GameObject droppedObject = Instantiate(item.prefab, dropPosition, Quaternion.identity);

            ItemPickUp itemPickUp = droppedObject.GetComponent<ItemPickUp>();
            if (itemPickUp != null)
            {
                itemPickUp.enabled = true;
            }

            Collider[] colliders = droppedObject.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.enabled = true;
                col.isTrigger = false;
            }

            Rigidbody rb = droppedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            if (heldObject != null)
            {
                Destroy(heldObject);
                heldItem = null;
            }
        }
    }
    public void SellItem(Item item)
    {
        items.Remove(item);

        if (heldItem == item)
        {
            Destroy(heldObject);
            heldItem = null;
        }
    }

    public InventorySlot FindSlotWithItem(Item item)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.ContainsItem(item))
            {
                return slot;
            }
        }
        return null;
    }
   
}
