using System;
using UnityEngine;

public class ClassHerro : Character
{
    [SerializeField] private CharacterSettings ClassCharact;

    public float strenght;
    public float intelect;
    public float agility;

    private void Awake()
    {
        if (ClassCharact == null)
        {
            Debug.LogError("ClassCharact ?? ???? ?????????? ? ??????????!");
            return;
        }

        strenght = ClassCharact.Strength;
        intelect = ClassCharact.Intellect;
        agility = ClassCharact.agility;

        ModifyHealth();
    }

    public void UpdateHaract(int Lvl)
    {
        strenght = ClassCharact.Strength * Lvl;
        intelect = ClassCharact.Intellect * Lvl;
        agility = ClassCharact.agility * Lvl;

        ModifyHealth();
    }

    public void ModifyHealth()
    {
        health = Mathf.RoundToInt((strenght + agility + intelect) * 10);
    }
}