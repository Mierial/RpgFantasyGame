using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private loot _loot;
    public int dropChanse;
    public void Awake()
    {
        dropChanse = _loot.dropChanse;
    }
}
