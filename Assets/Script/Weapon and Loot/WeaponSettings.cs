using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Info")]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private int needlvl;
    [SerializeField] private float attaktime;




    public float Attaktime => attaktime;
    public int NeedLvl => needlvl;
    public int Damage => damage;
}
