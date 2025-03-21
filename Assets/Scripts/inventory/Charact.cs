using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Charact
{
    public int Health {  get; set; }
    public int AttackPower {  get; set; }


    public abstract void SpecialAttack();


}
public class Mage : Charact
{
    public override void SpecialAttack()
    {
        //тут поивнна бути логіка атаки цього мага, наприклад enemy.Health-=10;
       //attackPower+=15
    }
}