using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMech : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private ClassHerro charactik;
    private StatProgress progress;

    public double needexp = 5;
    public double curtered_exp;
    public int Lvl = 1;

    public void Awake()
    {
        charactik = player.GetComponent<ClassHerro>(); // ????????????? charactik
        LvlUp();
        progress = FindObjectOfType<StatProgress>();
    }

    public void LvlUp()
    {
        if (curtered_exp >= needexp)
        {
            curtered_exp -= needexp; 
            Lvl++;
            needexp += 5; 
            charactik.UpdateHaract(Lvl);
            progress.AddPoints(Convert.ToInt32(curtered_exp));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("exp"))
        {
            curtered_exp += 5;
            Destroy(other.gameObject); 
        }

        if (curtered_exp >= needexp)
        {
            LvlUp();
        }
    }
}