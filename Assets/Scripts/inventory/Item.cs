using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public GameObject prefab;
    public int ItemValue;
    public int armorCount;
    public int healCount;



    public virtual void Use()
    {

    }

    public void RemoveFromInventory()
    {
        InventoryManager.Instance.RemoveItem(this);
    }
}
