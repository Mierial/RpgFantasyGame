using CustomPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn_Sphere_Boss : MonoBehaviour
{
    [SerializeField] private int _maxSphere;
    [SerializeField] private BoxCollider _arreaSpawn;
    private List<GameObject> _charaktersIn = new List<GameObject>();
    private CustomPool<Spawn_Sphere_Boss> _sperePool;
    private int _spawnedSphere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("attakedpoint"))
        {
            
        }
        else { _charaktersIn.Add(other.gameObject); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("attakedpoint"))
        {

        }
        else { _charaktersIn.Remove(other.gameObject); }
        
    }
    private void FixedUpdate()
    {
        if(_charaktersIn.Count >= 1)
        {
            if(_spawnedSphere <= _maxSphere)
            {
                SpawnObject();
                _spawnedSphere++;
            }
        }
        
    }

    private void SpawnObject()
    {
        Vector3 randomPosition = GetRandomPointInCollider(_arreaSpawn);
        _sperePool.Get(randomPosition, Quaternion.identity);
        
    }

  private  Vector3 GetRandomPointInCollider(BoxCollider collider)
    {
        Vector3 boundsMin = collider.bounds.min;
        Vector3 boundsMax = collider.bounds.max;

        float x = Random.Range(boundsMin.x, boundsMax.x);
        float y = Random.Range(boundsMin.y, boundsMax.y);
        float z = Random.Range(boundsMin.z, boundsMax.z);

        return new Vector3(x, y, z);
    }
}
