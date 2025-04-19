using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BothItem : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    public Text buyText;
    public Image image;
    private int _buyPrice;
    public GameObject panel;
    public InventoryManager inventoryManager;

    public CharacterHealth1 characterHealth;

    private int curenntItem = 0;
    public Image[] images;

    private int currentArmor = 0;

    public Sell sellManager;
    private int _currentNumberSlot = 0;

    public Wallett wallett;
    public AudioSource audioSource;


    private void Start()
    {
        SetItems();
    }

    public void SetItems()
    {
        if (items.Count > 0)
        {
            image.sprite = items[0].icon;
            _buyPrice = items[0].ItemValue;
            buyText.text = _buyPrice.ToString();
        }
    }

    public void SwicthItem()
    {
        if (_currentNumberSlot == items.Count)
        {
            _currentNumberSlot = 0;
        }

        image.sprite = items[_currentNumberSlot].icon;
        _buyPrice = items[_currentNumberSlot].ItemValue;
        buyText.text = _buyPrice.ToString();
    }

    public void NextItem()
    {
        if (_currentNumberSlot == items.Count)
        {
            _currentNumberSlot = 0;
        }
        else
        {
            _currentNumberSlot++;
            SwicthItem();
        }
    }

    public void PreviousItem()
    {
        if (_currentNumberSlot != 0)
        {
            _currentNumberSlot--;
            SwicthItem();
        }
    }

    public void BuyItem()
    {
        if (wallett.TotalCoins >= _buyPrice)
        {

            if (items[_currentNumberSlot].armorCount == 0)
            {
                audioSource.Play();
                InventoryManager.Instance.Add(items[_currentNumberSlot]);
            }
            else
            {

                images[curenntItem].sprite = items[_currentNumberSlot].icon;
                curenntItem++;
                currentArmor += items[_currentNumberSlot].armorCount;
                characterHealth.AddArmor(items[_currentNumberSlot].armorCount);
            }

            wallett.SubtractCoins(_buyPrice);
            wallett.UpdateText();

            RemoveItemFromList(_currentNumberSlot);

            SwicthItem();
        }
    }


    private void RemoveItemFromList(int index)
    {
        if (items.Count > 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
