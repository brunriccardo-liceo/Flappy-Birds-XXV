using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    
public void AddScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
