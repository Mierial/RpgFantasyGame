using System;
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
    public int Strength => strength;
    public float Intellect => intellect;
    public float Agility => agility;
    public int Health => health;
    public int Armor => armor; 
    
    
    
}
