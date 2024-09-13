using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class ObjectActivate : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float spawnInterval = 2f; // Tiempo entre activaciones
    private float timeSinceLastSpawn;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnInterval)
        {
            GameObject ObjectToPool = ObjectPool.Singleton.GetPooledObject();

            if (ObjectToPool != null)
            {
                ObjectToPool.transform.position = spawner.transform.position;
                ObjectToPool.transform.rotation = spawner.transform.rotation;
                ObjectToPool.SetActive(true);

                timeSinceLastSpawn = 0f;
            }
        }
    }
}
