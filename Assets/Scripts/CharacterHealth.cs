using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings character;
    public HealthBar healthBar;
    private int currentHealth = 100;
    public ArmorBar armorBar;
    private int currentArmor = 0;

    private void Start()
    {
        healthBar.SetHealth(currentHealth);


        armorBar.SetHealth(currentArmor);
    }


    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            if (currentHealth < 0) currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {

    }
}
