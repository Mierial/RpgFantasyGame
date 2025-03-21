using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private int _foodCountHealth;
    private Item _food;
    public HealthBar _healthBar;
    public void EatingFood()
    {
        if (InventoryManager.Instance.heldObject != null)
        {


            _food = InventoryManager.Instance.heldItem;
            if (_food != null && _food.healCount > 0 && _healthBar.slider.value!=100)
            {
                _healthBar.slider.value += _food.healCount;

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



    }
