using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character Info")]
public class CharacterSettings : ScriptableObject
{
    [Header("Characteristics")]
    public int strength;
    public float intellect;
    public float agility;
    public int health;
    public int armor; 

    [Header("Buff stats")]
    public float buffStrength;
    public float buffIntellect;
    public float buffAgility;

    public int Strength => strength;
    public float Intellect => intellect;
    public float Agility => agility;
    public int Health => health;
    public int Armor => armor; 
    public float BuffStrength => buffStrength;
    public float BuffIntellect => buffIntellect;
    public float BuffAgility => buffAgility;

    public float GetTotalStrength() => strength + buffStrength;
    public float GetTotalIntellect() => intellect + buffIntellect;
    public float GetTotalAgility() => agility + buffAgility;

    public void ModifyHealth(int amount)
    {
        health += amount;
        if (health < 0) health = 0;
    }

    public void ModifyArmor(int amount)
    {
        armor += amount;
        if (armor < 0) armor = 0;
    }
}
