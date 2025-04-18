using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public ArmorBar armorBar;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxArmor = 0;
    private int currentArmor = 0;

    public int CurrentHealth => currentHealth;
    public int CurrentArmor => currentArmor;
    public int MaxHealth => maxHealth;
    public int MaxArmor => maxArmor;

    private void Start()
    {
        currentHealth = maxHealth;
        currentArmor = 0;
        UpdateBars();
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
        }

        if (remainingDamage > 0)
        {
            currentHealth -= remainingDamage;
            currentHealth = Mathf.Max(currentHealth, 0);
        }

        UpdateBars();
    }

    public bool Heal(int healAmount)
    {
        if (healAmount <= 0) return false;

        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
            UpdateBars();
            return true;
        }
        return false;
    }

    public void RepairArmor(int armorAmount)
    {
        if (armorAmount <= 0) return;
        currentArmor = Mathf.Min(currentArmor + armorAmount, maxArmor);
        UpdateBars();
    }

    public void AddHealth(int value)
    {
        if (value <= 0) return;
        currentHealth = Mathf.Min(currentHealth + value, maxHealth);
        UpdateBars();
    }

    public void AddArmor(int value)
    {
        if (value <= 0) return;
        currentArmor = Mathf.Min(currentArmor + value, maxArmor);
        UpdateBars();
    }

    private void UpdateBars()
    {
        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        if (armorBar != null)
            armorBar.SetHealth(currentArmor);
    }
}
