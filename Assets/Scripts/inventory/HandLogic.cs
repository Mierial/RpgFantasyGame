using UnityEngine;

public class HandItemManager : MonoBehaviour
{
    private GameObject currentItem;  // Ссылка на текущий предмет в руке

    public void EquipItem(GameObject itemPrefab)
    {
        // Если в руке уже есть предмет, деактивируем его
        if (currentItem != null)
        {
            currentItem.SetActive(false);  // Либо Destroy(currentItem) если ты хочешь его уничтожить
        }

        // Создаем новый предмет и помещаем его в руку
        currentItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);  // Помещаем в позицию руки
        currentItem.transform.SetParent(transform);  // Привязываем к руке, чтобы следовал за ней
    }

    public void ThrowItem()
    {
        if (currentItem != null)
        {
            // Выкидываем предмет
            currentItem.SetActive(false);  // Либо Destroy(currentItem)
            currentItem = null;  // Очистить ссылку на предмет
        }
    }
}
