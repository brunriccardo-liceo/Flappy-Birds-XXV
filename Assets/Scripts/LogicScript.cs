using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public GameObject pauseMenu;
    public bool gameIsPaused = false;
    public GameObject darkBG;


    public void AddScore(int score)
    {
        if (bird.birdIsAlive)
        {
            playerScore += score;
            scoreText.text = playerScore.ToString();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        bird.birdIsAlive = false;
        gameOverScreen.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        darkBG.SetActive(true);

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        darkBG.SetActive(false);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


}
