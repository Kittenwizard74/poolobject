using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoControl : MonoBehaviour
{
    private Rigidbody2D playerRb; // Con esto se puede interactuar con las físicas del objeto en el juego.
    private AudioSource jumpSound;
    public float jumpingForce = 5f;
    public bool touchingGround = true;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            playerRb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse); // ForceMode.Impulse hace que al instante que se deja de apretar espacio, deja de funcionar.
            touchingGround = false; // Hace que solamente cuando no se colisione con el piso, salte. Sin esto saltaría infinitamente.
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            Time.timeScale = 0f;
        }
        touchingGround = true;
    }
}
