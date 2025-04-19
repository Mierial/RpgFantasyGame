using UnityEngine;
using UnityEngine.UI;

public class Wallett : MonoBehaviour
{
    private int _totalCoins;

    public Text _valueText;
    public int TotalCoins => _totalCoins;
    private void Start()
    {
        _totalCoins = 500;
        UpdateText();
    }
    public void AddCoins(int amount)
    {
        _totalCoins += amount;
    }

    public bool SubtractCoins(int amount)
    {
        if (_totalCoins >= amount)
        {
            _totalCoins -= amount;
            return true;
        }
        return false;
    }

    public void SetCoins(int amount)
    {
        _totalCoins = amount;
    }

    public void UpdateText()
    { 
        _valueText.text = TotalCoins.ToString();
    }
}
