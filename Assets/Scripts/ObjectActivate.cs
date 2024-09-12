using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class ObjectActivate : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    private void Update()
    {
        GameObject ObjectToPool = ObjectPool.Singleton.GetPooledObject();

        if (ObjectToPool != null)
        {
            ObjectToPool.transform.position = spawner.transform.position;
            ObjectToPool.transform.rotation = spawner.transform.rotation;
            ObjectToPool.SetActive(true);
        }
    }


}
