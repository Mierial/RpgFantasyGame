using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings character;
    public HealthBar healthBar;
    public ArmorBar armorBar;
    [SerializeField]public Character charact;
    public int maxHealth = 1000;
    public int currentHealth;
    private int currentArmor = 0;

    private void Start()
    {
        currentHealth = charact.Health;
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

    public void Heal(int healAmount)
    {
        if (healAmount <= 0) return;

        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
    public void AddArmor(int armorAmount)
    {
        currentArmor += armorAmount;
        armorBar.slider.value = currentArmor;
    }


}
