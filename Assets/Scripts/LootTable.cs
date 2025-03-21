using System;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/Loot Table")]
public class LootTable : ScriptableObject
{
    [Serializable]
    public class LootItem
    {
        public GameObject itemPrefab;

        [Range(0, 100)] public float dropChance; 
    }

    public LootItem[] lootItems;

    public GameObject GetDroppedItem()
    {
        float roll = UnityEngine.Random.Range(0f, 100f); 
        float cumulativeChance = 0f;

        foreach (var loot in lootItems)
        {
            cumulativeChance += loot.dropChance;
            if (roll <= cumulativeChance) 
            {
                return loot.itemPrefab;
            }
        }

        return null; 
    }

}
