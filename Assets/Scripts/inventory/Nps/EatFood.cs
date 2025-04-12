using UnityEngine;

public class EatFood : MonoBehaviour
{
    public CharacterHealth1 characterHealth; 
    public void EatingFood()
    {
        if (InventoryManager.Instance.heldObject == null) return;

        Item _food = InventoryManager.Instance.heldItem;

        if (_food == null || _food.healCount <= 0 || characterHealth == null) return;

        else if(characterHealth.currentHealth < 100) 
        {
            InventorySlot slotToClear = InventoryManager.Instance.FindSlotWithItem(_food);
            characterHealth.Heal(_food.healCount);
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
