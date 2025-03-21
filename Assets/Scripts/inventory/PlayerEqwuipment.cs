using UnityEngine;

public class PlayerEqwuipment : MonoBehaviour
{
    public Transform handPosition; 
    private GameObject currentItem; 


    public void HoldItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            Destroy(currentItem); // Видаляємо старий предмет з руки
        }

        // Створюємо новий предмет і прикріплюємо до руки
        currentItem = Instantiate(itemPrefab, handPosition.position, handPosition.rotation);
        currentItem.transform.SetParent(handPosition);
    }


    public void DropItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SetParent(null);
            currentItem.AddComponent<Rigidbody>(); // Додаємо фізику для падіння
            currentItem = null;
        }
    }
}
