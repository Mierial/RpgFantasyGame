using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("PICKED Up" + item.name);
        bool wasPickedUp = InventoryManager.Instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

}