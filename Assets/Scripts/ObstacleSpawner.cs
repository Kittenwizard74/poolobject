using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}
