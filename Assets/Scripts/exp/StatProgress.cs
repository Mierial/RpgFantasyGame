using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatProgress : MonoBehaviour
{
    public Slider slider; // ????????? ?? UI-???????
    public int maxPoints = 0; // ??????????? ????????? ????
    private int currentPoints = 0; // ??????? ????????? ????
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
        maxPoints= Convert.ToInt32(exp.needexp);
        currentPoints = Convert.ToInt32(exp.curtered_exp);
    }
    

    // ????? ??? ????????? ????
    public void AddPoints(int points)
    {
        currentPoints += points;
        currentPoints = Mathf.Clamp(currentPoints, 0, maxPoints); // ????????? ????????
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = currentPoints;
    }
}
