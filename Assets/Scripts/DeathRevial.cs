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
            gameObject.SetActive(true);
            animator.SetTrigger("Reveal");
            transform.position = rebirtPosition.transform.position;
            wallett.SubtractCoins(500);
            wallett.UpdateText();
            PanelDeath.SetActive(false);

            characterHealth.Heal(100);

        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Reset()
    {
        animator.ResetTrigger("Dead");
        gameObject.SetActive(false);
    }
    public void RevealActiveAnim()
    {
        animator.ResetTrigger("Reveal");
    }
}
