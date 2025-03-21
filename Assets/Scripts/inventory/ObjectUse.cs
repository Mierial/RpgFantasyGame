using UnityEngine;

public class ObjectUse : MonoBehaviour
{
    public void UseObject(GameObject obj)
    {
        Debug.Log("Используется объект: " + obj.name);
    }
}
