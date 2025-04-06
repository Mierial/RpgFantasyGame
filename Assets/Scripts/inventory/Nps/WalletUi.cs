using UnityEngine;
using UnityEngine.UI;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private Wallett wallet;
    [SerializeField] private Text coinText;

    private void Start()
    {
        UpdateText(); 
    }

    public void UpdateText()
    {
        coinText.text = wallet.TotalCoins.ToString();
    }
}
