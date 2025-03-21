using UnityEngine;

public enum EquipmentSlot { Head, Chest, Legs, Feet, Weapon, Shield }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot; 
    public GameObject prefab; 
}
