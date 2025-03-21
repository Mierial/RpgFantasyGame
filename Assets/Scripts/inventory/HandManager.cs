using UnityEngine;

public class HandManager : MonoBehaviour
{
    private GameObject currentItem;

    public void EquipItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        currentItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        currentItem.transform.SetParent(transform);
    }

    public void ThrowItem(Vector3 dropPosition)
    {
        if (currentItem != null)
        {
            Instantiate(currentItem, dropPosition, Quaternion.identity);
            Destroy(currentItem);
            currentItem = null;
        }
    }
}
