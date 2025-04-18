using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    public LootTable LootTable;

    public void DropLoot()
    {
        GameObject dropItem = LootTable.GetDroppedItem();
        if (dropItem != null)
        {
            Instantiate(dropItem, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}
