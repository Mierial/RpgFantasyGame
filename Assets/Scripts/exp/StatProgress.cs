using System;
using UnityEngine;
using UnityEngine.UI;

public class StatProgress : MonoBehaviour
{
    public Slider slider; // Слайдер для отображения прогресса
    public int maxPoints = 0; // Максимальное количество очков
    private int currentPoints = 0; // Текущее количество очков
    [SerializeField] private GameObject expmech;

    public void Awake()
    {
        SetExp();
    }

    public void SetExp()
    {
        ExpMech exp = expmech.GetComponent<ExpMech>();
        SetFromExp(exp);
    }

    public void SetFromExp(ExpMech exp)
    {
        maxPoints = Mathf.RoundToInt(exp.needexp);
        currentPoints = Mathf.RoundToInt(exp.curtered_exp);
        slider.maxValue = maxPoints;
        UpdateSlider();
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        currentPoints = Mathf.Clamp(currentPoints, 0, maxPoints);
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = currentPoints;
    }
}
