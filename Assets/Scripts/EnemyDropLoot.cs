using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    public LootTable LootTable;

    public void DropLoot()
    {
        Debug.Log("DropItem111");
        GameObject dropItem = LootTable.GetDroppedItem();
        if(dropItem != null)
        {
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }
    }
}
