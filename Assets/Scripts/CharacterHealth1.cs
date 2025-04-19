using UnityEngine;

public class CharacterHealth1 : MonoBehaviour
{
    [SerializeField] private Character charact;
    public CharacterSettings character;
    public HealthBar healthBar;
    public ArmorBar armorBar;
    public DeathRevial deathRevial;

    public ScreenFade screenFade;


    public int maxHealth = 100;
    public int currentHealth;
    private int currentArmor = 0;

    public Animator animator;

    private void Start()
    {
        currentHealth = 100;
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
        if (currentHealth <= 0)
        {
            screenFade.StartFade();
            animator.SetTrigger("Dead");
            deathRevial.PanelDeath.SetActive(true);
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
