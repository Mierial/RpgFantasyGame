using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private Character _character;
    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Weapon weapon) )
        {
            _character.ClaimDamage(weapon.Damage);
            
            Debug.Log($"Damaged{weapon.Damage}" );
        }
        else if ( other.gameObject.CompareTag("atakedpoint") && other.gameObject.TryGetComponent(out Arrow arrow))
        {
            _character.ClaimDamage(arrow.damage);
            Debug.Log("Worked");
        }
        else { Debug.Log("LOX"); }
    }
}
