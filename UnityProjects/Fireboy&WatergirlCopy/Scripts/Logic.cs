using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    [SerializeField] private int bluePlayerScore = 0;
    [SerializeField] private int redPlayerScore = 0;
    [SerializeField] private TextMeshProUGUI blueScoreText;
    [SerializeField] private TextMeshProUGUI redScoreText;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject levelCompleteScreen;
    [SerializeField] private GameObject gameOverScreen;
    private GameObject bluePlayer;
    private GameObject redPlayer;
    private bool gamePaused = false;
    [SerializeField] private AudioSource gemCollectSound;

    

    private void Awake()
    {
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
        redPlayer = GameObject.FindGameObjectWithTag("RedPlayer");
        Physics2D.IgnoreCollision(redPlayer.GetComponent<Collider2D>(),
            bluePlayer.GetComponent<Collider2D>());
    }
    void Update()
    {
        // Additional Controls
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            UnPauseGame();
        }
    }

    public void AddBlueScore(int score)
    {
        bluePlayerScore += score;
        blueScoreText.text = bluePlayerScore.ToString();
    }

    public void AddRedScore(int score)
    {
        redPlayerScore += score;
        redScoreText.text = redPlayerScore.ToString();
    }

    public void PlayCollectGemSound()
    {
        gemCollectSound.Play();
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void UnPauseGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void LevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
