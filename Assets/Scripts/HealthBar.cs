using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    private void Awake()
    {
       // slider.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
