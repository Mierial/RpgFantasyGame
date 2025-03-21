using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMech : Weapon
{
   
        [Header("Arrow Settings")]
        public GameObject arrowPrefab; // Префаб стріли
        public Transform arrowSpawnPoint; // Точка появи стріли
        public float shootForce;
       

        private float currentDrawTime = 0f; // Час, витрачений на натяг
        private bool isDrawing = false; // Чи натягується лук

   

    void Update()
        {
            // Початок натягу лука
            if (Input.GetMouseButtonDown(0)) // Ліва кнопка миші
            {
                StartDrawing();
            }

            // Підтримка натягу
            if (Input.GetMouseButton(0) && isDrawing)
            {
                currentDrawTime += Time.deltaTime;
                currentDrawTime = Mathf.Clamp(currentDrawTime, 0f, maxDrawTime);
            }

            // Випуск стріли
            if (Input.GetMouseButtonUp(0) && isDrawing)
            {
                ReleaseArrow();
            }
        }

        // Почати натяг
        private void StartDrawing()
        {
            isDrawing = true;
            currentDrawTime = 0f;
        }

        // Випустити стрілу
        private void ReleaseArrow()
        {
            isDrawing = false;

            // Розрахунок сили стрільби залежно від часу натягу
            float finalForce = (currentDrawTime / maxDrawTime) * shootForce;

            // Створення стріли
            GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        arrow.transform.SetParent(transform);

        // Додавання сили стрілі
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(arrowSpawnPoint.forward * finalForce, ForceMode.Impulse);
            }

            // Скидання часу натягу
            currentDrawTime = 0f;
        Debug.Log("Bow");
        }

    public int GetBowDamage()
    {
        return damage;
    }
    }

