using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   public int damage;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    public void GetDataFromBow()
    {

        BowMech bow = GetComponentInParent<BowMech>();
        if (bow != null)
        {
            damage = bow.GetBowDamage();
        }
    }


    
}
