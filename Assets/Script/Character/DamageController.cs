using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    ClassHerro reader; // Змінено на ClassHerro
    Weapon readerw;

    public int damage;

    private void Start()
    {
        

        if (reader == null || readerw == null)
        {
            Debug.LogError("Не вдалося знайти об'єкт ClassHerro або Weapon.");
        }
    }

    private void TakeDamage()
    {
        if (reader != null && readerw != null)
        {
            damage = (reader.Damage) / 2 + (readerw.Damage) / 2;
            Debug.Log("Розраховано damage: " + damage);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Виклик TakeDamage при натисканні пробілу
        {
            TakeDamage();
        }
    }
}
