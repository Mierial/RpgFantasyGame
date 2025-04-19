using System;
using UnityEngine;

public class ExpMech : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private ClassHerro charactik;
    public CharacterHealth1 Health1;
    private StatProgress progress;
    public HealthBar healthBar;

    public float needexp = 5;
    public float curtered_exp;
    public int Lvl = 1;

    public ParticleSystem particleSystem;
    public GameObject image;

    public void Awake()
    {
        charactik = player.GetComponent<ClassHerro>();
        progress = FindObjectOfType<StatProgress>();
        if (progress != null)
        {
            progress.SetFromExp(this);
        }
    }

    public void LvlUp()
    {
        while (curtered_exp >= needexp)
        {
            curtered_exp -= needexp;
            Lvl++;
            needexp += 5;
            charactik.UpdateHaract(Lvl);
            image.SetActive(true);
            particleSystem.Play();
        }

        if (progress != null)
        {
            progress.SetFromExp(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("exp"))
        {
            curtered_exp += 5;
            Destroy(other.gameObject);
            Health1.maxHealth += 20;
            healthBar.maxHealth += 20;

            LvlUp();
        }
    }
}
