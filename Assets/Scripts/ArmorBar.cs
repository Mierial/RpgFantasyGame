using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    public Slider slider;
    public void SetHealth(int armor)
    {
        slider.value = armor;
    }

}
