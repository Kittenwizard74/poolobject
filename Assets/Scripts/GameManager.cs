using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    public static GameManager Instance { get; private set; }
    private int score;
    private float scoreTimer;

    private void Update()
    {
        Score();
    }

    private void Awake()
    {
       if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
       else
        {
            Instance = this;
        }
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void Score()
    {
        int scoreCounter = 10;

        scoreTimer += Time.deltaTime;
        score = (int)(scoreTimer * scoreCounter);
        scoreText.text = string.Format("{0:00000}", score);
    }
}
