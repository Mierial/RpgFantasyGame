using CustomPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Pool : MonoBehaviour
{
    [SerializeField] public Spawn_Sphere_Boss sphere;
    [SerializeField] public int poolSphere;

    private CustomPool<Spawn_Sphere_Boss> _sperePool;

    private void Awake()
    {
        _sperePool = new CustomPool<Spawn_Sphere_Boss> (sphere, poolSphere);
    }

    public void SpawnSphere()
    {
       
    }
}
