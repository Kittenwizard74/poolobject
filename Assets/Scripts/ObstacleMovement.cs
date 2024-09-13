using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float velocity = 3f;
    public float lifeTime;
    public float maxlifeTime;

    private void Update()
    {
        transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0); // Ahora el cactus se mueve hacia la izquierda (negativo pq es así en el eje X).
        lifeTime += Time.deltaTime; // Para que cuando aparezca el objeto empiece a contarse el tiempo de vida lifeTime.

        //if (lifeTime >= maxlifeTime)
        //{
        //    gameObject.SetActive(false);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("Memuero");
            gameObject.SetActive(false); 
        }
    }
}
