using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRevial : MonoBehaviour
{
    public CharacterHealth1 characterHealth;
    public Wallett wallett;

    public GameObject rebirtPosition;
    public GameObject PanelDeath;
    public Animator animator;
    public void Rebirth()
    {
        if (characterHealth != null && wallett.TotalCoins >= 500)
        {
            transform.position = rebirtPosition.transform.position;
            wallett.SubtractCoins(500);
            wallett.UpdateText();
            PanelDeath.SetActive(false);
            animator.ResetTrigger("Dead");
            PanelDeath.SetActive(false);

            characterHealth.Heal(100);
}
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
