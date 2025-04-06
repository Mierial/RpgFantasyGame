using UnityEngine;

public class EatFood : MonoBehaviour
{
    public CharacterHealth characterHealth; 
    public void EatingFood()
    {
        if (InventoryManager.Instance.heldObject == null) return;

        Item _food = InventoryManager.Instance.heldItem;

        if (_food == null || _food.healCount <= 0 || characterHealth == null) return;

        if (characterHealth.Heal(_food.healCount))
        {
            InventorySlot slotToClear = InventoryManager.Instance.FindSlotWithItem(_food);

            InventoryManager.Instance.SellItem(_food);

            if (slotToClear != null)
            {
                slotToClear.ClearSlot();
            }

            Destroy(InventoryManager.Instance.heldObject);
            InventoryManager.Instance.heldItem = null;

            InventoryManager.Instance.onItemChangedCallback?.Invoke();
        }

    }
}
