using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    public Wallett wallett;
    [SerializeField] private Text infoText;
    [SerializeField] private InventoryManager inventoryManager;
    public Text valueText;
    private Item item_pref;

    public Image itemImage;

    private void OnTriggerEnter(Collider other)
    {
        UpdateItemInfo();
    }

    private void UpdateItemInfo()
    {
        item_pref = inventoryManager.heldItem;

        if (item_pref != null)
        {
            itemImage.sprite = item_pref.icon;
            itemImage.gameObject.SetActive(true);
            infoText.text = item_pref.ItemValue.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            infoText.text = "0";
        }
    }

    public void SellItem()
    {
        if (item_pref == null)
        {
            return;
        }

        InventorySlot slotToClear = inventoryManager.FindSlotWithItem(item_pref);

        if (slotToClear != null)
        {
            slotToClear.ClearSlot();
        }

        if (InventoryManager.Instance.heldItem != null)
        {
            wallett.AddCoins(item_pref.ItemValue);
            inventoryManager.SellItem(item_pref);
            inventoryManager.heldItem = null;
        }

        inventoryManager.onItemChangedCallback?.Invoke();
        UpdateItemInfo();
        wallett.UpdateText();
    }

}
