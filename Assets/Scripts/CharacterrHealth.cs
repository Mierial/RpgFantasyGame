using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public ArmorBar armorBar;

    [SerializeField] private int maxHealth = 100;
    [SerializeField]private int currentHealth;
    private int currentArmor = 0;
    [SerializeField] private int maxArmor = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        currentArmor = maxArmor;
        healthBar.SetHealth(currentHealth);
        armorBar.SetHealth(currentArmor);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        int remainingDamage = damage;

        if (currentArmor > 0)
        {
            int absorbed = Mathf.Min(currentArmor, damage);
            currentArmor -= absorbed;
            remainingDamage -= absorbed;
            armorBar.SetHealth(currentArmor);
        }

        if (remainingDamage > 0)
        {
            currentHealth -= remainingDamage;
            currentHealth = Mathf.Max(currentHealth, 0);
            healthBar.SetHealth(currentHealth);
        }
    }

    public bool Heal(int healAmount)
    {
        if (healAmount <= 0) return false;

        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
            healthBar.SetHealth(currentHealth);
            return true;
        }
           return false;
    }
    public void RepairArmor(int armorAmount)
    { 
        currentArmor += armorAmount;
        if (currentArmor >= maxArmor)
            currentArmor = maxArmor;
        armorBar.slider.value = currentArmor;
    }

    public void AddHealth(int value)
    {
        currentHealth += value;
        healthBar.slider.value = currentHealth;
    }

    public void AddArmor(int value)
    {
        currentArmor += value;
        armorBar.slider.value = currentArmor;
    }


}
